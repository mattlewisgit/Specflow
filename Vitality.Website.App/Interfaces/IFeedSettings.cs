namespace Vitality.Website.App.Interfaces
{
    public interface IFeedSettings
    {
        string MockDataFile { get; set; }
        string Password { get; set; }
        string Url { get; set; }
        string Username { get; set; }
    }
}
