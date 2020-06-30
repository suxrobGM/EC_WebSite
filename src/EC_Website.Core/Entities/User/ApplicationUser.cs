﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using EC_Website.Core.Entities.Blog;
using EC_Website.Core.Entities.Forum;
using EC_Website.Core.Entities.Wikipedia;
using EC_Website.Core.Interfaces;
using SuxrobGM.Sdk.Utils;

namespace EC_Website.Core.Entities.User
{
    public class ApplicationUser : IdentityUser, IEntity<string>
    {
        public ApplicationUser()
        {
            Id = GeneratorId.GenerateComplex();
            Timestamp = DateTime.Now;
        }

        [StringLength(32)]
        public override string Id { get; set; }

        [StringLength(80, ErrorMessage = "Characters must be less than 80")]
        public string FirstName { get; set; }

        [StringLength(80, ErrorMessage = "Characters must be less than 80")]
        public string LastName { get; set; }

        [StringLength(128, ErrorMessage = "Characters must be less than 128")]
        public string Status { get; set; }

        [StringLength(4096, ErrorMessage = "Characters must be less than 4096")]
        public string Bio { get; set; }           
        public bool IsBanned { get; set; }
        public DateTime? BanExpirationDate { get; set; }
        public DateTime Timestamp { get; set; }

        [StringLength(64)]
        public string ProfilePhotoPath { get; set; }

        [StringLength(64)]
        public string HeaderPhotoPath { get; set; }
        public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
        public virtual ICollection<Thread> Threads { get; set; } = new List<Thread>();
        public virtual ICollection<UserBadge> UserBadges { get; set; } = new List<UserBadge>();
        public virtual ICollection<FavoriteThread> FavoriteThreads { get; set; } = new List<FavoriteThread>();
        public virtual ICollection<BlogEntry> BlogEntries { get; set; } = new List<BlogEntry>();
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public virtual ICollection<WikiEntry> WikiEntries { get; set; } = new List<WikiEntry>();

        public override string ToString() => UserName;
    }
}