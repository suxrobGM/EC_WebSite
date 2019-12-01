﻿using System;
using System.Collections.Generic;
using SuxrobGM.Sdk.Utils;

namespace EC_Website.Models.ForumModel
{
    public class Board
    {
        public Board()
        {
            Id = GeneratorId.GenerateLong();
            Threads = new List<Thread>();
            Timestamp = DateTime.Now;
        }

        public string Id { get; set; }       
        public string Title { get; set; }
        public string Slug { get; set; }
        public DateTime Timestamp { get; set; }
        public string ForumId { get; set; }
        public virtual ForumHead Forum { get; set; }

        public virtual ICollection<Thread> Threads { get; set; }
    }
}
