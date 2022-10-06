using CSharpFunctionalExtensions;

namespace MDLTask.Domain
{
    public interface IMessageService
    {
        public Task<Result<bool>> SendAndAddtoDatabase(Message message);

        public Task<Domain.Models.MessageResponseGetAll[]> Get();
    }
}
