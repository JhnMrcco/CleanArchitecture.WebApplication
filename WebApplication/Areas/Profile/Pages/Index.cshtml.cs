using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Persistence.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication.Areas.Profile.Pages
{
    public class IndexModel : PageModel
    {
        public string Username { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] ProfilePicture { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }
        private readonly UserManager<ApplicationUser> _userManager;
        public IndexModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task OnPostViewProfileAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            Username = user.UserName;
            ProfilePicture = user.ProfilePicture;
            FirstName = user.FirstName;
            LastName = user.LastName;
        }
    }
}
