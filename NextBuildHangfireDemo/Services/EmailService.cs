namespace NextBuildHangfireDemo.Services
{
    using System.IO;
    using System.Web.Hosting;
    using System.Web.Mvc;
    using Models;
    using Postal;

    public class EmailService
    {
        public void NotifyNewComment(int commentId)
        {
            // Prepare Postal classes to work outside of ASP.NET request
            var viewsPath = Path.GetFullPath(HostingEnvironment.MapPath(@"~/Views/Emails"));
            var engines = new ViewEngineCollection();
            engines.Add(new FileSystemRazorViewEngine(viewsPath));

            // Get comment and send a notification.
            using (var db = new MailerDbContext())
            {
                var comment = db.Comments.Find(commentId);

                var email = new NewCommentEmail
                {
                    To = "yourmail@example.com",
                    UserName = comment.UserName,
                    Comment = comment.Text
                };

                email.Send();
            }
        }
    }
}