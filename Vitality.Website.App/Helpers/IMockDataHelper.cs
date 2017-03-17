namespace Vitality.Website.App.Helpers
{
    public interface IMockDataHelper
    {
        T GetJsonMockData<T>(string filePath);
        T GetXmlMockData<T>(string filePath);
    }
}
