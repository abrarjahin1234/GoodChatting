using GoodChatting.Data;
using GoodChatting.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GoodChatting.Controllers
{
    [Authorize]
    public class ChatingController : Controller
    {
        private readonly ILogger<ChatingController> logger;
        private readonly UserManager<AppUser> userManager;
        private readonly ApplicationDbContext context;

        public ChatingController(ILogger<ChatingController> logger, UserManager<AppUser> userManager,
            ApplicationDbContext context)
        {
            this.logger = logger;
            this.userManager = userManager;
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var currentUser = await userManager.GetUserAsync(User);
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.currentUserName = currentUser.UserName;
            }

            var messages = await context.Messages.ToListAsync();
            return View();
        }
        public async Task<IActionResult> Create(Message message)
        {
            if (ModelState.IsValid)
            {
                message.UserName = User.Identity.Name;
                var sender = await userManager.GetUserAsync(User);
                message.UserId = sender.Id;
                await context.Messages.AddAsync(message);
                await context.SaveChangesAsync();
                return Ok();
            }

            return View("something went wrong");
        }
    }
}
