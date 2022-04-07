using API.Attributes;
using Application.Interface;
using Application.ViewModel.Request;
using Application.ViewModel.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AgendamentoController : ControllerBase
    {
        private readonly IConfiguration _Configuration;
        private readonly IAgendamentoAppService _AgendamentoAppService;

        public AgendamentoController(IConfiguration Configuration, IAgendamentoAppService AgendamentoAppService)
        {
            _Configuration = Configuration;
            _AgendamentoAppService = AgendamentoAppService;
        }

        // GET: api/<Agendamento>
        /// <summary>
        /// Consultar agendamento(s) do associado: Este endpoint deve ser utilizado para  consultar um agendamento específico 
        /// utilizando o identificador do associado como filtro.
        /// </summary>
        /// <param name="idAssociado">Identificador do associado</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<ResponseAgendamentoViewModel>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(string))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(string))]
        public List<ResponseAgendamentoViewModel> List([Required][FromQuery] long idAssociado)
        {
            return _AgendamentoAppService.List(idAssociado).Result;
        }

        // GET api/<Agendamento>/5
        /// <summary>
        /// Consultar agendamento: Este endpoint deve ser utilizado para  consultar um agendamento específico 
        /// utilizando o identificador do agendamento como filtro.
        /// </summary>
        /// <param name="id">Identificador do agendamento</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseAgendamentoViewModel))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(string))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(string))]
        public ResponseAgendamentoViewModel Get([Required][FromRoute] long id)
        {
            return _AgendamentoAppService.Get(id).Result;
        }

        // POST api/<Agendamento>
        /// <summary>
        /// Cadastrar agendamento: Este endpoint deve ser utilizado para registrar agendamentos para os associados.
        /// </summary>
        /// <param name="value">Dados do agendamento</param>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseAgendamentoViewModel))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(string))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(string))]
        public IActionResult Post([Required][FromBody] RequestAgendamentoViewModel value)
        {
            // var result = _AgendamentoAppService.Add(value);


            ObjectResult result = null;
            DateTime initProcess = DateTime.Now;

            try
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                var validations = value.Validate(new ValidationContext(value));

                if (!validations.Any())
                {
                    var response = _AgendamentoAppService.Add(value).Result;

                    if ((response?.Id ?? 0) > 0)
                        result = StatusCode((int)HttpStatusCode.OK, response);
                    else
                        result = StatusCode((int)HttpStatusCode.BadRequest, "Erro na inclusão do agendamento.");
                }
                else
                    result = StatusCode((int)HttpStatusCode.BadRequest, validations);
            }
            catch (UnauthorizedAccessException ex)
            {
                result = StatusCode((int)HttpStatusCode.Unauthorized, ex.Message);
            }
            //catch (ArgumentNullException ex)
            //{
            //    result = StatusCode((int)HttpStatusCode.BadRequest, new ResponseErrorsViewModel() { Errors = new List<string>() { "Json inválido." } });
            //}
            catch (HttpRequestException ex)
            {
                result = StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                result = StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }

            return result;
        }

        /// <summary>
        /// Alterar agendamento: Este endpoint deve ser utilizado para altear um agendamento.
        /// </summary>
        /// <param name="id">Identificador do agendamento</param>
        /// <param name="value">Dados do agendamento</param>
        // PUT api/<Agendamento>/5
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(string))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(string))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(string))]
        public void Put([Required][FromRoute] long id, [Required][FromBody] RequestAgendamentoViewModel value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<Agendamento>/5
        /// <summary>
        /// Cancelar agendamento: Este endpoint deve ser utilizado para cancelar um agendamento.
        /// </summary>
        /// <param name="id">Identificador do agendamento</param>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(string))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(string))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(string))]
        public void Delete([Required][FromRoute] long id)
        {
            throw new NotImplementedException();
        }
    }
}
