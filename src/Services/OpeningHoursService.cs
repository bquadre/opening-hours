using System;
using System.Collections.Generic;
using System.Linq;
using OpeningHours.API.Models;

namespace OpeningHours.API.Services
{
    public class OpeningHoursService : IOpeningHoursService
    {
        public Response ProcessRequest(DayOfWeekInputDto inputDto)
        {
            try
            {
                var monday = ComputeForDay(inputDto.Monday);
                var tuesday = ComputeForDay(inputDto.Tuesday);
                var wednesday = ComputeForDay(inputDto.Wednesday);
                var thurday = ComputeForDay(inputDto.Thursday);
                var friday = ComputeForDay(inputDto.Friday);
                var saturday = ComputeForDay(inputDto.Saturday);
                var sunday = ComputeForDay(inputDto.Sunday);

                var data = new List<string>();
                data.Add($"Monday: {monday}");
                data.Add($"Tuesday: {tuesday}");
                data.Add($"Wednesday: {wednesday}");
                data.Add($"Thurday: {thurday}");
                data.Add($"Friday: {friday}");
                data.Add($"Saturday: {saturday}");
                data.Add($"Sunday: {sunday}");

                return new Response
                {
                    IsSuccess = true,
                    Message = "Data retrieve successfully",
                    Data = data
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string ComputeForDay(List<OpeningHoursInputDto> openingHours)
        {
           var hours = string.Empty;
            var dateTime = DateTime.Now;
            var time = string.Empty;

            if (openingHours.Count == 0)
            {
                hours += "closed";
            }

            foreach (var item in openingHours)
            {
              
                if(item.Type.ToLower() == "open")
                {
                    dateTime = UnixTimeToDateTime(item.Value);

                    time = dateTime.ToShortTimeString();

                    hours += time;
                }
                else
                {
                    dateTime = UnixTimeToDateTime(item.Value);

                    time = dateTime.ToShortTimeString();

                    if(openingHours[0] == item)
                    {
                        hours += $"{time},";
                    }
                    else
                    {
                        hours += $" - {time},";
                    }

                }
               
            }

            return hours;
        }

        private DateTime UnixTimeToDateTime(long unixtime)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddMilliseconds(unixtime).ToLocalTime();
            return dtDateTime;
        }
    }
}
