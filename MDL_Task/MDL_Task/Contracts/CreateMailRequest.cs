using MDLTask.Domain;
using System.ComponentModel.DataAnnotations;

namespace MDLTask.Api.Contracts
{
    /// <summary>
    /// Contract for creating email message.
    /// </summary>
    public class CreateMailRequest
    {
        [MaxLength(Message.MaxMessageSubject)]
        [Required]
        public string Subject { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        public string[] Recipients { get; set; }
    }
}
