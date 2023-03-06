using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebEnterprise.Data;
using WebEnterprise.Models;

namespace WebEnterprise.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<CUser> _userManager;
        private readonly ApplicationDbContext _context;

        public UserController(UserManager<CUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string? id, CUser user, IFormFile file)
        {
            if (id != user.CUserId)
            {
                return NotFound();
            }

            var userToUpdate = await _userManager.FindByIdAsync(id);
            if (userToUpdate == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                userToUpdate.Mail = user.Mail;
                userToUpdate.Name = user.Name;
                userToUpdate.StaffNumber = user.StaffNumber;
                userToUpdate.Fullname_ = user.Fullname_;
                userToUpdate.Address = user.Address;
                userToUpdate.HomeTown = user.HomeTown;
                userToUpdate.SocialMedia = user.SocialMedia;

                if (file != null && file.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        await file.CopyToAsync(ms);
                        userToUpdate.Images = ms.ToArray();
                    }
                }

                try
                {
                    await _userManager.UpdateAsync(userToUpdate);
                    _context.Update(userToUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(userToUpdate.CUserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(user);
        }

        private bool UserExists(string id)
        {
            return _userManager.Users.Any(e => e.CUserId == id);
        }
    }
}
