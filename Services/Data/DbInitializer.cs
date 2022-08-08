﻿using Domain.Comments;
using Domain.Posts;
using Domain.Users;

namespace Services.Data
{
    public  class DbInitializer
    {
        private readonly ApplicationContext _context;


        public DbInitializer(ApplicationContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            _context.Database.EnsureDeleted();
            if (_context.Database.EnsureCreated())
            {
                Seeder();
            }
        }
        public void Seeder()
        {

            Random rand = new Random();
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            var lorem = new Bogus.DataSets.Lorem(locale: "nl");
            int rangeLorem = rand.Next(2, 4);

            //Comments
            String now = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            var comment1 = new Comment { Date = now, Text = lorem.Paragraphs(rangeLorem-1) };
            var comment2 = new Comment { Date = now, Text = lorem.Paragraphs(rangeLorem-1) };
            var comment3 = new Comment { Date = now, Text = lorem.Paragraphs(rangeLorem-1) };
            var comment4 = new Comment { Date = now, Text = lorem.Paragraphs(rangeLorem-1) };
            var comment5 = new Comment { Date = now, Text = lorem.Paragraphs(rangeLorem-1) };
            var comment6 = new Comment { Date = now, Text = lorem.Paragraphs(rangeLorem-1) };
            var comment7 = new Comment { Date = now, Text = lorem.Paragraphs(rangeLorem-1) };

            //Posts
            var posts = new Post[]
            {
                new Post
                {
                    Text = lorem.Paragraph(5),
                    Date = now,
                    Image = "",
                    Comments = new List<Comment> { comment1, comment2 }
                },
                new Post
                {
                    Text = lorem.Paragraph(3),
                    Date = now,
                    Image = "",
                    Comments = new List<Comment> { comment3, comment4, comment5 }
                },
                new Post
                {
                    Text = lorem.Paragraph(4),
                    Date = now,
                    Image = "",
                    Comments = new List<Comment> { comment6, comment7 }
                },

            };


            //Users
            var users = new User[]
            {
                new User
                {
                    FirstName = "Mark",
                    LastName = "Vanhove",
                    Email = "Mark.Vanhove@gmail.com",
                    Password = "Testje123",
                    DateOfBirth = DateTime.Now.AddYears(-60).ToString("yyyyMMddHHmmssffff"),
                    RoleType = Faith.Shared.RoleTypes.RoleType.Mentor,
                    Gender = Faith.Shared.Gender.Gender.Male
                },
                new User
                {
                    FirstName = "Nathan",
                    LastName = "Vanloppem",
                    Email = "Nathan.Vanloppem@gmail.com",
                    Password = "Testje123",
                    DateOfBirth = DateTime.Now.AddYears(-15).ToString("yyyyMMddHHmmssffff"),
                    RoleType = Faith.Shared.RoleTypes.RoleType.Junior,
                    Gender = Faith.Shared.Gender.Gender.Male
                },
                new User
                {
                    FirstName = "Cynthia",
                    LastName = "Deboosere",
                    Email = "Cynthia.Deboosere@gmail.com",
                    Password = "Testje123",
                    DateOfBirth = DateTime.Now.AddYears(-13).ToString("yyyyMMddHHmmssffff"),
                    RoleType = Faith.Shared.RoleTypes.RoleType.Junior,
                    Gender = Faith.Shared.Gender.Gender.Female
                },
                new User
                {
                    FirstName = "Tim",
                    LastName = "Dubois",
                    Email = "Tim.Dubois@gmail.com",
                    Password = "Testje123",
                    DateOfBirth = DateTime.Now.AddYears(-14).ToString("yyyyMMddHHmmssffff"),
                    RoleType = Faith.Shared.RoleTypes.RoleType.Junior,
                    Gender = Faith.Shared.Gender.Gender.Other
                },
            };


            _context.Posts.AddRange(posts);
            _context.Users.AddRange(users);
            _context.SaveChanges();
        }
    }
}
