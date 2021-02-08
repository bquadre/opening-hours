using System;
using OpeningHours.API.Models;

namespace OpeningHours.API.Services
{
    public interface IOpeningHoursService
    {
        Response ProcessRequest(DayOfWeekInputDto inputDto);
    }
}
