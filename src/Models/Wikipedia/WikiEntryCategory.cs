﻿using System.ComponentModel.DataAnnotations;

namespace EC_Website.Models.Wikipedia
{
    public class WikiEntryCategory
    {
        [StringLength(32)]
        public string WikiEntryId { get; set; }
        public virtual WikiEntry Entry { get; set; }

        [StringLength(32)]
        public string CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
