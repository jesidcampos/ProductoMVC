using Microsoft.AspNetCore.Mvc;
using MiPrimeraAppMvc.Models;
using System.Collections.Generic;
using System;
using MiPrimeraAppMvc.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiPrimeraAppMvc.Data.Repository.Interfaces;

namespace MiPrimeraAppMvc.Controllers
{
    public class ProductoController : Controller
    {
        //private readonly ProductosContext _context;
        private readonly IProductoRepository _productoRepository;

        //public ProductoController(ProductosContext context)
        //{
        //    _context = context;
        //}

        public ProductoController(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<IActionResult> Index()
        {
            //var productos = await _context.Productos.ToListAsync();
            var productos = await _productoRepository.GetAll();
            return View(productos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Producto producto)
        {
            if(ModelState.IsValid)
            {
                //producto.FechaDeAlta = DateTime.Now;
                //_context.Add(producto);
                //await _context.SaveChangesAsync();
                var result = await _productoRepository.Create(producto);
                if (result < 0)
                {
                    ViewBag.ErrorMessage = "Error al guardar datos";
                    return View(producto)                    ;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(producto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if(id == 0)
                return NotFound();

            var producto = await _productoRepository.GetById(id);

            if(producto == null)
                return NotFound();

            return View(producto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Producto producto)
        {
            if(id != producto.Id)
                return NotFound();

            if(ModelState.IsValid)
            {
                //_context.Update(producto);
                //await _context.SaveChangesAsync();
                var result = await _productoRepository.Update(producto);
                if(result < 0)
                {
                    ViewBag.ErrorMessage = "Error al actualizar los datos";
                    return View(producto);
                }                   
                return RedirectToAction(nameof(Index));
            }

            return View(producto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if(id == 0)
                return NotFound();

            //var producto = await _context.Productos.FindAsync(id);
            var producto = await _productoRepository.GetById(id);

            if(producto == null)
                return NotFound();
            
            return View(producto);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            //var producto = await _context.Productos.FindAsync(id);

            //_context.Productos.Remove(producto);
            //await _context.SaveChangesAsync();

            var result = await _productoRepository.DeleteById(id);
            if(result)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.ErrorMessage = "Error al intentar borrar!!!";
                return View();
            }
            
        }
    }
}