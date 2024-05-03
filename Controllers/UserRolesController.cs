using Leave_Management.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management.Controllers
{
    public class UserRolesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<UserRole> _roleManager;

        public UserRolesController(ApplicationDbContext context, RoleManager<UserRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }

        // GET: UserRoles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Roles.ToListAsync());
        }

        // GET: UserRoles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Roles == null)
            {
                return NotFound();
            }

            var userRole = await _context.Roles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userRole == null)
            {
                return NotFound();
            }

            return View(userRole);
        }

        // GET: UserRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] UserRole userRole)
        {
            if (string.IsNullOrWhiteSpace(userRole.Name))
            {
                ModelState.AddModelError("Name", "Role name is required");
            }


            if (ModelState.IsValid)
            {
                var normalizedRoleName = userRole.Name?.ToUpper() ?? string.Empty;

                var existingRole = await _context.Roles
                                                 .FirstOrDefaultAsync(r => r.NormalizedName == normalizedRoleName);

                if (existingRole != null)
                {
                    ModelState.AddModelError("Name", "Role name already exists");
                }

                if (ModelState.IsValid)
                {
                    userRole.Id = Guid.NewGuid().ToString();
                    userRole.NormalizedName = normalizedRoleName;
                    userRole.ConcurrencyStamp = Guid.NewGuid().ToString();

                    _context.Add(userRole);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
            }

            return View(userRole);
        }

        // GET: UserRoles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Roles == null)
            {
                return NotFound();
            }

            var userRole = await _context.Roles.FindAsync(id);
            if (userRole == null)
            {
                return NotFound();
            }
            return View(userRole);
        }

        // POST: UserRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name, Id, NormalizedName, ConcurrencyStamp")] UserRole role)
        {
            if (id != role.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Retrieve the existing role from the database
                    var existingRole = await _roleManager.FindByIdAsync(id);

                    if (existingRole == null)
                    {
                        return NotFound();
                    }

                    // Update the properties of the existingRole with the values from role
                    existingRole.Name = role.Name;

                    await _roleManager.UpdateAsync(existingRole);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _roleManager.RoleExistsAsync(role.Id))
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
            return View(role);
        }


        // GET: UserRoles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Roles == null)
            {
                return NotFound();
            }

            var userRole = await _context.Roles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userRole == null)
            {
                return NotFound();
            }

            return View(userRole);
        }

        // POST: UserRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Roles == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UserRole'  is null.");
            }
            var userRole = await _context.Roles.FindAsync(id);
            if (userRole != null)
            {
                _context.Roles.Remove(userRole);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserRoleExists(string id)
        {
            return _context.Roles.Any(e => e.Id == id);
        }
    }
}
