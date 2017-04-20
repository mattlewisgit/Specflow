using RestSharp;
using RestSharp.Deserializers;

namespace Vitality.Website.App.Helpers
{
    public interface IMockDataHelper
    {
        T GetMockData<T>(IDeserializer deserializer, string filePath);
        T GetMockData<T>(string contentType, string fileUrl) where T : new();
    }
}
