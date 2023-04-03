using System.Collections.Generic;

namespace NZHotel.UI.Areas.Management.Models
{
    public class RoleAssignListModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool Exist { get; set; }
    }

    public class RoleAssignSendModel
    {
        public List<RoleAssignListModel> Roles { get; set; }
        public int UserId { get; set; }
    }
}
