﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.WeekTallyDtos
{
    public class WeekTallyRebuildDto
    {
        public int WeekDate { get; set; }
        public int WeekNumber { get; set; }
        public DateTime FirstDate { get; set; }
        public DateTime FinishDate { get; set; }
        public Guid StudentGuidId { get; set; }

    }
}
