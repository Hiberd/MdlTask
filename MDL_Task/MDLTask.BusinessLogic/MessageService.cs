using MDLTask.Domain;
using AutoMapper;
using CSharpFunctionalExtensions;

namespace MDLTask.BusinessLogic
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly ISmtpService _smtpService;

        public MessageService(IMessageRepository messageRepository, ISmtpService smtpService)
        {
            _messageRepository = messageRepository;
            _smtpService = smtpService;
        }

        public async Task<Result<bool>> SendAndAddtoDatabase(Message message)
        {
            var resultOperation = await _smtpService.SendEmail(message.Recipients, message.Subject, message.Body);

            if (resultOperation.IsFailure)
            {
                await _messageRepository.Add(message, false);

                return resultOperation;
            }

            int id = await _messageRepository.Add(message, true);

            return resultOperation;
        }

        public async Task<Domain.Models.MessageResponseGetAll[]> Get()
        {
            return await _messageRepository.Get();
        }

    }
}
