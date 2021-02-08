using System;
using System.Collections.Generic;

namespace OpeningHours.API.Models
{
    public class DayOfWeekInputDto
    {
        public List<OpeningHoursInputDto> Monday { get; set; }
        public List<OpeningHoursInputDto> Tuesday { get; set; }
        public List<OpeningHoursInputDto> Wednesday { get; set; }
        public List<OpeningHoursInputDto> Thursday { get; set; }
        public List<OpeningHoursInputDto> Friday { get; set; }
        public List<OpeningHoursInputDto> Saturday { get; set; }
        public List<OpeningHoursInputDto> Sunday { get; set; }
    }
}
