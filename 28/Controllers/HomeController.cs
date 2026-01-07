using _28.Models;
using _28.Services.Abstractions;
using _28.Services.Implementations;
using _28.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace _28.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITareaServices tareaServices;

        public HomeController(ILogger<HomeController> logger, ITareaServices tareaServices)
        {
            _logger = logger;
            this.tareaServices = tareaServices;
        }

        public async Task<IActionResult> Index()
        {
            List<TareaViewModel> tareasViewModel = await tareaServices.DevuelveTareas();

            return View(tareasViewModel);
        }

        public IActionResult Nuevo()
        {
            TareaViewModel tareaViewModel = new TareaViewModel();

            return View(tareaViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Nuevo(TareaViewModel tareaViewModel)
        {
            //Verifica si el Modelo de la Vista es valido, el Modelo de la Vista es valido cuando cumple las validaciones
            if (!ModelState.IsValid)
            {
                //Se devuelve el Modelo de la Vista, para colocar la informacion que ya se tenia en la Vista
                return View(tareaViewModel);
            }

            await tareaServices.NuevaTarea(tareaViewModel);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Editar(int id)
        {
            var tareaViewModel = await tareaServices.DevuelveTarea(id);

            if (tareaViewModel is null)
            {
                return RedirectToAction("Index");
            }

            return View(tareaViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(TareaViewModel tareaViewModel)
        {
            var tareaEncontradaViewModel = await tareaServices.DevuelveTarea(tareaViewModel.Id);

            if (tareaEncontradaViewModel is null)
            {
                return RedirectToAction("Index");
            }

            //Verifica si el Modelo de la Vista es valido, el Modelo de la Vista es valido cuando cumple las validaciones
            if (!ModelState.IsValid)
            {
                //Se devuelve el Modelo de la Vista, para colocar la informacion que ya se tenia en la Vista
                return View(tareaViewModel);
            }

            await tareaServices.EditarTarea(tareaViewModel);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            var tareaEncontradaViewModel = await tareaServices.DevuelveTarea(id);

            if (tareaEncontradaViewModel is null)
            {
                return RedirectToAction("Index");
            }

            await tareaServices.EliminarTarea(tareaEncontradaViewModel);

            return RedirectToAction("Index");
        }
    }
}
