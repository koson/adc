using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace adc.Algoritms
{
	public class Algoritm1
	{
		private double _p0;
		private int _n;
		private double _gamma;

		public Algoritm1(double p0, int n, double gamma)
		{
			_p0 = p0;
			_n = n;
			_gamma = gamma;
		}

		public double ProcessStep(int a)
		{
			double summ = 0;
			for (int i = 0; i <= _n; i++)
			{
				var ai = (double)((a >> (_n - i)) & 0x1);
				summ += ai * Math.Pow(2, -i + _gamma);
			}
			return _p0 * summ;
		}

		public double[] Process()
		{
			var steps = (int)Math.Pow(2, _n);
			var result = new double[steps];
			for (int i = 0; i < steps; i++)
			{
				result[i] = ProcessStep(i + 1);
			}
			return result;
		}

		public Result2 Process2(double[] steps)
		{
			var result = new Result2();

			result.Deltas = new double[steps.Length];

			var max = steps[steps.Length - 1];
			for (int i = 0; i < steps.Length; i++)
			{
				result.Deltas[i] = steps[i] - ((i + 1d) * max) / (double)steps.Length;
			}

			result.MaxDelta = result.Deltas.Max(d => Math.Abs(d));

			return result;
		}

		public Result Process1(double[] steps)
		{
			var result = new Result();

			result.IdealQuantum = steps[steps.Length - 1] / (double)steps.Length;

			result.DeltaQuantums = new double[steps.Length];
			var prevStep = 0d;
			for (int i = 0; i < steps.Length; i++)
			{
				result.DeltaQuantums[i] = result.IdealQuantum - (steps[i] - prevStep);
				prevStep = steps[i];
			}

			result.MaxDeltaQuantum = result.DeltaQuantums.Max(q => Math.Abs(q));

			return result;
		}
		public class Result
		{
			public double IdealQuantum { get; internal set; }
			/// <summary>
			/// Разница квантов с идеальным
			/// </summary>
			public double[] DeltaQuantums { get; internal set; }
			public double MaxDeltaQuantum { get; internal set; }
		}

		public class Result2
		{
			public double[] Deltas { get; internal set; }
			public double MaxDelta { get; internal set; }
		}
	}
}
