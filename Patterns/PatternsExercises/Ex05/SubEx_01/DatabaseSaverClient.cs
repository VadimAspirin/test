using System;
using Patterns.Ex05.ExternalLibs;

namespace Patterns.Ex05.SubEx_01
{
    public class DatabaseSaverClient
    {
        public void Main(bool b)
        {
            IDatabaseSaver databaseSaver = new DatabaseSaver();
            var sender = new MailSender();
            databaseSaver = new MailSenderDecorator(databaseSaver, sender);
            databaseSaver = new MailSenderDecorator(databaseSaver, sender, "jora@ya.ru");
            databaseSaver = new CacheUpdaterDecorator(databaseSaver, new CacheUpdater());

            DoSmth(databaseSaver);
            
        }

        

        private void DoSmth(IDatabaseSaver saver)
        {
            saver.SaveData(null);
        }

    }

    public class DatabaseSaverDecorator : IDatabaseSaver
    {
        protected IDatabaseSaver Wrappee;

        public DatabaseSaverDecorator(IDatabaseSaver saver)
        {
            Wrappee = saver;
        }

        public void SaveData(object data)
        {
           Wrappee.SaveData(data);
        }
    }

    public class MailSenderDecorator : DatabaseSaverDecorator
    {
        private readonly MailSender _mailSender;
        private readonly string _email;
        public MailSenderDecorator(IDatabaseSaver saver, MailSender mailSender, string email = "") : base(saver)
        {
            _mailSender = mailSender;
            _email = email;
        }

        public new void SaveData(object data)
        {
            base.SaveData(data);
            _mailSender.Send(_email);
        }
    }

    public class CacheUpdaterDecorator : DatabaseSaverDecorator
    {
        private readonly CacheUpdater _cacheUpdater;
        public CacheUpdaterDecorator(IDatabaseSaver saver, CacheUpdater cacheUpdater) : base(saver)
        {
            _cacheUpdater = cacheUpdater;
        }

        public new void SaveData(object data)
        {
            base.SaveData(data);
            _cacheUpdater.UpdateCache();
        }
    }

}