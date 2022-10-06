using CSharpFunctionalExtensions;

namespace MDLTask.Domain
{
    public record Message
    {

        public const int MaxMessageSubject = 30;

        public int Id { get; init; }

        public string Subject { get; init; }

        public string Body { get; init; }

        public string[] Recipients { get; init; }

        private Message(int id, string subject, string body, string[] recipients)
        {
            Id = id;
            Subject = subject;
            Body = body;
            Recipients = recipients;
        }

        public static Result<Message> Create(string subject, string body, string[] recipients)
        {
            if (string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(body) || recipients == null)
            {
                return Result.Failure<Message>("Field cannot be null or whitespace");
            }

            if (subject.Length > MaxMessageSubject)
            {
                return Result.Failure<Message>($"Name cannot have more than {MaxMessageSubject} char");
            }

            return new Message(0, subject, body, recipients);
        }
    }
}