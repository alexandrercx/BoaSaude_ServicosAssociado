using Application.Interface;
using Application.ViewModel.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicosAssociadoController : ControllerBase
    {
        private readonly IServicosAssociadoAppService _ServicosAssociadoAppService;

        public ServicosAssociadoController(IServicosAssociadoAppService ServicosAssociadoAppService)
        {
            _ServicosAssociadoAppService = ServicosAssociadoAppService;
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(int))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(string))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(string))]
        public IActionResult Post([Required][FromQuery] string key, [Required][FromBody] PostServicosAssociadoViewModel ServicosAssociadoViewModel)
        {
            try
            {

                int Id = _ServicosAssociadoAppService.PostCadastroServicosAssociado(ServicosAssociadoViewModel);
                return Ok(200);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }

        }

    }
}