using adc.core;
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
			var algoritm = CreateAlgoritm();

			var ideal = algoritm.GetIdealCharacteristic();
			Message("Идеальное распределение :{0}\r\n", ideal);
			var errors = algoritm.GetErrors();
			Message("Погрешности :{0}\r\n", errors);
			var real = algoritm.GetRealCharacteristic(errors);
			ShowIdealAndReal(ideal, real);
			Message("Реальное распределение :{0}\r\n", real);

			var diff = GetDiff(ideal, real);
			ShowDiff(diff);
			Message("Разность :{0}", diff);
			Message("Математическое ожидание = " + Statistics.Median(diff));
			Message("Дисперсия = " + Statistics.Variance(diff));
			Message("Среднеквадратичное отклонеение = {0}\r\n", Statistics.StandardDeviation(diff));

			Message("Гистограмма: ");
			var k = (int)_kNumericUpDown.Value;
			var histogram = new Histogram(diff, k);
			ShowHistogram(histogram);
			Message("\tМаксимум по x {0}", histogram.UpperBound);
			Message("\tМинимум по x {0}", histogram.LowerBound);
			for (int i = 0; i < histogram.BucketCount; i++)
			{
				var backet = histogram[i];
				Message("\tотрезок {0}, ширина {1} количество {2} мин x {4} макс x {3} ", i, backet.Width, backet.Count, backet.UpperBound, backet.LowerBound);
			}
			Message("");
		}

		private void ShowIdealAndReal(double[] ideal, double[] real)
		{
			var zedGraph = zedGraphControl1;
			GraphPane pane = zedGraph.GraphPane;
			pane.CurveList.Clear();
			var xArray = Enumerable.Range(0, ideal.Length).Select(x => (double)x).ToArray();

			pane.AddCurve("Ideal", xArray, ideal, Color.Green, SymbolType.None);
			pane.AddCurve("Real", xArray, real, Color.Red, SymbolType.None);
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

		private void Message(string message, params object[] args)
		{
			if (args != null)
				args = args.Select(a => a is IEnumerable ?
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
