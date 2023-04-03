using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using NZHotel.DataAccess.Entities;

namespace NZHotel.UI.TagHelpers
{
    [HtmlTargetElement("getUserInfo")]
    public class GetUserInfo:TagHelper
    {
        public int UserId { get; set; }
        private readonly UserManager<AppUser> _userManager;

        public GetUserInfo(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output) //usermamanger içindeki tüm methodlar async oldugu için process methodunuda async olarak seçtik 
        {
            var html = "";

            var user = await _userManager.Users.SingleOrDefaultAsync(x => x.Id == UserId);
            var roles = await _userManager.GetRolesAsync(user);  //bu method string bir dizi döner IList
            foreach (var item in roles)
            {
                html += item + " ";
            }
            output.Content.SetHtmlContent(html);
        }
    }
}
