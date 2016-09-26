using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Specialized;
using RestSharp.Extensions.MonoHttp;

namespace TwitterAPITestProject.Models
{
    public class Tweet
    {
        public string Author { get; set; }
        public string Body { get; set; }
        public string ImageURL { get; set; }
        public static void GetTweets()
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("https://api.twitter.com/1.1/");
            client.Authenticator = new HttpBasicAuthenticator();
            var request = new RestRequest();
            request.Resource = "statuses/user_timeline.json?screen_name=twitterapi&count=2";

            client.ExecuteAsync(request, response =>
            {
                Console.WriteLine("This is the response" + response.Content);
            });

            //var client = new RestClient("https://api.twitter.com")
            //{
            //    Authenticator = OAuth1Authenticator.ForRequestToken(EnvVariables.ApiKey, EnvVariables.ApiSecret)
            //};
            //var oauthRequest = new RestRequest("oauth/request_token", Method.POST);
            //client.ExecuteAsync(oauthRequest, response =>
            //{
            //    Console.WriteLine("this is the oauth response " + response.Content);
            //    NameValueCollection qs = HttpUtility.ParseQueryString(response.Content);
            //    _oauthToken = qs["oauth_token"];
            //    _oauthTokenSecret = qs["oauth_token_secret"];

            //    client.Authenticator = OAuth1Authenticator.ForProtectedResource(EnvVariables.ApiKey, EnvVariables.ApiSecret, _oauthToken, _oauthTokenSecret);

            //    var request = new RestRequest("oauth/acces_token", Method.POST);
            //    client.Authenticator = OAuth1Authenticator.ForAccessToken(EnvVariables.ApiKey, EnvVariables.ApiSecret, _oauthToken, _oauthTokenSecret, verifier);

            //    client.ExecuteAsync(request, response2 =>
            //    {
            //        Console.WriteLine("This is the response" + response2.Content);
            //        returnString = response2.Content;
            //        Console.WriteLine(returnString);
            //    });

            //});
            //return returnString;

               

        }
        public static Task<IRestResponse> GetResponseContentAsync(RestClient client, RestRequest request)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            client.ExecuteAsync(request, response =>
            {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}