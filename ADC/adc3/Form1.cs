using NLog;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace adc3
{
    public partial class Form1 : Form
    {
        private Logger _log = LogManager.GetCurrentClassLogger();
        public Form1()
        {
            InitializeComponent();
            InitGraph();
        }

        private void InitGraph()
        {
            var pane = zedGraphControl1.GraphPane;
            pane.XAxis.Cross = 0.0;
            pane.YAxis.Cross = 0.0;
            // Отключим отображение первых и последних меток по осям
            pane.XAxis.Scale.IsSkipFirstLabel = true;
            pane.XAxis.Scale.IsSkipLastLabel = true;
            // Отключим отображение меток в точке пересечения с другой осью
            pane.XAxis.Scale.IsSkipCrossLabel = true;
            // Отключим отображение первых и последних меток по осям
            pane.YAxis.Scale.IsSkipFirstLabel = true;
            // Отключим отображение меток в точке пересечения с другой осью
            pane.YAxis.Scale.IsSkipLastLabel = true;
            pane.YAxis.Scale.IsSkipCrossLabel = true;
            // Спрячем заголовки осей
            pane.XAxis.Title.IsVisible = false;
            pane.YAxis.Title.IsVisible = false;
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }
        /*
        private void Show1()
        {
            var zedGraph = zedGraphControl1;
            var pane = zedGraph.GraphPane;
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
        }*/

        private void start_Click(object sender, EventArgs e)
        {
            try
            {
                InputData data = ReadInputData();
                var algoritm = new Algoritm(data.P0, data.N);
                RichTextBoWriteLine("АЦП\r\n");
                RichTextBoWriteLine("N[{{Xi}}] = SUM{{i = [0;n-1]|j=n-1-i}}(xi * (2^-j)");
                RichTextBoWriteLine("ai - значение i-того бита в числе a");
                RichTextBoWriteLine(Color.Green, "n = {0}, a = {1}", data.N, data.A);
                double N = algoritm.GetIdealCharacteristicStep(data.A);
                RichTextBoWriteLine(Color.Green, "N[{{Xi}}] = {0}\r\n", N);

                RichTextBoWriteLine("Pq = P0 * N[{{Xi}}]");
                double Pq = N * data.P0;
                RichTextBoWriteLine(Color.Green, "Pq = {0}\r\n", Pq);

                RichTextBoWriteLine("Смещение dUсм = 0.5*P0*x0*(2^-(n-1))");
                RichTextBoWriteLine("x0 = Rос*Sфп");
                double x0 = data.R * data.S;
                RichTextBoWriteLine(Color.Green, "x0 = {0}", x0);
                double dUсм = 0.5 * data.P0 * x0 * Math.Pow(2, -(data.N - 1));
                RichTextBoWriteLine(Color.Green, "dUсм = {0}\r\n", dUсм);

                RichTextBoWriteLine("Сигнал с выхода усилителя U");
                RichTextBoWriteLine("U = Sоф*Roc*Qi*P0*N[{{Xi}}] + dUсм");
                double U = data.S * data.R * data.Q * data.P0 * N + dUсм;
                RichTextBoWriteLine(Color.Green, "U = {0}\r\n", U);
                RichTextBoWriteLine("ЦАП\r\n");
                RichTextBoWriteLine("Uоп = 2*P0*Rос*Sоф");
                double Uop = 2 * data.P0 * data.R * data.S;
                RichTextBoWriteLine(Color.Green, "Uоп = {0}", Uop);
                RichTextBoWriteLine("Em = IF U >= Uоп * m/(2^n) THEN 1 ELSE 0 ");
                RichTextBoWriteLine("где m = [1;(2^n))]");
                int mMax = (int)Math.Pow(2, data.N) - 1;
                RichTextBoWriteLine(Color.Green, "mMax = {0}", mMax);
                bool[] E = new bool[mMax];
                for (int m = 1; m <= mMax; m++)
                {
                    E[m - 1] = (U >= m * Uop / (Math.Pow(2, data.N))) ? true : false;
                }
                RichTextBoWriteLine(Color.Green, "e = {0}", String.Join("", E.Reverse().Select(em => em ? "1" : "0")));
                var result = E.Where(em => em).Count();
                RichTextBoWriteLine("РЕЗУЛЬТАТ: {0}", result);

            }
            catch (Exception exc)
            {
                _log.Error(exc, "start bitton exception:");
                MessageBox.Show(exc.Message);
            }
        }

        private void RichTextBoWriteLine(Color? color, string message, params object[] args)
        {
            Color oldColor = this.richTextBox1.BackColor;
            if (color.HasValue)
            {
                this.richTextBox1.BackColor = color.Value;
            }
            this.richTextBox1.AppendText(String.Format(message, args));
            this.richTextBox1.AppendText(Environment.NewLine);
            this.richTextBox1.BackColor = oldColor;
        }

        private void RichTextBoWriteLine(string message, params object[] args)
        {
            RichTextBoWriteLine(null, message, args);
        }

        private InputData ReadInputData()
        {
            var data = new InputData();
            data.A = (int)a_numericUpDown.Value;
            data.N = (int)n_numericUpDown.Value;
            if (data.A > Math.Pow(2, data.N) - 1)
                throw new ApplicationException(String.Format("Положение концевиков {0} не соответствует разрядности {1}", data.A, data.N));
            data.P0 = (double)p0_numericUpDown.Value;
            data.S = (double)s_numericUpDown.Value;
            data.R = (double)r_numericUpDown.Value;
            data.Q = (double)q_numericUpDown.Value;

            return data;
        }
    }

    class InputData
    {
        public int A { get; internal set; }
        public int N { get; internal set; }
        public double P0 { get; internal set; }
        public double Q { get; internal set; }
        public double R { get; internal set; }
        public double S { get; internal set; }
    }
}
