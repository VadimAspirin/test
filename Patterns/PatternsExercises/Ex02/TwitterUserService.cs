using System;
using System.Linq;
using System.Text.RegularExpressions;
using Patterns.Ex01.ExternalLibs.Twitter;

namespace Patterns.Ex02
{
    public class TwitterUserService : UserService<TwitterUser>
    {
        readonly TwitterClient _client = new TwitterClient();

        protected override UserInfo[] ConvertToUserInfo(TwitterUser[] user)
        {
            return user.Select(c =>
            {
                var userInfo = new UserInfo
                {
                    UserId = c.UserId.ToString(),
                    Name = _client.GetUserNameById(c.UserId)
                };
                return userInfo;
            }).ToArray();
        }

        protected override string Parse(string pageUrl)
        {
            var regex = new Regex("twitter.com/(.*)");
            var userName = regex.Match(pageUrl).Groups[0].Value;
            return GetUserId(userName).ToString();
        }


        protected override TwitterUser[] GetFriendsById(string userId)
        {
            return _client.GetSubscribers(Convert.ToInt64(userId)).ToArray();
        }

        protected override string GetName(string userId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Нет необходимости менять этот метод, достаточно просто переиспользовать
        /// Реализация его не важна, стоит полагаться только на его внешний интерфейс
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        private long GetUserId(String userName)
        {
            //TODO: Return userId from userName
            return 0;
        }
    }
}