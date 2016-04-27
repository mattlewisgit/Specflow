namespace Vitality.Website.Extensions
{
    using Vitality.Website.Handlers;
    using Vitality.Website.Models;

    public static class IRequestExtensions
    {
        public static BlogPostRequest ToRequest(this BlogPage blogPage)
        {
            return new BlogPostRequest
                   {
                       Url = blogPage.BlogUrl.Url,
                       NumberOfPosts = blogPage.NumberOfPosts,
                       QueryStringParameters = blogPage.QueryString
                   };
        }
    }
}