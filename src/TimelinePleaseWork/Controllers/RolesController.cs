using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using TimelinePleaseWork.Models;
using TimelinePleaseWork.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Security.Claims;
using TimelinePleaseWork.Data;
using Microsoft.AspNetCore.Authorization;

namespace TimelinePleaseWork.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class RolesController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
        }

        public IActionResult Index()
        {
            var roles = _db.Roles;
            return View(_db.Roles);
        }

        public IActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }
        [HttpPost]
        public IActionResult Create(IdentityRole Role)
        {
            _db.Roles.Add(Role);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
