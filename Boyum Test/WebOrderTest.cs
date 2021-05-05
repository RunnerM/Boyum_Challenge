using Boyum_Test.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Boyum_Test
{
    [TestClass]
    public class WebOrderTest
    {
        private WebOrder _order = new WebOrder();
        private WebOrderXmlDeserializer _des = new WebOrderXmlDeserializer();
        [TestInitialize]
        public void Init()
        {
            _order = _des.ProcessFile("C:/Users/pente/Downloads/Boyum IT Code Challenge/InputFile.xml");
        }

        [TestCleanup]
        public void Cleanup()
        {
            _order = null;
        }
        
        [TestMethod]
        public void Average()
        {
            double res = _order.AveragePrice();
            Assert.IsTrue(
                res == 462.210
            );
        }
        [TestMethod]
        public void Sum()
        {
            double res = _order.TotalPrice();
            Assert.IsTrue(
                res == 3039.920
                );
        }
        
    }
}