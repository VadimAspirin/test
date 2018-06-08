using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Ex02
{
    public abstract class UserService<T>
    {
        protected abstract UserInfo[] ConvertToUserInfo(T[] user);

        protected abstract string Parse(string pageUrl);

        public UserInfo GetUserInfo(string pageUrl)
        {
            var userId = Parse(pageUrl);
            var users = GetFriendsById(userId);
            return new UserInfo
            {
                Name = GetName(userId),
                UserId = userId,
                Friends = ConvertToUserInfo(users)
            };
        }

        protected abstract T[] GetFriendsById(string userId);

        protected abstract string GetName(string userId);
    }
}
