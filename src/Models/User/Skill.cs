﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SuxrobGM.Sdk.Utils;

// ReSharper disable once CheckNamespace
namespace EC_Website.Models.UserModel
{
    public class Skill
    {
        public Skill()
        {
            Id = GeneratorId.GenerateLong();
            Timestamp = DateTime.Now;
        }

        [StringLength(32)]
        public string Id { get; set; }

        [Required(ErrorMessage = "Please enter the skill name")]
        [StringLength(80, ErrorMessage = "Characters must be less than 80")]
        public string Name { get; set; }
        public DateTime Timestamp { get; set; }

        public virtual ICollection<UserSkill> UserSkills { get; set; } = new List<UserSkill>();
    }
}
