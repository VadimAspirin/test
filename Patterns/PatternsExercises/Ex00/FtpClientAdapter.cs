using Patterns.Ex00.ExternalLibs;

namespace Patterns.Ex00
{

    public class FtpClientAdapter : LogImporter
    {
        private readonly FtpClient _ftpClient;
        public FtpClientAdapter(ILogReader reader, FtpClient ftpClient) : base(reader)
        {
            _ftpClient = ftpClient;
        }
        public void ImportLogs(string login, string password, string filePath)
        {
            var file = _ftpClient.ReadFile(login, password, filePath);
            // Do smth
        }

    }
}