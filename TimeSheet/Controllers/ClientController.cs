﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Core.IServices;
using TimeSheet.Core.Models;
using TimeSheet.WebAPI.DTOs;
using TimeSheet.WebAPI.Routes;

namespace TimeSheet.WebAPI.Controllers
{
    [ApiController]
    public class ClientController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IClientService _clientService;
        public ClientController(IMapper mapper, IClientService clientService)
        {
            _mapper = mapper;
            _clientService = clientService;
        }
        [HttpGet(ClientRoutes.ClientGetAll)]
        [ProducesResponseType(200, Type = typeof(List<ClientResponseDTO>))]
        public async Task<IActionResult> GetAll()
        {
            var serviceResponse = await _clientService.GetAll();
            var response = _mapper.Map<List<ClientResponseDTO>>(serviceResponse);
            return Ok(response);
        }
        [HttpGet(ClientRoutes.ClientFindByName)]
        [ProducesResponseType(typeof(ClientResponseDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromRoute] string name)
        {
            var client = await _clientService.GetByName(name);
            var result = _mapper.Map<ClientResponseDTO>(client);
            return Ok(result);
        }
        [HttpGet(ClientRoutes.ClientFindById)]
        [ProducesResponseType(typeof(ClientResponseDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var client = await _clientService.GetById(id);
            var result = _mapper.Map<ClientResponseDTO>(client);
            return Ok(result);
        }
        [HttpPost(ClientRoutes.ClientCreate)]
        [ProducesResponseType(typeof(Client), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post(ClientDTO clientDTO)
        {
            var clientModel = _mapper.Map<Client>(clientDTO);
            var createdModel = await _clientService.AddClient(clientModel);
            var response = new { Model = createdModel, Message = "Successfully created client!" };
            return Ok(response);
        }
        [HttpPut(ClientRoutes.ClientUpdate)]
        [ProducesResponseType(typeof(Client), StatusCodes.Status200OK)]
        public async Task<IActionResult> Put(ClientResponseDTO clientDTO)
        {
            var clientModel = _mapper.Map<Client>(clientDTO);
            var updatedModel = await _clientService.UpdateClient(clientModel);
            var response = new { Model = updatedModel, Message = "Successfully created client!" };
            return Ok(response);
        }
        [HttpDelete(ClientRoutes.ClientDelete)]
        [ProducesResponseType(typeof(Client), StatusCodes.Status200OK)]
        public IActionResult Delete([FromRoute] int id)
        {
            _clientService.DeleteClient(id);
            return Ok("Successfully deleted client!");
        }
    }
}