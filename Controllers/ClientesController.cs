using CrudPrueba.Data;
using CrudPrueba.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudPrueba.Controllers
{
    public class ClientesController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

       

        //Http Index
        public IActionResult Index()
        {
            IEnumerable<Cliente> ListClientes = _context.Clientes;

            return View(ListClientes);
        }

        //Http Get Create
        public IActionResult Create()
        {
            return View();

        }

        //Http Post Create
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();

                TempData["mensaje"] = "El Cliente se creo correctamente";
                return RedirectToAction("Index");
            }

            return View();

        }

        //Http Get Edit
        public IActionResult Edit(int? Codigo)
        {

            if (Codigo == null || Codigo == 0) 
            {
                return NotFound();
            }

            var clientes = _context.Clientes.Find(Codigo);
            if (clientes == null)
            {
                return NotFound();
            }
            return View(clientes);

        }

        //Http Post Edit
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Clientes.Update(cliente);
                _context.SaveChanges();

                TempData["mensaje"] = "El Cliente se actualizado correctamente";
                return RedirectToAction("Index");
            }

            return View();

        }

        //Http Get Delete
        public IActionResult Delet(int? Codigo)
        {

            if (Codigo == null || Codigo == 0)
            {
                return NotFound();
            }

            var clientes = _context.Clientes.Find(Codigo);
            if (clientes == null)
            {
                return NotFound();
            }
            return View(clientes);

        }

        //Http Post Delet
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeleteClientes(int? Codigo)
        {
           
            var clientes = _context.Clientes.Find(Codigo);

            if (clientes== null)
            {
                return NotFound();

            }


            _context.Clientes.Remove(clientes);
                _context.SaveChanges();

                TempData["mensaje"] = "El Cliente se eliminado correctamente";
                return RedirectToAction("Index");
           

    

        }


    }
}
