﻿using Application.Features.ProgramLanguages.Commands.CreateProgramLanguage;
using Application.Features.ProgramLanguages.Commands.DeleteProgramLanguage;
using Application.Features.ProgramLanguages.Commands.UpdateProgramLanguage;
using Application.Features.ProgramLanguages.Dtos;
using Application.Features.ProgramLanguages.Models;
using Application.Features.ProgramLanguages.Queries.GetByIdProgramLanguage;
using Application.Features.ProgramLanguages.Queries.GetListProgramLanguage;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramLanguagesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgramLanguageCommand createProgramLanguageCommand)
        {
            CreatedProgramLanguageDto result = await Mediator.Send(createProgramLanguageCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgramLanguageQuery getListProgramLanguageQuery = new() { PageRequest = pageRequest };
            ProgramLanguageListModel result = await Mediator.Send(getListProgramLanguageQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgramLanguageQuery getByIdProgramLanguageQuery)
        {
            ProgramLanguageGetByIdDto programLanguageGetByIdDto = await Mediator.Send(getByIdProgramLanguageQuery);
            return Ok(programLanguageGetByIdDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProgramLanguageCommand updateProgramLanguageCommand)
        {
            UpdatedProgramLanguageDto result = await Mediator.Send(updateProgramLanguageCommand);
            return Created("", result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProgramLanguageCommand  deleteProgramLanguageCommand)
        {
            DeletedProgramLanguageDto deletedProgramLanguageDto = await Mediator.Send(deleteProgramLanguageCommand);
            return Ok(deleteProgramLanguageCommand);
        }
    }
}
