﻿using MathNet.Numerics.Distributions;
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
		public double[] GetIdealCharacteristic()
		{
			var steps = (int)Math.Pow(2, _n);
			var result = new double[steps];
			for (int a = 0; a < steps; a++)
			{
				result[a] = GetIdealCharacteristicStep(a);
			}
			return result;
		}

		/// <summary>
		/// Идеальная характеристика для одного значения из последовательности от 0 до ((2^_n) -1)
		/// </summary>
		/// <param name="a">Значение из последовательности от 0 до ((2^_n) -1)</param>
		/// <returns></returns>
		private double GetIdealCharacteristicStep(int a)
		{
			double summ = 0;
			for (int i = 0; i <= _n; i++)
			{
				var ai = ((a >> i) & 0x1);
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
		public double[] GetRealCharacteristic(double[] errors)
		{
			if (errors.Length != _n)
				throw new ArgumentOutOfRangeException(String.Format("Количество погрешностей не соответствует числу разрядов {0}", _n));

			var steps = (int)Math.Pow(2, _n);
			var result = new double[steps];
			for (int a = 0; a < steps; a++)
			{
				result[a] = GetRealCharacteristicStep(a, errors);
			}
			return result;

		}

		/// <summary>
		/// Реалная характеристика для одного значения из последовательности от 0 до ((2^_n) -1)
		/// </summary>
		/// <param name="a">Значение из последовательности от 0 до ((2^_n) -1)</param>
		/// <param name="errors">Массив погрешностей</param>
		/// <returns></returns>
		private double GetRealCharacteristicStep(int a, double[] errors)
		{
			double summ = 0;
			var stepsCount = _n - 1;
			for (int i = 0; i <= stepsCount; i++)
			{
				var ai = ((a >> i) & 0x1);
				var error = errors[i];
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

		/*
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
		}*/
	}
}