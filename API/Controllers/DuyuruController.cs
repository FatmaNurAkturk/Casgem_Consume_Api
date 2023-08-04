using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DuyuruController : ControllerBase
    {
        private readonly IDuyuruService _duyuruService;

        public DuyuruController(IDuyuruService duyuruService)
        {
            _duyuruService = duyuruService;
        }
        [HttpGet]
        public IActionResult DuyuruList()
        {
            var values = _duyuruService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddDuyuru(Duyuru duyuru)
        {
            _duyuruService.TInsert(duyuru);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDuyuru(string id)
        {
            var values = _duyuruService.TGetByID(id);
            _duyuruService.TDelete(values);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetDuyuru(string id)
        {
            var values = _duyuruService.TGetByID(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateDuyuru(Duyuru duyuru)
        {
            _duyuruService.TUpdate(duyuru);
            return Ok();
        }
    }
}
