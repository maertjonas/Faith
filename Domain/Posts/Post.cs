using System;
using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;

namespace Domain.Posts
{
    public class Post
    {
        private bool pinned;
        public bool Pinned { get; set; }

        private bool archive;
        public bool Archive { get; set; }

        private string text;
        public string Text
        {
            get { return text; }
            set { text = Guard.Against.NullOrWhiteSpace(value, nameof(text)); }
        }

        private DateTime date;
        public DateTime Date { get; set; }
        
        private string image;
        public string Image { get; set; }

    }
}
