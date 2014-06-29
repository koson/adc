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

		[TestMethod]
		public void Process1Test()
		{
			var n = 3;
			var p0 = 2;
			var gamma = 0.2;
			var algoritm = new Algoritm1(p0, n, gamma);
			var steps = algoritm.Process();
			var result = algoritm.Process1(steps);
			Assert.AreEqual(0.00000000000000016653345369377348, result.MaxDeltaQuantum);
			Assert.AreEqual(0.28717458874925877, result.IdealQuantum);
			var expect = new double[8]{ 
				0.0
				, 0.00000000000000011102230246251565
				, 0.000000000000000055511151231257827
				, 0.000000000000000055511151231257827
				, 0.000000000000000055511151231257827
				, 0.000000000000000055511151231257827
				, -0.00000000000000016653345369377348
				, -0.00000000000000016653345369377348
			};
			CollectionAssert.AreEqual(expect, result.DeltaQuantums);
		}

		[TestMethod]
		public void Process2Test()
		{
			var n = 3;
			var p0 = 2;
			var gamma = 0.2;
			var algoritm = new Algoritm1(p0, n, gamma);
			var steps = algoritm.Process();
			var result = algoritm.Process2(steps);
			Assert.AreEqual(0.00000000000000044408920985006262, result.MaxDelta);
			var expect = new double[8]{ 
				0.0
				, -0.00000000000000011102230246251565
				, -0.00000000000000022204460492503131
				, -0.00000000000000022204460492503131
				, -0.00000000000000022204460492503131
				, -0.00000000000000044408920985006262
				, 0.0
				, 0.0
			};
			CollectionAssert.AreEqual(expect, result.Deltas);
		}
	}
}
