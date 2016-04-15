namespace NextBuildHangfireDemo.Services
{
    using System;
    using System.IO;
    using System.Net.Mail;
    using Hangfire;
    using Hangfire.Server;

    public class TempfileCleanupService : IBackgroundProcess
    {
        public void Execute(BackgroundProcessContext context)
        {
            var directory = new SmtpClient().PickupDirectoryLocation;

            foreach (var file in Directory.GetFiles(directory))
            {
                BackgroundJob.Enqueue(() => CleanUpEmail(file));
            }

            context.Wait(TimeSpan.FromMinutes(1));
        }

        public void CleanUpEmail(string file)
        {
            File.Delete(file);
        }

    }
}