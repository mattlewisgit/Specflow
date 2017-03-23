using RestSharp.Deserializers;

namespace Vitality.Website.App.Helpers
{
    public interface IMockDataHelper
    {
        T GetMockData<T>(IDeserializer deserializer, string filePath);
    }
}
