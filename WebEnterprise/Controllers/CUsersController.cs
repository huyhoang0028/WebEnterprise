using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebEnterprise.Data;
using WebEnterprise.Models;

namespace WebEnterprise.Controllers
{
    public class CUsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public CUsersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: CUsers
        public async Task<IActionResult> Index()
        {
              return _context.CUser != null ? 
                          View(await _context.CUser.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.CUser'  is null.");
        }

        // GET: CUsers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.CUser == null)
            {
                return NotFound();
            }

            var cUser = await _context.CUser
                .FirstOrDefaultAsync(m => m.CUserId == id);
            if (cUser == null)
            {
                return NotFound();
            }

            return View(cUser);
        }

        // GET: CUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CUserId,Mail,Name,StaffNumber,Fullname_,Address,HomeTown,SocialMedia,Images")] CUser cUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cUser);
        }






        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, ApplicationUser user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.FindByIdAsync(id);
                if (currentUser == null)
                {
                    return NotFound();
                }

                currentUser.CUser.Fullname_ = user.CUser.Fullname_;
                currentUser.CUser.Fullname_ = user.CUser.Fullname_;
                currentUser.Email = user.Email;
                currentUser.UserName = user.UserName;

                var result = await _userManager.UpdateAsync(currentUser);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(user);
        }

        // POST: CUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.CUser == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CUser'  is null.");
            }
            var cUser = await _context.CUser.FindAsync(id);
            if (cUser != null)
            {
                _context.CUser.Remove(cUser);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CUserExists(string id)
        {
          return (_context.CUser?.Any(e => e.CUserId == id)).GetValueOrDefault();
        }
    }
}
