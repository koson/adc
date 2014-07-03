using adc.Algoritms;
using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace ADC
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			this.zedGraphControl1.GraphPane.XAxis.Title.Text = "N";
			this.zedGraphControl1.GraphPane.YAxis.Title.Text = "P";
			this.zedGraphControl1.GraphPane.YAxis.Title.FontSpec.Angle = 90;
		}

		private void clearAll()
		{
			dataGridView1.Rows.Clear();
			dataGridView1.Columns.Clear();
			label_IdelQuant.Visible = false;
			label_Maximum.Visible = false;
		}

		private Algoritm1 createAlgoritm()
		{
			return new Algoritm1(double.Parse(textBox_P0.Text.Replace(".", ","))
						, int.Parse(textBox_N.Text)
						, double.Parse(textBox_Gamma.Text.Replace(".", ",")));
		}

		private void button3_Click(object sender, EventArgs e)
		{
			try
			{
				clearAll();
				var algoritm = createAlgoritm();
				var steps = showSteps(algoritm);
				var result = algoritm.Process2(steps);
				showResult2(steps, result);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void showResult2(double[] steps, Algoritm1.Result2 result)
		{
			var index = this.dataGridView1.Columns.Add("Delta", "Delta");
			this.dataGridView1.Columns[index].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			for (int i = 0; i < result.Deltas.Length; i++)
			{
				dataGridView1.Rows[i].Cells["Delta"].Value = result.Deltas[i];
			}
			label_Maximum.Text = "Максимум: " + result.MaxDelta;
			label_Maximum.Visible = true;

			var zedGraph = this.zedGraphControl1;
			GraphPane pane = zedGraph.GraphPane;

			PointPairList list = new PointPairList();

			list.Add(0, 0);
			list.Add(steps.Length, steps[steps.Length - 1]);
			LineItem myCurve = pane.AddCurve("Sinc", list, Color.Green, SymbolType.None);
			zedGraph.AxisChange();
			zedGraph.Invalidate();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				clearAll();
				var algoritm = createAlgoritm();
				var steps = showSteps(algoritm);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private double[] showSteps(Algoritm1 algoritm)
		{

			double[] steps = null;
			if (radioButton1.Checked)
				steps = algoritm.Process(StepAlgoritm.Old);
			if (radioButton2.Checked)
				steps = algoritm.Process(StepAlgoritm.Step1);
			if (radioButton3.Checked)
				steps = algoritm.Process(StepAlgoritm.Step2);

			this.dataGridView1.Columns.Add("N", "N");
			var index = this.dataGridView1.Columns.Add("step", "Шаг");
			this.dataGridView1.Columns[index].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			for (int i = 0; i < steps.Length; i++)
			{
				dataGridView1.Rows.Add(i + 1, steps[i]);
			}

			var zedGraph = this.zedGraphControl1;
			GraphPane pane = zedGraph.GraphPane;
			pane.CurveList.Clear();

			PointPairList list = new PointPairList();

			list.Add(0, 0);
			list.Add(0, 1);
			list.Add(PointPairBase.Missing, PointPairBase.Missing);

			for (int x = 0; x < steps.Length; x++)
			{
				list.Add(x + 1, steps[x]);
				list.Add(x + 2, steps[x]);
				list.Add(PointPairBase.Missing, PointPairBase.Missing);
			}

			LineItem myCurve = pane.AddCurve("Sinc", list, Color.Blue, SymbolType.None);
			zedGraph.AxisChange();
			pane.YAxis.Scale.Max = steps[steps.Length - 1] * 1.1;
			zedGraph.Invalidate();
			return steps;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			try
			{
				clearAll();
				var algoritm = createAlgoritm();
				var steps = showSteps(algoritm);
				var result = algoritm.Process1(steps);
				showResult1(result);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void showResult1(Algoritm1.Result result)
		{
			var index = this.dataGridView1.Columns.Add("DeltaQuantum", "DeltaQuantum");
			this.dataGridView1.Columns[index].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			for (int i = 0; i < result.DeltaQuantums.Length; i++)
			{
				dataGridView1.Rows[i].Cells["DeltaQuantum"].Value = result.DeltaQuantums[i];
			}
			label_IdelQuant.Text = "Идеальный квант: " + result.IdealQuantum;
			label_Maximum.Text = "Максимум: " + result.MaxDeltaQuantum;
			label_IdelQuant.Visible =
				label_Maximum.Visible = true;
		}


	}
}
