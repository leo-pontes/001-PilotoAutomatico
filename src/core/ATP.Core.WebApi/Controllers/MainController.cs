using ATP.Core.Validation.Models;
using ATP.Core.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace ATP.Core.WebApi.Controllers
{
    [ApiController]
    public abstract class MainController : Controller
    {
        protected ICollection<string> Erros = new List<string>();     

        protected bool ObjetoValido(ModelStateDictionary objeto)
        {
            var erros = objeto.Values.SelectMany(e => e.Errors);

            foreach (var erro in erros)
            {
                AdicionarErroProcesso(erro.ErrorMessage);
            }

            return !Erros.Any();
        }

        protected bool ObjetoValido(ResultValidation validation)
        {
            foreach (var erro in validation.Errors)
            {
                AdicionarErroProcesso(erro.Mensagem);
            }

            return !Erros.Any();
        }

        protected bool ResponsePossuiErros(ResponseResult resposta)
        {
            if (resposta == null || !resposta.Errors.Mensagens.Any()) return false;

            foreach (var mensagem in resposta.Errors.Mensagens)
            {
                AdicionarErroProcesso(mensagem);
            }

            return true;
        }

        protected ValidationProblemDetails ObterErrosEstruturaResposta()
        {
            if (Erros.Any())
            {
                return new ValidationProblemDetails(new Dictionary<string, string[]>
                {
                    { "Mensagens", Erros.ToArray() }
                });
            }

            return null;
        }

        protected IActionResult RespostaSolicitacaoInvalida(object result = null)
        {           
            return BadRequest(ObterErrosEstruturaResposta());
        }

        protected IActionResult RespostaNaoAutorizado(object result = null)
        {
            return Unauthorized();
        }

        protected IActionResult RespostaProibido(object result = null)
        {
            return Forbid();
        }

        protected IActionResult RespostaNaoEncontrado(object result = null)
        {
            return NotFound();
        }

        protected IActionResult RespostaErroServidor(object result = null)
        {
            var resposta = new ObjectResult(result);

            resposta.StatusCode = 500;

            if (Erros.Any())
                resposta.Value = ObterErrosEstruturaResposta();

            return resposta;
        }

        protected IActionResult RespostaOK(object result = null)
        {            
            return Ok(result);
        }

        protected IActionResult RespostaCriacaoSucesso(string uriGet, object result = null)
        {            
            return Created(uriGet, result);
        }

        protected void AdicionarErroProcesso(string erro)
        {
            Erros.Add(erro);
        }

        protected void AdicionarErroProcesso()
        {
            Erros.Clear();
        }
    }
}