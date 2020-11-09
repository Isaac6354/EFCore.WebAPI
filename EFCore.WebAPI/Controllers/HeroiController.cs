using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.WebAPI.Data;
using EFCore.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroiController : ControllerBase
    {
        private readonly HeroiContext _HeroiContext;

        public HeroiController(HeroiContext HeroiContext) 
        {
            _HeroiContext = HeroiContext;
        }

        public HeroiController()
        {
            //Foi criado este contrutor vazio para rodar o testes de gerar lista com falha e com sucesso
        }

        // GET: api/<HeroiController>
        [HttpGet]
        public IEnumerable<Heroi> Get()
        {
            return _HeroiContext.Herois;
        }

        // GET api/<HeroiController>/5
        [HttpGet("{id}", Name = "Get")]
        public Heroi Get(int id)
        {
            return _HeroiContext.Herois.SingleOrDefault(x => x.Id == id);
        }

        // POST api/<HeroiController>
        [HttpPost]
        public void Post([FromBody] Heroi heroi)
        {
            _HeroiContext.Herois.Add(heroi);
            _HeroiContext.SaveChanges();
        }

        // PUT api/<HeroiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Heroi heroi)
        {
            _HeroiContext.Herois.Update(heroi);
            _HeroiContext.SaveChanges();
        }

        // DELETE api/<HeroiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _HeroiContext.Herois.FirstOrDefault(x => x.Id == id);
            if (item != null) 
            {
                _HeroiContext.Herois.Remove(item);
                _HeroiContext.SaveChanges();
            }
        }

        public Task GerarListaAsync()
        {
            throw new NotImplementedException();
        }
    }
}
