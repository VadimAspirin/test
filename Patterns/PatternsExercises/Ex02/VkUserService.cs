namespace Patterns.Ex02
{
    public class VkUserService: UserService<VkUser>
    {
        /// <summary>
        /// Нет необходимости менять этот метод, достаточно просто переиспользовать
        /// Реализация его не важна, стоит полагаться только на его внешний интерфейс
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        protected override string GetName(string userId)
        {
            return "NAME";
        }

        /// <summary>
        /// Нет необходимости менять этот метод, достаточно просто переиспользовать
        /// Реализация его не важна, стоит полагаться только на его внешний интерфейс
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        protected override VkUser[] GetFriendsById(string userId)
        {
            return new VkUser[0];
        }

        /// <summary>
        /// Нет необходимости менять этот метод, достаточно просто переиспользовать
        /// Реализация его не важна, стоит полагаться только на его внешний интерфейс
        /// </summary>
        /// <param name="pageUrl"></param>
        /// <returns></returns>
        protected override string Parse(string pageUrl)
        {
            return "USER_ID";
        }


        /// <summary>
        /// Нет необходимости менять этот метод, достаточно просто переиспользовать
        /// Реализация его не важна, стоит полагаться только на его внешний интерфейс
        /// </summary>
        /// <param name="friends"></param>
        /// <returns></returns>
        protected override UserInfo[] ConvertToUserInfo(VkUser[] friends)
        {
            return new UserInfo[0];
        }
    }
}