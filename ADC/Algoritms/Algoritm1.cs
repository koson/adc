using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adc.Algoritms
{
	public class Algoritm1
	{
		private  double _p0;
		private  int _n;
		private  double _gamma;

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
				result[i] = ProcessStep(i+1);
			}
			return result;
		}

		public class Result
		{
			public double[] Steps { get; private set; }
		}
	}
}
