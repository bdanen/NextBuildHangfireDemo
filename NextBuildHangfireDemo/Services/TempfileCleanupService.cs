namespace NextBuildHangfireDemo.Services
{
    using System.IO;
    using System.Net.Mail;

    public class TempfileCleanupService
    {
        public void CleanUpEmails()
        {
            var directory = new SmtpClient().PickupDirectoryLocation;

            foreach (var file in Directory.GetFiles(directory))
            {
                File.Delete(file);
            }
        }
    }
}