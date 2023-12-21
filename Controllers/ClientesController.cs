using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspCore_Scaffolding.Models;

namespace AspCore_Scaffolding.Controllers
{
    public class ClientesController : Controller
    {
        private readonly PanificadoradbContext _context;

        public ClientesController(PanificadoradbContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
              return _context.TbClientes != null ? 
                          View(await _context.TbClientes.ToListAsync()) :
                          Problem("Entity set 'PanificadoradbContext.TbClientes'  is null.");
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbClientes == null)
            {
                return NotFound();
            }

            var tbCliente = await _context.TbClientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbCliente == null)
            {
                return NotFound();
            }

            return View(tbCliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeCliente,CpfCnpj,ContatoCliente,EnderecoCliente")] TbCliente tbCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbCliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TbClientes == null)
            {
                return NotFound();
            }

            var tbCliente = await _context.TbClientes.FindAsync(id);
            if (tbCliente == null)
            {
                return NotFound();
            }
            return View(tbCliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeCliente,CpfCnpj,ContatoCliente,EnderecoCliente")] TbCliente tbCliente)
        {
            if (id != tbCliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbClienteExists(tbCliente.Id))
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
            return View(tbCliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TbClientes == null)
            {
                return NotFound();
            }

            var tbCliente = await _context.TbClientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbCliente == null)
            {
                return NotFound();
            }

            return View(tbCliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TbClientes == null)
            {
                return Problem("Entity set 'PanificadoradbContext.TbClientes'  is null.");
            }
            var tbCliente = await _context.TbClientes.FindAsync(id);
            if (tbCliente != null)
            {
                _context.TbClientes.Remove(tbCliente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbClienteExists(int id)
        {
          return (_context.TbClientes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
