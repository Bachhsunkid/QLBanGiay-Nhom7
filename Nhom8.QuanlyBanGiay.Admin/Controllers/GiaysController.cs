using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nhom8.QuanlyBanGiay.Admin.Models;

namespace Nhom8.QuanlyBanGiay.Admin.Controllers
{
    public class GiaysController : Controller
    {
        private readonly QlbanGiayContext _context;

        public GiaysController(QlbanGiayContext context)
        {
            _context = context;
        }

        // GET: Giays
        public async Task<IActionResult> Index()
        {
              return View(await _context.Giays.ToListAsync());
        }

        // GET: Giays/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Giays == null)
            {
                return NotFound();
            }

            var giay = await _context.Giays
                .FirstOrDefaultAsync(m => m.MaGiay == id);
            if (giay == null)
            {
                return NotFound();
            }

            return View(giay);
        }

        // GET: Giays/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Giays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaGiay,TenGiay,KieuDang,KichCo,MauSac,SoLuong,GiaNhap,GiaGoc,GiaBan,PhanTramGiam,TinhTrang,Loai,DanhGia")] Giay giay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(giay);
                await _context.SaveChangesAsync();
                return RedirectToAction("Products", "Home");
            }
            return View(giay);
        }

        // GET: Giays/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Giays == null)
            {
                return NotFound();
            }

            var giay = await _context.Giays.FindAsync(id);
            if (giay == null)
            {
                return NotFound();
            }
            return View(giay);
        }

        // POST: Giays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaGiay,TenGiay,KieuDang,KichCo,MauSac,SoLuong,GiaNhap,GiaGoc,GiaBan,PhanTramGiam,TinhTrang,Loai,DanhGia")] Giay giay)
        {
            if (id != giay.MaGiay)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(giay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GiayExists(giay.MaGiay))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Products", "Home");
            }
            return View(giay);
        }

        // GET: Giays/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Giays == null)
            {
                return NotFound();
            }

            var giay = await _context.Giays
                .FirstOrDefaultAsync(m => m.MaGiay == id);
            if (giay == null)
            {
                return NotFound();
            }

            return View(giay);
        }

        // POST: Giays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Giays == null)
            {
                return Problem("Entity set 'QlbanGiayContext.Giays'  is null.");
            }
            var giay = await _context.Giays.FindAsync(id);
            if (giay != null)
            {
                _context.Giays.Remove(giay);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Products", "Home");
        }

        private bool GiayExists(string id)
        {
          return _context.Giays.Any(e => e.MaGiay == id);
        }
    }
}
