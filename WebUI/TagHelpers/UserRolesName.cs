using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.TagHelpers
{
    [HtmlTargetElement("td",Attributes = "user-roles")]
    public class UserRolesName:TagHelper
    {
        public UserManager<User> _userManager;
        public UserRolesName(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        [HtmlAttributeName("user-roles")]
        public string UserId { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            User user = await _userManager.FindByIdAsync(UserId);
            IList<string> roles= await _userManager.GetRolesAsync(user);
            string html = string.Empty;
            roles.ToList().ForEach(x =>
            {
                html += $"<span class='badge badge-info'>{x}</span>";
            });
            output.Content.SetHtmlContent(html);
        }
    }
}
