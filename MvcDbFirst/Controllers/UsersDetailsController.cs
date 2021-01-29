using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcDbFirst.Data;
using MvcDbFirst.Models;

namespace MvcDbFirst.Controllers
{
    public class UsersDetailsController : Controller
    {
        private readonly MYMvcDbContext _context;

        public UsersDetailsController(MYMvcDbContext context)
        {
            _context = context;
        }

        // GET: UsersDetails
        public IActionResult Index()
        {
            List<UsersDetail> usersDetails = _context.UsersDetails.ToList();
            return View(usersDetails);
        }

        // GET: UsersDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usersDetail = await _context.UsersDetails
                .Include(u => u.CidNavigation)
                .Include(u => u.City)
                .Include(u => u.SidNavigation)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (usersDetail == null)
            {
                return NotFound();
            }

            return View(usersDetail);
        }

        // GET: UsersDetails/Create
        public IActionResult Create()
        {
            ViewData["Cid"] = new SelectList(_context.Tblcountries, "Cid", "Cid");
            ViewData["Cityid"] = new SelectList(_context.TblCities, "Cityid", "Cityid");
            ViewData["Sid"] = new SelectList(_context.Tblstates, "Sid", "Sid");
            return View();
        }

        // POST: UsersDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Username,Emailid,Address,Pincode,Password,Gender,Phone,Usertype,Cid,Sid,Cityid")] UsersDetail usersDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usersDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cid"] = new SelectList(_context.Tblcountries, "Cid", "Cid", usersDetail.Cid);
            ViewData["Cityid"] = new SelectList(_context.TblCities, "Cityid", "Cityid", usersDetail.Cityid);
            ViewData["Sid"] = new SelectList(_context.Tblstates, "Sid", "Sid", usersDetail.Sid);
            return View(usersDetail);
        }

        // GET: UsersDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usersDetail = await _context.UsersDetails.FindAsync(id);
            if (usersDetail == null)
            {
                return NotFound();
            }
            ViewData["Cid"] = new SelectList(_context.Tblcountries, "Cid", "Cid", usersDetail.Cid);
            ViewData["Cityid"] = new SelectList(_context.TblCities, "Cityid", "Cityid", usersDetail.Cityid);
            ViewData["Sid"] = new SelectList(_context.Tblstates, "Sid", "Sid", usersDetail.Sid);
            return View(usersDetail);
        }

        // POST: UsersDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Username,Emailid,Address,Pincode,Password,Gender,Phone,Usertype,Cid,Sid,Cityid")] UsersDetail usersDetail)
        {
            if (id != usersDetail.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usersDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersDetailExists(usersDetail.UserId))
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
            ViewData["Cid"] = new SelectList(_context.Tblcountries, "Cid", "Cid", usersDetail.Cid);
            ViewData["Cityid"] = new SelectList(_context.TblCities, "Cityid", "Cityid", usersDetail.Cityid);
            ViewData["Sid"] = new SelectList(_context.Tblstates, "Sid", "Sid", usersDetail.Sid);
            return View(usersDetail);
        }

        // GET: UsersDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usersDetail = await _context.UsersDetails
                .Include(u => u.CidNavigation)
                .Include(u => u.City)
                .Include(u => u.SidNavigation)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (usersDetail == null)
            {
                return NotFound();
            }

            return View(usersDetail);
        }

        // POST: UsersDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usersDetail = await _context.UsersDetails.FindAsync(id);
            _context.UsersDetails.Remove(usersDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsersDetailExists(int id)
        {
            return _context.UsersDetails.Any(e => e.UserId == id);
        }
    }
}
