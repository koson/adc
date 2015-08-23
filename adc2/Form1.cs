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

		private void button1_Click(object sender, EventArgs e)
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

			var errors = algoritm.GetErrors();
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
			var normalHistogram = new double[histogram.BucketCount - 1];
			var realHistogram = new double[histogram.BucketCount - 1];
			var x = new double[histogram.BucketCount - 1];

			for (int i = 0; i < histogram.BucketCount; i++)
			{
				var backet = histogram[i];
				// начало первого интервала в гистограмме пропускаем  
				if (i != 0)
				{
					x[i - 1] = backet.LowerBound;
					normalHistogram[i - 1] = Normal.PDFLn(mean, standardDeviation, x[i - 1]);
					realHistogram[i - 1] = backet.Count;
				}
				Message("\tотрезок {0}, ширина {1} количество {2} мин x {4} макс x {3} ", i, backet.Width, backet.Count, backet.UpperBound, backet.LowerBound);
			}
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
			curve.Line.StepType = StepType.RearwardStep;
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
				var height = histogram[i].Count / histogram.DataCount;
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
			pane.YAxis.Scale.Max = 1;
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
	}
}
