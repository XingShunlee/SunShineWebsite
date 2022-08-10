using ehaiker;
using ehaiker.Auth;
using ehaikerv202010.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ehaikerv202010.Controllers
{

    public class GroupPermissionBindersController : Controller
    {
        private readonly EhaikerContext _context;

        public GroupPermissionBindersController(EhaikerContext context)
        {
            _context = context;
        }

        // GET: GroupPermissionBinders
        [AdminLoginStateRequiredAttribute]
        public async Task<IActionResult> Index()
        {
            return View(await _context.GroupBinderTable.Where(r => r.Name != "superadmin").ToListAsync());
        }

        // GET: GroupPermissionBinders/Details/5
        [AdminLoginStateRequiredAttribute]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupPermissionBinder = await _context.GroupBinderTable
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groupPermissionBinder == null)
            {
                return NotFound();
            }

            return View(groupPermissionBinder);
        }

        // GET: GroupPermissionBinders/Create
        [AdminLoginStateRequiredAttribute]
        public IActionResult Create()
        {
            return View();
        }

        // POST: GroupPermissionBinders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminLoginStateRequiredAttribute]
        public async Task<IActionResult> Create([Bind("Id,ControllerNo,Name,Description,OwnPermissions")] GroupPermissionBinder groupPermissionBinder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groupPermissionBinder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(groupPermissionBinder);
        }

        // GET: GroupPermissionBinders/Edit/5
        [AdminLoginStateRequiredAttribute]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupPermissionBinder = await _context.GroupBinderTable.FindAsync(id);
            if (groupPermissionBinder == null)
            {
                return NotFound();
            }
            var chk = _context.PermissionTable.ToList();
            var types = chk;
            ViewBag.Types = types.Select(r => new SelectListItem { Text = r.ChineseActionName, Value = r.Id.ToString() });
            return View(groupPermissionBinder);
        }

        // POST: GroupPermissionBinders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminLoginStateRequiredAttribute]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ControllerNo,Name,Description,OwnPermissions")] GroupPermissionBinder groupPermissionBinder)
        {
            if (id != groupPermissionBinder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupPermissionBinder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupPermissionBinderExists(groupPermissionBinder.Id))
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
            return View(groupPermissionBinder);
        }

        // GET: GroupPermissionBinders/Delete/5
        [AdminLoginStateRequiredAttribute]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupPermissionBinder = await _context.GroupBinderTable
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groupPermissionBinder == null)
            {
                return NotFound();
            }

            return View(groupPermissionBinder);
        }

        // POST: GroupPermissionBinders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminLoginStateRequiredAttribute]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groupPermissionBinder = await _context.GroupBinderTable.FindAsync(id);
            _context.GroupBinderTable.Remove(groupPermissionBinder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupPermissionBinderExists(int id)
        {
            return _context.GroupBinderTable.Any(e => e.Id == id);
        }
    }
}
