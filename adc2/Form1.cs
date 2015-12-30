using Accord.Statistics.Testing;
using adc.core;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.Statistics;
using System;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ZedGraph;

namespace adc2
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private double[] GetErrors(Algoritm algoritm)
		{
			if (String.IsNullOrEmpty(errorsTextBox.Text.Trim()))
			{
				button2_Click(null, null);
			}
			try
			{
				return errorsTextBox.Text.
					Split(';').
					Select(er =>
					{
						double tmp;
						if (!double.TryParse(er.Replace(',', '.'), out tmp))
							double.TryParse(er.Replace('.', ','), out tmp);
						return tmp;
					}).
					ToArray();
			}
			catch (Exception ex)
			{
				MessageBox.Show(String.Format("Ошибка при разборе погрешностей: {0}", ex.Message));
				return null;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				Func<double, int, double> idealSumElementFunction = null;
				Func<double, double, int, double> realSumElementFunction = null;

				if (plusRadioButton.Checked)
				{
					idealSumElementFunction = (ai, i) => ai * Math.Pow(2, i);
					realSumElementFunction = (ai, error, i) => ai * Math.Pow(2, i + error);
				}

				var algoritm = CreateAlgoritm();

				var ideal = algoritm.GetIdealCharacteristic(idealSumElementFunction);
				Message("Идеальное распределение :{0}\r\n", ideal);

				var errors = GetErrors(algoritm);
				if (errors == null)
					return;

				Message("Погрешности :{0}\r\n", errors);

				var real = algoritm.GetRealCharacteristic(errors, realSumElementFunction);
				ShowIdealAndReal(ideal, real);
				Message("Реальное распределение :{0}\r\n", real);

				var diff = GetDiff(ideal, real);
				var mean = Statistics.Mean(diff);
				var variance = Statistics.Variance(diff);
				var standardDeviation = Statistics.StandardDeviation(diff);
				ShowDiff(diff);
				Message("Разность :{0}", diff);
				Message("Математическое ожидание = {0}", mean);
				Message("Дисперсия = {0}", variance);
				Message("Среднеквадратичное отклонеение = {0}\r\n", standardDeviation);

				Message("Гистограмма: ");
				var k = (int)_kNumericUpDown.Value;
				var histogram = new Histogram(diff, k);
				ShowHistogram(histogram);
				Message("\tМаксимум по x {0}", histogram.UpperBound);
				Message("\tМинимум по x {0}", histogram.LowerBound);

				ChiSquareTest(histogram, mean, standardDeviation);
			}
			catch (Exception ex)
			{
				MessageBox.Show(String.Format("Произошла ошибка: {0}", ex.Message));
			}
		}

		private void ChiSquareTest(Histogram histogram, double mean, double standardDeviation)
		{
			var normalCDF = new double[histogram.BucketCount + 1];
			var realHistogram = new double[histogram.BucketCount];
			var normalHistogram = new double[histogram.BucketCount];
			var x = new double[histogram.BucketCount];

			var normal = new Normal(mean, standardDeviation);

			for (int i = 0; i < histogram.BucketCount; i++)
			{
				var backet = histogram[i];
				x[i] = backet.LowerBound;
				// Взяли левую границу интервалов
				normalCDF[i + 1] = Normal.CDF(mean, standardDeviation, backet.UpperBound);
				realHistogram[i] = backet.Count;
				Message("\tотрезок {0}, ширина {1} количество {2} мин x {4} макс x {3} ", i, backet.Width, backet.Count, backet.UpperBound, backet.LowerBound);
			}

			normalCDF[0] = Normal.CDF(mean, standardDeviation, histogram.LowerBound);
			for (int i = 0; i < normalCDF.Length - 1; i++)
			{
				normalHistogram[i] = (normalCDF[i + 1] - normalCDF[i]) * histogram.DataCount;
			}

			Message("normal histogramm {0}", normalHistogram);
			Message("real histogramm {0}", realHistogram);
			//ShowHistogram(x, normalHistogram);
			var test = new ChiSquareTest(normalHistogram, realHistogram, normalHistogram.Length - 1);
			Message("(Критерий пирсона) Уровень значимости = {0}", test.PValue);
			Message("Распределение {0} является нормальным", test.Significant ? "не" : "");
		}

		private void ShowIdealAndReal(double[] ideal, double[] real)
		{
			var zedGraph = zedGraphControl1;
			GraphPane pane = zedGraph.GraphPane;
			pane.CurveList.Clear();
			var xArray = Enumerable.Range(0, ideal.Length).Select(x => (double)x).ToArray();

			var curve = pane.AddCurve("Ideal", xArray, ideal, Color.Green, SymbolType.None);
			curve.Line.StepType = StepType.ForwardStep;
			curve = pane.AddCurve("Real", xArray, real, Color.Red, SymbolType.None);
			curve.Line.StepType = StepType.ForwardStep;
			zedGraph.AxisChange();
			zedGraph.Invalidate();
		}

		private void ShowDiff(double[] diff)
		{
			var zedGraph = zedGraphControl2;
			GraphPane pane = zedGraph.GraphPane;
			pane.CurveList.Clear();
			var xArray = Enumerable.Range(0, diff.Length).Select(x => (double)x).ToArray();

			var curve = pane.AddCurve("Diff", xArray, diff, Color.Green, SymbolType.None);
			curve.Line.StepType = StepType.ForwardStep;
			zedGraph.AxisChange();
			zedGraph.Invalidate();
		}

		private void ShowHistogram(Histogram histogram)
		{
			var zedGraph = zedGraphControl3;
			GraphPane pane = zedGraph.GraphPane;
			pane.GraphObjList.Clear();

			for (int i = 0; i < histogram.BucketCount; i++)
			{
				var height = histogram[i].Count; // histogram.DataCount;
				BoxObj box = new BoxObj(histogram[i].LowerBound,
					height,
					histogram[i].Width,
					height);

				box.IsClippedToChartRect = true;
				box.Fill.Color = Color.Green;
				pane.GraphObjList.Add(box);
			}
			pane.XAxis.Scale.Max = histogram.UpperBound;
			pane.XAxis.Scale.Min = histogram.LowerBound;
			pane.YAxis.Scale.Max = histogram.DataCount;
			pane.YAxis.Scale.Min = 0;

			zedGraph.AxisChange();
			zedGraph.Invalidate();
		}

		private void ShowHistogram(double[] x, double[] histogram)
		{
			var zedGraph = zedGraphControl3;
			GraphPane pane = zedGraph.GraphPane;
			pane.GraphObjList.Clear();

			var width = x[0] - x[1];
			for (int i = 0; i < x.Length; i++)
			{
				var height = histogram[i];
				BoxObj box = new BoxObj(x[i],
					height,
					width,
					height);

				box.IsClippedToChartRect = true;
				box.Fill.Color = Color.Green;
				pane.GraphObjList.Add(box);
			}
			pane.XAxis.Scale.Max = x[x.Length - 1];
			pane.XAxis.Scale.Min = x[0];
			pane.YAxis.Scale.Max = histogram.Max();
			pane.YAxis.Scale.Min = 0;

			zedGraph.AxisChange();
			zedGraph.Invalidate();
		}

		private void Message(string message, params object[] args)
		{
			if (args != null)
				args = args.Select(a => a is IEnumerable && !(a is string) ?
				string.Join(", ", ((IEnumerable)a).OfType<object>().Select(i => i.ToString()).ToArray()) : a).
				ToArray();
			_richTextBox.AppendText(String.Format(message, args));
			_richTextBox.AppendText(Environment.NewLine);
		}

		private Algoritm CreateAlgoritm()
		{
			double u0 = (double)_u0NumericUpDown.Value;
			int n = (int)_nNumericUpDown.Value;
			return new Algoritm(u0, n);
		}

		private double[] GetDiff(double[] ideal, double[] real)
		{
			var diff = new double[ideal.Length];
			for (int i = 0; i < ideal.Length; i++)
			{
				diff[i] = real[i] - ideal[i];
			}
			return diff;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			double[] errors;

			var algoritm = CreateAlgoritm();
			if (radioButton2.Checked)
				errors = algoritm.GetErrors2();
			else if (radioButton3.Checked)
				errors = algoritm.GetErrors2Inv();
			else errors = algoritm.GetErrors();

			errorsTextBox.Text = String.Join("; ", errors.Select(er => er.ToString()).ToArray());
		}
	}
}
