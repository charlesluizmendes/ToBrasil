using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToBrasil.Application.DTO;
using ToBrasil.Application.Extensions;
using ToBrasil.Application.Interfaces;
using ToBrasil.Domain.Entities;

namespace ToBrasil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserAppService _userAppService;
        private readonly IPhoneAppService _phoneAppService;

        public UserController(IMapper mapper,
            IUserAppService userAppService,
            IPhoneAppService phoneAppService)
        {
            _mapper = mapper;
            _userAppService = userAppService;
            _phoneAppService = phoneAppService;
        }

        [HttpPost("Cadastro")]
        public ActionResult Cadastro(CadastroDTO cadastroDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(cadastroDTO);
            }

            var user = _mapper.Map<User>(cadastroDTO);
            user.PasswordHash = HasherExtension.HashPassword(user.PasswordHash);

            var verifyEmail = _userAppService.VerifyEmail(user.Email);

            if (verifyEmail)
            {
                return BadRequest("E-mail já existente");
            }

            _userAppService.Insert(user);
            _userAppService.Commit();

            return new ObjectResult(cadastroDTO);
        }

        [HttpPost("Login")]
        public ActionResult Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(loginDTO);
            }

            var user = _mapper.Map<User>(loginDTO);

            var verifyEmail = _userAppService.VerifyEmail(user.Email);

            if (!verifyEmail)
            {
                return BadRequest("Usuário e/ou senha inválidos");
            }

            var login = _userAppService.Login(user.Email, user.PasswordHash);

            if (!login)
            {
                return Unauthorized("Usuário e/ou senha inválidos");
            }

            var token = _userAppService.Token(user.Email);

            return Ok(new
            {               
                Login = loginDTO,
                Token = token
            });
        }
    }
}
