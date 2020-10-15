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

namespace ToBrasil.API.Controllers
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

            var user = _mapper.Map<User>(cadastroDTO);

            var email = await _mediator.Send(new GetUserByEmailQuery
            {
                User = user
            });

            if (email != null)
            {
                return BadRequest("E-mail já existente");
            }

            var cadastro = await _mediator.Send(new CreateUserCommand
            {
                User = user
            });
            
            var output = _mapper.Map<CadastroOutputDTO>(cadastro);

            return new ObjectResult(output);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<LoginOutputDTO>> Login(LoginInputDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(loginDTO);
            }

            var user = _mapper.Map<User>(loginDTO);            

            var login = await _mediator.Send(new GetUserByLoginQuery
            {
                User = user
            });

            if (login == null)
            {
                return Unauthorized("Usuário e/ou senha inválidos");
            }          

            var output = _mapper.Map<LoginOutputDTO>(login);

            return Ok(output);
        }
    }
}
