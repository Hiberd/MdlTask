namespace MDLTask.Domain.Models
{
    public class MessageResponseGetAll
    {
        public int id { get; set; }

        public string subject { get; set; }

        public string body { get; set; }

        public DateTime Date { get; set; }

        public string Result { get; set; }

        public string RecipientsString { get; set; }
    }
}
