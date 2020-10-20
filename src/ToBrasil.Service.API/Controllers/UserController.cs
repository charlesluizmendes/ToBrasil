using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToBrasil.Application.DTO;
using ToBrasil.Application.Services.Command;
using ToBrasil.Application.Services.Query;
using ToBrasil.Domain.Entities;

namespace ToBrasil.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UserController(IMapper mapper,
            IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost("Cadastro")]
        public async Task<ActionResult<CadastroOutputDTO>> Cadastro(CadastroInputDTO cadastroDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(cadastroDTO);
            }

            var cadastro = await _mediator.Send(new CreateUserCommand
            {
                User = _mapper.Map<Users>(cadastroDTO)
            });

            if (cadastro == null)
            {
                return BadRequest("E-mail já existente");
            }            

            return new ObjectResult(_mapper.Map<CadastroOutputDTO>(cadastro));
        }

        [HttpPost("Login")]
        public async Task<ActionResult<LoginOutputDTO>> Login(LoginInputDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(loginDTO);
            }

            var login = await _mediator.Send(new GetUserByLoginQuery
            {
                User = _mapper.Map<Users>(loginDTO)
            });

            if (login == null)
            {
                return Unauthorized("Usuário e/ou senha inválidos");
            }

            return Ok(_mapper.Map<LoginOutputDTO>(login));
        }
    }
}
