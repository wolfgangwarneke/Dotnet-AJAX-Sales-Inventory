using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TimelinePleaseWork.Data;
using TimelinePleaseWork.Models;

namespace TimelinePleaseWork.Controllers
{
    public class InventoryItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InventoryItemsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: InventoryItems
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.InventoryItem.Include(i => i.Item);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: InventoryItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryItem = await _context.InventoryItem.SingleOrDefaultAsync(m => m.InventoryItemId == id);
            if (inventoryItem == null)
            {
                return NotFound();
            }

            return View(inventoryItem);
        }

        // GET: InventoryItems/Create
        public IActionResult Create()
        {
            ViewData["ItemId"] = new SelectList(_context.Items, "ItemId", "ItemId");
            return View();
        }

        // POST: InventoryItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InventoryItemId,Category,ItemId,Quantity")] InventoryItem inventoryItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventoryItem);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ItemId"] = new SelectList(_context.Items, "ItemId", "ItemId", inventoryItem.ItemId);
            return View(inventoryItem);
        }

        // GET: InventoryItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryItem = await _context.InventoryItem.SingleOrDefaultAsync(m => m.InventoryItemId == id);
            if (inventoryItem == null)
            {
                return NotFound();
            }
            ViewData["ItemId"] = new SelectList(_context.Items, "ItemId", "ItemId", inventoryItem.ItemId);
            return View(inventoryItem);
        }

        // POST: InventoryItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InventoryItemId,Category,ItemId,Quantity")] InventoryItem inventoryItem)
        {
            if (id != inventoryItem.InventoryItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventoryItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryItemExists(inventoryItem.InventoryItemId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["ItemId"] = new SelectList(_context.Items, "ItemId", "ItemId", inventoryItem.ItemId);
            return View(inventoryItem);
        }

        // GET: InventoryItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryItem = await _context.InventoryItem.SingleOrDefaultAsync(m => m.InventoryItemId == id);
            if (inventoryItem == null)
            {
                return NotFound();
            }

            return View(inventoryItem);
        }

        // POST: InventoryItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventoryItem = await _context.InventoryItem.SingleOrDefaultAsync(m => m.InventoryItemId == id);
            _context.InventoryItem.Remove(inventoryItem);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool InventoryItemExists(int id)
        {
            return _context.InventoryItem.Any(e => e.InventoryItemId == id);
        }
    }
}
