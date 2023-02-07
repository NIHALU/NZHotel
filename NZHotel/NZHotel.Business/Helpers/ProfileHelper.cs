using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NZHotel.Business.Mappings.AutoMapper;

namespace NZHotel.Business.Helpers
{
    public static class ProfileHelper
    {
        public static List<Profile> GetProfiles()
        {
            return new List<Profile> {
                new RoomProfile(),
                new RoomStatusProfile(),
                new RoomTypeProfile()
            };
        }
    }
}
