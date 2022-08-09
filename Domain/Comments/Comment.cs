using Domain.Common;
using Ardalis.GuardClauses;
using System.ComponentModel.DataAnnotations;

namespace Domain.Comments
{
    public class Comment : Entity
    {

        [Required]
        private string date;
        public string Date { get; set; }

        [Required]
        [MaxLength(300)]
        private string text;
        public string Text
        {
            get { return text; }
            set { text = Guard.Against.NullOrWhiteSpace(value, nameof(text)); }
        }

        public Comment() {}

        public Comment(string date, string text)
        {
            this.date = date;
            this.text = text;
        }
    }
}
