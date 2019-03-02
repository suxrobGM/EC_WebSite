﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EC_WebSite.Models.ForumModel
{
    public class ForumHead
    {
        public ForumHead()
        {
            Id = GeneratorId.Generate();
            Boards = new List<Board>();
        }
       
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Board> Boards { get; set; }
    }
}
