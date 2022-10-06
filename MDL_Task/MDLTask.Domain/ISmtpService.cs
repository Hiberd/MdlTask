using CSharpFunctionalExtensions;

namespace MDLTask.Domain
{
    public interface ISmtpService
    {
        public Task<Result<bool>> SendEmail(string[] recipients, string subject, string body);
    }
}
