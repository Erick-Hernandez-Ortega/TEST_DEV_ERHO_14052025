using FrontPruebaToka.Models;
using Microsoft.AspNetCore.Mvc;
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

    }
}
