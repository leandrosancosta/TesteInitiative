using Initiative.Teste.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Initiative.Teste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TesteController : ControllerBase
    {
        ValoresService service = new ValoresService();
        [HttpGet("GetTabela")]
        public string GetTabela()
        {
            var valores = service.GetTabela();
            return JsonConvert.SerializeObject(valores);
        }

        [HttpGet("ExecutarDecupagem")]
        public string ExecDecupage()
        {
            service.Decomposicao();
            return GetTabela();
        }
    }
}
