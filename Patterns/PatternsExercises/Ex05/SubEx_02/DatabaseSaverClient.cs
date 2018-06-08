using System;
using Patterns.Ex05.ExternalLibs;

namespace Patterns.Ex05.SubEx_02
{
    public class DatabaseSaverClient
    {
        public void Main(bool b)
        {
      
            var databaseSaver = new DatabaseSaverProxy(new DatabaseSaver());
            databaseSaver.DataSaved += (sender, args) =>
            {
                var mailSender = new MailSender(); 
                var cacheUpdated = new CacheUpdater();
                mailSender.Send("email");
                cacheUpdated.UpdateCache();               
            };
            DoSmth(databaseSaver);
        }

        private void DoSmth(IDatabaseSaver saver)
        {
            saver.SaveData(null);
        }
    }




    public class DatabaseSaverProxy : IDatabaseSaver
    {

        public event EventHandler DataSaved;

        protected virtual void OnDataSaved()
        {
            DataSaved?.Invoke(this, EventArgs.Empty);
        }

        private readonly IDatabaseSaver _databaseSaver;

        public DatabaseSaverProxy(IDatabaseSaver databaseSaver)
        {
            _databaseSaver = databaseSaver;
        }

        public void SaveData(object data)
        {
            _databaseSaver.SaveData(data);
            OnDataSaved();
        }
    }





}