namespace MDLTask.Domain
{
    public interface IMessageRepository
    {
        public Task<int> Add(Message message, bool resultOperation);

        public Task<Domain.Models.MessageResponseGetAll[]> Get();
    }
}
