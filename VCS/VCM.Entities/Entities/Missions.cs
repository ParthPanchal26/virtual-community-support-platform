﻿using VCS.Entities;
using VCS.Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VCS.Entities;
using VCS.Entities.Entities;

namespace VCS.Entities {
    public class Missions : BaseEntity // Assuming BaseEntity defines common properties
    {
        [Key]
        public int Id { get; set; }

        public string MissionTitle { get; set; }

        public string MissionDescription { get; set; }

        public int CountryId { get; set; }

        public int CityId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int? TotalSheets { get; set; }

        public DateTime? RegistrationDeadLine { get; set; }

        public int MissionThemeId { get; set; }

        public string MissionSkillId { get; set; }

        public string MissionImages { get; set; }


        [ForeignKey(nameof(CountryId))]
        public virtual Country Country { get; set; } = null!;

        [ForeignKey(nameof(CityId))]
        public virtual City City { get; set; } = null!;

        [ForeignKey(nameof(MissionThemeId))]
        public virtual MissionTheme MissionTheme { get; set; } = null!;

        public virtual ICollection<MissionApplication> MissionApplications { get; set; } = [];


    }
}
