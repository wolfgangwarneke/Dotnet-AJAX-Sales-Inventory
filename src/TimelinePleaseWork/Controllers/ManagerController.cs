using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using TimelinePleaseWork.Models;
using TimelinePleaseWork.Data;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TimelinePleaseWork.Controllers
{
    public class ManagerController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public ManagerController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EventDetails(int id)
        {
            ViewData["id"] = id;
            ViewData["timeAtLoad"] = DateTime.Now;
            return PartialView();
        }

        public async Task<IActionResult> Inventory()
        {
            var applicationDbContext = _context.InventoryItem.Include(i => i.Item);
            //ViewData["items"] = new Dictionary<string, Item> { };
            //var secondDbContext = _context.Items.Include(i => i.Item);

            return PartialView(await applicationDbContext.ToListAsync());
        }
    }
}
