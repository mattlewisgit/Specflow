using System;

namespace Vitality.Website.Handlers
{
    using System.Collections.Generic;
    using System.Linq;

    using MediatR;

    using RestSharp;

    using Vitality.Website.Models;

    public class BlogRequestHandler : IRequestHandler<BlogPostRequest, IEnumerable<BlogPost>>
    {
        private readonly IRestClient restClient;

        public BlogRequestHandler(IRestClient restClient)
        {
            this.restClient = restClient;
        }

        public IEnumerable<BlogPost> Handle(BlogPostRequest message)
        {
            try
            {
                this.restClient.BaseUrl = new Uri(message.Url);

                var request = new RestRequest();
                request.AddQueryParameter("paras", message.NumberOfPosts.ToString());
                foreach (var parameter in message.QueryStringParameters)
                {
                    request.AddQueryParameter(parameter.Key, parameter.Value);
                }

                return (this.restClient.Get<List<string>>(request).Data ?? new List<string>()).Select(text => new BlogPost {Text = text}).ToList();
            }
            catch (UriFormatException ex)
            {
                throw new ArgumentException("Blog url is incorrect", "message", ex);
            }
        }
    }

    public class BlogPostRequest : IRequest<IEnumerable<BlogPost>>
    {
        public string Url { get; set; }
        public int NumberOfPosts { get; set; }
        public IDictionary<string, string> QueryStringParameters { get; set; }
    }
}