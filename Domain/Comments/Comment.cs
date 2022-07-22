using Domain.Common;
using Ardalis.GuardClauses;

namespace Domain.Comments
{
    public class Comment : Entity
    {
        private DateTime date;
        public DateTime Date { get; set; }

        private string text;
        public string Text
        {
            get { return text; }
            set { text = Guard.Against.NullOrWhiteSpace(value, nameof(text)); }
        }

    }
}
