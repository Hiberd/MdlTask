using AutoMapper;
using MDLTask.Domain;
using Microsoft.EntityFrameworkCore;

namespace MDLTask.DataAccess
{
    public class MessageRepository : IMessageRepository
    {
        private readonly MdlTaskDbContext _dbContext;
        private readonly IMapper _mapper;

        public MessageRepository(MdlTaskDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<int> Add(Message message, bool resultOperation)
        {
            var content = _mapper.Map<Domain.Message, Entities.Content>(message);

            content.Date = DateTime.Now;

            if (resultOperation)
            {
                content.Result = "Ok";
            }

            await _dbContext.AddRangeAsync(content);

            await _dbContext.SaveChangesAsync();

            return content.id;
        }

        public async Task<Domain.Models.MessageResponseGetAll[]> Get()
        {
            var messages = await _dbContext.Contents
                .AsNoTracking()
                .ToArrayAsync();

            return _mapper.Map<Entities.Content[], Domain.Models.MessageResponseGetAll[]>(messages);
        }
    }
}
