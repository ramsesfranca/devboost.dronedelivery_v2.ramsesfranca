﻿using DroneDelivery.Application.Commands.Drones;
using DroneDelivery.Application.Models;
using DroneDelivery.Application.Queries.Drones;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneDelivery.Api.Controllers
{
    [Authorize]
    public class DroneController : BaseController
    {
        public DroneController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<DroneModel>>> ObterTodos()
        {
            var response = await this._mediator.Send(new ListarDronesQuery());

            return response.HasFails
                ? (ActionResult<IEnumerable<DroneModel>>)BadRequest(response.Fails)
                : Ok(response.Data);
        }

        [AllowAnonymous]
        [HttpGet("situacao")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<DroneSituacaoModel>>> ObterSituacaoDrones()
        {
            var response = await this._mediator.Send(new ListarSituacaoDronesQuery());

            return response.HasFails
                ? (ActionResult<IEnumerable<DroneSituacaoModel>>)BadRequest(response.Fails)
                : Ok(response.Data);
        }

        /// <summary>
        /// Criar um drone
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/drone
        ///     {
        ///         "capacidade": 12000,
        ///         "velocidade": 3.33333,
        ///         "autonomia": 35,
        ///         "carga": 60
        ///     }
        ///
        /// </remarks>        
        /// <param name="command"></param>  
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Adicionar(CriarDroneCommand command)
        {
            var response = await this._mediator.Send(command);

            return response.HasFails ? (IActionResult)BadRequest(response.Fails) : Ok();
        }
    }
}
