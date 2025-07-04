﻿using VCS.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace VCS.Entities {
    public class Country {
        [Key]
        public int Id { get; set; }

        public string CountryName { get; set; }

        public virtual ICollection<Missions> Missions { get; set; } = [];
    }
}
