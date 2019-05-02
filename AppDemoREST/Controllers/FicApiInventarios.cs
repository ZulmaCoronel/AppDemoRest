using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppDemoREST.Data;
//using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppDemoREST.Controllers
{
    [Produces("application/json")]
    public class FicApiInventarios : Controller
    {
        //private readonly IConfiguration configuration;
        //public FicApiInventarios(IConfiguration config)
        //{
        //    this.configuration = config;
        //}
        private readonly FicDBContext FicLoDBContext;
        public FicApiInventarios(FicDBContext FicPaDBContext)
        {
            FicLoDBContext = FicPaDBContext;
        }//CONSTRUCTOR

        //GET: api/FicApiInventarios
        [HttpGet]
        [Route("api/inventarios/invacucon")]
        public async Task<IActionResult> FicApiGetListInventarios([FromQuery]int cedi)
        {
            //https://localhost:44321/api/inventarios/invacucon?cedi=5

            var zt_inventarios = (from data_inv in FicLoDBContext.zt_inventarios where data_inv.IdCEDI == cedi select data_inv).ToList();

            if (zt_inventarios.Count() > 0)
            {

                zt_inventarios = zt_inventarios.ToList();

                return Ok(zt_inventarios);
            }
            else
            {
                //var zt_inventarios_conteos = new List<zt_inventarios_conteos>();

                zt_inventarios = zt_inventarios.ToList();

                return Ok(zt_inventarios);
            }
        }
        // GET: api/<controller>
        //    [HttpGet]
        //    public IEnumerable<string> Get()
        //    {
        //        return new string[] { "value1", "value2" };
        //    }

        //    // GET api/<controller>/5
        //    [HttpGet("{id}")]
        //    public string Get(int id)
        //    {
        //        return "value";
        //    }

        //    // POST api/<controller>
        //    [HttpPost]
        //    public void Post([FromBody]string value)
        //    {
        //    }

        //    // PUT api/<controller>/5
        //    [HttpPut("{id}")]
        //    public void Put(int id, [FromBody]string value)
        //    {
        //    }

        //    // DELETE api/<controller>/5
        //    [HttpDelete("{id}")]
        //    public void Delete(int id)
        //    {
        //    }

    }
}
