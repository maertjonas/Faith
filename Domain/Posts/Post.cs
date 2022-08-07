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

        [Required]
        [MaxLength(300)]
        private string text;
        public string Text
        {
            get { return text; }
            set { text = Guard.Against.NullOrWhiteSpace(value, nameof(text)); }
        }

        [Required]
        private DateTime date;
        public DateTime Date { get; set; }

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

        public Post(string text, DateTime date)
        {
            this.Text = text;
            this.Date = date;
        }
    }
}