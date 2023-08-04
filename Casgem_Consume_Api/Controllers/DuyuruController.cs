using DTO.DTOs.DuyuruDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Casgem_Consume_Api.Controllers
{
    public class DuyuruController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DuyuruController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateDuyuruDTO createduyuruDTO)
        {
            var username = HttpContext.Session.GetString("Username");
            var client = _httpClientFactory.CreateClient();
            createduyuruDTO.Date = DateTime.Now;
            createduyuruDTO.UserName = username;
            createduyuruDTO.ImageUrl2 = "bos";
            var JsonData = JsonConvert.SerializeObject(createduyuruDTO);
            StringContent content = new StringContent(JsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7224/api/Duyuru", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }

        public async Task<IActionResult> DeleteDuyuru(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7224/api/Duyuru/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
