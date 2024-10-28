using Dto;
using LogicaDeAplicacion.InterfacesCU.Tareas;
using LogicaDeNegocios.Entidades;
using LogicaDeNegocios.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models;
using System.Diagnostics;

namespace Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGetAllTareas _getAllTareas;
        private readonly IGetTarea _getTarea;
        private readonly IEliminarTarea _eliminarTarea;
        private readonly IModificarTarea _modificarTarea;
        private readonly IAltaTarea _altaTarea;

        public HomeController(IGetAllTareas getAllTareas, IGetTarea getTarea, IEliminarTarea eliminarTarea, IModificarTarea modificarTarea, IAltaTarea altaTarea)
        {
            _getAllTareas = getAllTareas;
            _getTarea = getTarea;
            _eliminarTarea = eliminarTarea;
            _modificarTarea = modificarTarea;
            _altaTarea = altaTarea;
        }
        public IActionResult Alta()
        {
            return View(new TareaDto());
        }
        [HttpPost]
        public IActionResult Alta(TareaDto tDto)
        {
            try
            {
                _altaTarea.Ejecutar(tDto);
            }
            catch (ElementoInvalidoException e)
            {
                ViewBag.msg = e.Message;
                return View(tDto);
            }
            TempData["msg"] = "Tarea agregada correctamente";
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Index(string filtro)
        {
            IEnumerable<TareaDto> tareas = _getAllTareas.Ejecutar().OrderBy(t => t.Estado).ThenBy(t => t.FechaRealizar);
            if(filtro == "pendientes")
            {
                tareas = tareas.Where(t => t.Estado == EnumEstado.Pendiente);
            }
            return View(tareas);
        }
        public IActionResult Edit(int id)
        {
            TareaDto tDto = _getTarea.Ejecutar(id);
            return View(tDto);
        }
        public IActionResult Delete(int id) 
        {
            _eliminarTarea.Ejecutar(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Completar(int id)
        {
            TareaDto tDto = _getTarea.Ejecutar(id);
            Tarea tarea = tDto.ToTarea();
            tarea.Completar();
            TareaDto tareaDtoAModificar = new TareaDto(tarea);
            _modificarTarea.Ejecutar(id, tareaDtoAModificar);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(int id, TareaDto tDto)
        {
            try
            {
                _modificarTarea.Ejecutar(id, tDto);
                TempData["msg"] = "Tarea modificada correctamente";
            }
            catch (ElementoInvalidoException e)
            {
                ViewBag.msg = e.Message;
                return View(tDto);
            }
            return RedirectToAction(nameof(Index));
        }
        
    }
}
