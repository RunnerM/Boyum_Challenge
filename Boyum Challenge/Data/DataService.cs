using Boyum_Challenge.Model;

namespace Boyum_Challenge.Data
{
    public class DataService : IDataService
    {
        private WebOrder Order { get; set; }
        private readonly WebOrderXmlDeserializer _deserializer;

        public DataService()
        {
            _deserializer = new WebOrderXmlDeserializer();
        }

        public WebOrder GetOrder()
        {
            if (Order == null)
            {
                Order = new WebOrder();
            }
            return Order;
        }

        public void ReadOrderFromXml(string filename)
        {
            Order = _deserializer.ProcessFile(filename);
        }
    }
}