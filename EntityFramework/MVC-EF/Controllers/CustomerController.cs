using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC_EF.Models;

namespace MVC_EF.Controllers;

public class CustomerController : Controller
{
    private readonly ApplicationDbContext _context;

    public CustomerController()
    {
        _context = new ApplicationDbContext();
    }

    public IActionResult Index()
    {
        var Customers = _context.Customers.ToList();
        return View(Customers);
    }

    public IActionResult AddCustomer()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddCustomer(Customer customer)
    {
        if (ModelState.IsValid)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Success");
        }
        return View(customer);
    }

    public IActionResult Success()
    {
        return View();
    }

    public IActionResult Edit(int? Id)
    {
        if (Id == null || _context.Customers == null)
        {
            return NotFound();
        }

        var Customer = _context.Customers.FirstOrDefault(c => c.Id == Id);
        if (Customer == null)
        {
            return NotFound();
        }

        return View(Customer);
    }

    [HttpPost]
    public IActionResult Edit(Customer customer)
    {
        if (ModelState.IsValid)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(customer);
    }
    public IActionResult Delete(int? Id)
    {
        if (Id == null || _context.Customers == null)
        {
            return NotFound();
        }

        var Customer = _context.Customers.FirstOrDefault(c => c.Id == Id);
        if (Customer == null)
        {
            return NotFound();
        }

        return View(Customer);
    }

    [HttpPost]
    public IActionResult Delete(Customer customer)
    {
        if (ModelState.IsValid)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(customer);
    }

}
