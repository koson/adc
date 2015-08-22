using adc.core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace adc.tests
{
	[TestClass]
	public class AlgoritmTest
	{
		[TestMethod]
		public void GetIdealCharacteristicTest()
		{
			var a = new Algoritm(1, 2);
			var result = a.GetIdealCharacteristic();
			CollectionAssert.AreEqual(new[] { 0, 1, 0.5, 1.5 }, result);
		}

		[TestMethod]
		public void TestGetErrors()
		{
			var a = new Algoritm(64, 8);
			var result = a.GetErrors();
			Assert.IsTrue(result.All(r => r > -4));
			Assert.IsTrue(result.All(r => r < 4));
		}

		[TestMethod]
		public void GetRealCharacteristicTest()
		{
			var a = new Algoritm(1, 2);
			var errors = a.GetErrors();
			var result = a.GetRealCharacteristic(errors);
			Assert.IsNotNull(result);
			Assert.AreEqual(4, result.Length);


		}
	}
}
