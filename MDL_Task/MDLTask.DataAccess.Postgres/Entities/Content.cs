using System.ComponentModel.DataAnnotations.Schema;

namespace MDLTask.DataAccess.Entities
{
    public class Content
    {
        private static readonly char delimiter = ';';

        public int id { get; set; }

        public string subject { get; set; }

        public string body { get; set; }

        public DateTime Date { get; set; }

        public string Result { get; set; } = "Failed";

        public string? FailedMessage { get; set; }

        public string RecipientsString { get; set; }

        [NotMapped]
        public string[] Recipients
        {
            get
            {
                return RecipientsString.Split(delimiter);
            }

            set
            {
                RecipientsString = string.Join($"{delimiter}", value);
            }
        }
    }
}
