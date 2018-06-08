using System;
using Patterns.Ex01.ExternalLibs.Twitter;
using Patterns.Ex01.ExternalLibs.Instagram;
using System.Collections.Generic;
using System.Linq;

namespace Patterns.Ex01
{
    public class SubscriberViewer
    {
        public Dictionary<SocialNetwork, ISocialStrategy> IDictionary= new Dictionary<SocialNetwork, ISocialStrategy>();

        public SubscriberViewer(Dictionary<SocialNetwork, ISocialStrategy> dictionary)
        {
            IDictionary = dictionary;
        }
        public SocialNetworkUser[] GetSubscribers(String userName, SocialNetwork networkType)
        {            
            return IDictionary[networkType].GetSubscribers(userName);
        }

        public interface ISocialStrategy
        {
            public SocialNetworkUser[] GetSubscribers(String userName);
        }

        public class TwitterSocialStrategy: ISocialStrategy
        {
            public SocialNetworkUser[] GetSubscribers(String userName)
            {
                var twitterClient = new TwitterClient();
                var userId = twitterClient.GetUserIdByName(userName);
                var twitterUserSubscribers = twitterClient.GetSubscribers(userId);
                var socialNetworkUsers = new List<SocialNetworkUser>();
                foreach(TwitterUser twitterUser in twitterUserSubscribers)
                    socialNetworkUsers.Add(new SocialNetworkUser { UserName = twitterClient.GetUserNameById(twitterUser.UserId) });
                return socialNetworkUsers.ToArray();
            }
        }

        public class InstagramSocialStrategy: ISocialStrategy
        {
            public SocialNetworkUser[] GetSubscribers(String userName)
            {
                var instagramClient = new InstagramClient();
                var instagramUserSubscribers = instagramClient.GetSubscribers(userName);
                var socialNetworkUsers = new List<SocialNetworkUser>();
                foreach (InstagramUser instagramUser in instagramUserSubscribers)
                    socialNetworkUsers.Add(new SocialNetworkUser { UserName = instagramUser.UserName });
                return socialNetworkUsers.ToArray();
            }
        }
     
    }
}