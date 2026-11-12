using Mfc.Health.Corner.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mfc.Health.Corner.Domain.DITModels;
using Mfc.Health.Corner.Common.Extension;

namespace Mfc.Health.Corner.Persistence.Data
{
    public static class DITModelExtantions
    {
        public static User ToMfcCornerUser(this DblkIuser dblkIuser)
        {
            var user = new User
            {
                FullName = dblkIuser.Name,
                Phone = "",
                Login = dblkIuser.Login,
                Email = dblkIuser.Email,
                IsDeleted = false,
                Blocked = false,
                Active = false,
                CreatedAt = dblkIuser.Cdate
            };
            return user;
        }

        public static MfcCorner ToMfcCorner(this DblkComplex complex, List<District> districts)
        {
            string basePath = $"{complex.Name.Trim().Replace(" ", "_").CyrilicToLatin().ToLower()}-wss-proxy.mfchealth.ru";

            MfcCorner corner = new MfcCorner
            {
                Name = complex.Name,
                EquipmentCondition = new EquipmentCondition
                {
                    Analyzer = false,
                    Bpbio = false,
                    Bsm = false,
                    Gaz = false,
                    Pulse = false
                },
                TelegtamChatId = "",
                Address = complex.Address,
                Latitude = complex.Latitude,
                Longitude = complex.Longitude,
                CreatedAt = complex.Cdate,
                DistrictId = districts.FirstOrDefault(x => x.Name == complex.Area.Trim())?.Id ?? "",
                Ip = basePath,
                Group = basePath,
                Port = "8380"
            };
            return corner;
        }
    }
}
