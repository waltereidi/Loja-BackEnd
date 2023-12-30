﻿using Api.loja.Data;
using Api.loja.Services;
using Dominio.loja.Dto.CustomEntities;
using Dominio.loja.Dto.Models;
using Dominio.loja.Dto.Requests;
using Dominio.loja.Entity;
using Dominio.loja.Interfaces;
using Dominio.loja.Interfaces.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.loja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreClientsController : BaseController
    {
        public StoreClientsController(ILogger<StoreClientsController> logger  ) : base(logger)
        {
        }
        
        [HttpGet]
        [Authorize]
        public IActionResult GetEditMyProfile([FromHeader]int ID_Clients)
        {

            return Ok();
        }

        [HttpPut]
        [Authorize]
        public IActionResult PutEditMyProfile([FromBody] Clients dataSource)
        {

            return Ok();
        }
        [HttpGet]
        [Authorize]
        public IActionResult GetOrdersRequest([FromHeader] int ID_Clients )
        {
            return Ok();

        }
        [HttpPost]
        [Authorize]
        public IActionResult PostOrdersRequest([FromBody] int dataSource )
        {
            return Ok();
        }

        [HttpPut]
        [Authorize]
        public IActionResult PutCartProducts()
        {
            return Ok();
        }
        [HttpDelete]
        [Authorize]
        public IActionResult DeleteCartProducts()
        {
            return Ok();
        }
        [HttpDelete]
        [Authorize]
        public IActionResult GetCartProducts()
        {
            return Ok();
        }

        // GET: StoreClientsController
     }
}
