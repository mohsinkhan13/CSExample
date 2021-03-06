﻿using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using CS.Accessors.ClientAccessor;
using CS.App.Models;

namespace CS.Api.CentralApi.Controllers
{
    public class ClientController : ApiController
    {
        private readonly IClientAccessor _clientAccessor;
        private readonly IMapper _mapper;

    public ClientController(IClientAccessor accessor, IMapper mapper)
        {
            _clientAccessor = accessor;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClientSupplierAppModel>> GetClientsAsync()
        {
            return await _clientAccessor.GetAllClientsAsync();
        }
         
        public async Task<IHttpActionResult> GetClientAsync(int id)
        {
            var client = await _clientAccessor.GetClientById(id);
            if (client == null) return NotFound();

            return Ok(client);
        }
    }
}