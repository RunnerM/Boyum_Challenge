using Boyum_Challenge.Model;

namespace Boyum_Challenge.Data
{
    public interface IDataService
    {
        public WebOrder GetOrder();
        public void ReadOrderFromXml(string filename);

    }
}