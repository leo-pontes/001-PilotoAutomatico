using ATP.Core.WebApi.Controllers;
using ATP.Identidade.API.Models;
using ATP.Identidade.API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ATP.Identidade.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/identidade")]    
    public class AuthController : MainController
    {
        private readonly AuthService _authenticationService;

        public AuthController(AuthService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("novo")]
        public async Task<IActionResult> Registrar(UsuarioCadastro usuarioRegistro)
        {
            try
            {
                if (!ObjetoValido(ModelState))
                    return RespostaSolicitacaoInvalida(usuarioRegistro);

                var user = new IdentityUser
                {
                    UserName = usuarioRegistro.Nome,
                    Email = usuarioRegistro.Email,
                    PhoneNumber = usuarioRegistro.Telefone,
                    EmailConfirmed = true
                };

                var result = await _authenticationService.UserManager.CreateAsync(user, usuarioRegistro.Senha);

                if (result.Succeeded)
                    return RespostaCriacaoSucesso("", _authenticationService.GerarJwt(usuarioRegistro.Email));
                else
                    return RespostaErroServidor();
            }
            catch (Exception ex)
            {
                AdicionarErroProcesso(ex.Message);
                return RespostaErroServidor();
            }
        }

        [HttpPost("autenticar")]
        public async Task<IActionResult> Login(UsuarioLogin usuarioLogin)
        {
            if (!ObjetoValido(ModelState))
                return RespostaSolicitacaoInvalida();

            var nomeUsuario = await _authenticationService.UserManager.FindByEmailAsync(usuarioLogin.Email);
            if (nomeUsuario == null)
            {
                AdicionarErroProcesso("Usuário não cadastrado");
                return RespostaSolicitacaoInvalida();
            }

            var result = await _authenticationService.SignInManager.PasswordSignInAsync(nomeUsuario.UserName, usuarioLogin.Senha, false, true);

            if (result.Succeeded)
                return RespostaOK(await _authenticationService.GerarJwt(usuarioLogin.Email));

            if (result.IsLockedOut)
            {
                AdicionarErroProcesso("Usuário temporariamente bloqueado por excesso de tentativas inválidas");
                return RespostaSolicitacaoInvalida();
            }

            AdicionarErroProcesso("Usuário ou Senha incorretos");
            return RespostaSolicitacaoInvalida();
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] string refreshToken)
        {
            if (string.IsNullOrEmpty(refreshToken))
            {
                AdicionarErroProcesso("Refresh Token inválido");
                return RespostaSolicitacaoInvalida();
            }

            var token = await _authenticationService.ObterRefreshToken(Guid.Parse(refreshToken));

            if (token is null)
            {
                AdicionarErroProcesso("Refresh Token expirado");
                return RespostaSolicitacaoInvalida();
            }

            return RespostaOK(await _authenticationService.GerarJwt(token.Username));
        }
    }
}
