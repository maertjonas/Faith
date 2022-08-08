using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using Ardalis.GuardClauses;
using Domain.Comments;
using Domain.Common;

namespace Domain.Posts
{
    public class Post : Entity
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

        private string date;
        public string Date { get; set; }

        private string image;
        public string Image { get; set; }

        [JsonIgnore]
        private IEnumerable<Comment> comments;
        public IEnumerable<Comment> Comments
        {
            get { return comments; }
            set
            {
                comments = Guard.Against.NullOrEmpty(value, nameof(comments));
            }
        }

        public Post() { }

        public Post(string text, String date)
        {
            this.Text = text;
            this.Date = date;
        }

        public Post(string text, string date, bool archive, bool pinned, string image, List<Comment> comments) : this(text, date)
        {
            this.Archive = archive;
            this.Pinned = pinned;
            this.Image = image;
            this.Comments = comments;
        }
    }
}