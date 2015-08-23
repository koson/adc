using MathNet.Numerics.Distributions;
using System;

namespace adc.core
{
	public class Algoritm
	{
		private double _u0;
		private int _n;

		public Algoritm(double u0, int n)
		{
			_u0 = u0;
			_n = n;
		}

		/// <summary>
		/// Вычисление идеальной характеристики 
		/// Формула: ua = u0 + SUM{i = [0;n-1]}(ai * (2^-i))
		/// где a = [0;(2^n) - 1]
		/// u0 - константа
		/// ai - значение i бита в числе a
		/// </summary>
		/// <returns></returns>
		public double[] GetIdealCharacteristic(Func<double, int, double> sumElement = null)
		{
			var steps = (int)Math.Pow(2, _n);
			var result = new double[steps];
			for (int a = 0; a < steps; a++)
			{
				result[a] = GetIdealCharacteristicStep(a, sumElement);
			}
			return result;
		}

		/// <summary>
		/// Идеальная характеристика для одного значения из последовательности от 0 до ((2^_n) -1)
		/// </summary>
		/// <param name="a">Значение из последовательности от 0 до ((2^_n) -1)</param>
		/// <returns></returns>
		private double GetIdealCharacteristicStep(int a, Func<double, int, double> sumElement = null)
		{
			double summ = 0;
			for (int i = 0; i <= _n; i++)
			{
				var ai = ((a >> i) & 0x1);
				if (sumElement != null)
					summ += sumElement(ai, i);
				else
					summ += ai * Math.Pow(2, -i);
			}
			return _u0 * summ;
		}

		/// <summary>
		/// Вычисление реальной характеристики
		/// Формула: ua = u0 + SUM{i = [0;n-1]}(ai * (2^-(i+di))
		/// где a = [0;(2^n) - 1]
		/// u0 - константа
		/// ai - значение i бита в числе a
		/// di - i погрешность из массива errors
		/// </summary>
		/// <param name="errors"></param>
		/// <returns></returns>
		public double[] GetRealCharacteristic(double[] errors, Func<double, double, int, double> sumElement = null)
		{
			if (errors.Length != _n)
				throw new ArgumentOutOfRangeException(String.Format("Количество погрешностей не соответствует числу разрядов {0}", _n));

			var steps = (int)Math.Pow(2, _n);
			var result = new double[steps];
			for (int a = 0; a < steps; a++)
			{
				result[a] = GetRealCharacteristicStep(a, errors, sumElement);
			}
			return result;

		}

		/// <summary>
		/// Реалная характеристика для одного значения из последовательности от 0 до ((2^_n) -1)
		/// </summary>
		/// <param name="a">Значение из последовательности от 0 до ((2^_n) -1)</param>
		/// <param name="errors">Массив погрешностей</param>
		/// <returns></returns>
		private double GetRealCharacteristicStep(int a, double[] errors, Func<double, double, int, double> sumElement = null)
		{
			double summ = 0;
			var stepsCount = _n - 1;
			for (int i = 0; i <= stepsCount; i++)
			{
				var ai = ((a >> i) & 0x1);
				var error = errors[i];
				if (sumElement != null)
					summ += sumElement(ai, error, i);
				else
					summ += ai * Math.Pow(2, -(i + error));
			}
			return _u0 * summ;
		}

		/// <summary>
		/// Возвращает массив погрешностей распределенных по равномерному закону распределения
		/// </summary>
		/// <returns></returns>
		public double[] GetErrors()
		{
			var result = new double[_n];
			var upper = 0.5 * _u0 / _n;
			var continuousUniform = new ContinuousUniform(-upper, upper);
			continuousUniform.Samples(result);
			return result;
		}
	}
}
