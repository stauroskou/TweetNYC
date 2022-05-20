using System;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;

namespace TweetNYC
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var userCredentials = new TwitterCredentials("CONSUMER_KEY", "CONSUMER_SECRET", "ACCESS_TOKEN", "ACCESS_TOKEN_SECRET");
            var userClient = new TwitterClient(userCredentials);

            var stream = userClient.Streams.CreateFilteredStream();
            stream.AddTrack("java");

            stream.MatchingTweetReceived += (sender, eventReceived) =>
            {
                Console.WriteLine(eventReceived.Tweet);
            };

            await stream.StartMatchingAnyConditionAsync();

        }
    }
}
