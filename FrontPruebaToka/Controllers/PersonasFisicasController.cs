using FrontPruebaToka.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace FrontPruebaToka.Controllers
{
    public class PersonasFisicasController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PersonasFisicasController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5268/api/PersonaFisica");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var persons = JsonSerializer.Deserialize<List<PersonaFisicaViewModel>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return View(persons);
            }

            return View(new List<PersonaFisicaViewModel>());
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"http://localhost:5268/api/PersonaFisica/{id}");

            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Persona eliminada correctamente.";
            }
            else
            {
                TempData["ErrorMessage"] = "Error al eliminar la persona.";
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Create(PersonaFisicaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Todos los campos son requeridos.";
                return RedirectToAction("Index");
            }

            var client = _httpClientFactory.CreateClient();

            var json = JsonSerializer.Serialize(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("http://localhost:5268/api/PersonaFisica", content);

            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Persona agregada exitosamente.";
            }
            else
            {
                TempData["ErrorMessage"] = "Error al agregar la persona.";
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PersonaFisicaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Los datos son inválidos.";
                return RedirectToAction("Index");
            }

            var client = _httpClientFactory.CreateClient();

            var payload = new
            {
                model.Id,
                model.Nombre,
                model.ApellidoPaterno,
                model.ApellidoMaterno,
                model.RFC,
                model.FechaNacimiento,
                UsuarioAgrega = 1
            };

            var json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("http://localhost:5268/api/PersonaFisica", content);

            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Persona editada correctamente.";
            }
            else
            {
                TempData["Error"] = "Ocurrió un error al editar.";
            }

            return RedirectToAction("Index");
        }

    }
}
