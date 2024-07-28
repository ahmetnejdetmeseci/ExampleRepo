using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Contexts;
using DataAccess.Entities;
using Business.Services.Bases;
using Business.Models;

namespace MVC.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerModel _customerService;

        public CustomersController(ICustomerModel customerModel)
        {
            _customerService = customerModel;
        }

        // GET: Customers
        public IActionResult Index()
        {
            return View(_customerService.Query().ToList());
        }

        // GET: Customers/Details/5
        //public IActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var customer = _context.Customers
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(customer);
        //}

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CustomerModel customer)
        {
            if (ModelState.IsValid)
            {
                var result = _customerService.Add(customer);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.Message);
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        //    public async Task<IActionResult> Edit(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var customer = await _context.Customers.FindAsync(id);
        //        if (customer == null)
        //        {
        //            return NotFound();
        //        }
        //        return View(customer);
        //    }

        //    // POST: Customers/Edit/5
        //    // To protect from overposting attacks, enable the specific properties you want to bind to.
        //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Date")] Customer customer)
        //    {
        //        if (id != customer.Id)
        //        {
        //            return NotFound();
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            try
        //            {
        //                _context.Update(customer);
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!CustomerExists(customer.Id))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }
        //            return RedirectToAction(nameof(Index));
        //        }
        //        return View(customer);
        //    }

        //    // GET: Customers/Delete/5
        //    public async Task<IActionResult> Delete(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var customer = await _context.Customers
        //            .FirstOrDefaultAsync(m => m.Id == id);
        //        if (customer == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(customer);
        //    }

        //    // POST: Customers/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> DeleteConfirmed(int id)
        //    {
        //        var customer = await _context.Customers.FindAsync(id);
        //        if (customer != null)
        //        {
        //            _context.Customers.Remove(customer);
        //        }

        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    private bool CustomerExists(int id)
        //    {
        //        return _context.Customers.Any(e => e.Id == id);
        //    }
        }
    }
