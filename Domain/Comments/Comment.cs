using Domain.Common;
using Ardalis.GuardClauses;
using System.ComponentModel.DataAnnotations;

namespace Domain.Comments
{
    public class Comment : Entity
    {

        [Required]
        private String date;
        public String Date { get; set; }

        [Required]
        [MaxLength(300)]
        private string text;
        public string Text
        {
            get { return text; }
            set { text = Guard.Against.NullOrWhiteSpace(value, nameof(text)); }
        }

    }
}
