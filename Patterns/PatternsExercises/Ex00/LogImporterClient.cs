namespace Patterns.Ex00.ExternalLibs
{
     public class LogImporterClient
    {
        /// <summary>
        /// TODO: Изменения нужно вносить в этом методе
        /// </summary>
        public void DoMethod()
        {

            var fileLogReader = new FileLogReader();
            var ftpClient = new FtpClient();
            var importer = new FtpClientAdapter(fileLogReader, ftpClient);

            importer.ImportLogs("ftp://log.txt");
            importer.ImportLogs("login", "password", "filePath");
        }
    }
}
