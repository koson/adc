using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using adc.Algoritms;

namespace adc.tests
{
	[TestClass]
	public class Algorim1Test
	{
		[TestMethod]
		public void ProcessStepTest()
		{
			var n = 2;
			var p0 = 2;
			var gamma = 4;
			Assert.AreEqual(8, new Algoritm1(p0, n, gamma).ProcessStep(1));
			Assert.AreEqual(16, new Algoritm1(p0, n, gamma).ProcessStep(2));
		}

		[TestMethod]
		public void ProcessTest()
		{
			var n = 3;
			var p0 = 2;
			var gamma = 4;
			var result = new Algoritm1(p0, n, gamma).Process();
			Assert.AreEqual(8, result.Length);
			Assert.AreEqual(4, result[0]);
			Assert.AreEqual(8, result[1]);
			Assert.AreEqual(12, result[2]);
		}
	}
}
