﻿using Application.Features.ProgramLanguages.Commands.CreateProgramLanguage;
using Application.Features.ProgramLanguages.Commands.DeleteProgramLanguage;
using Application.Features.ProgramLanguages.Commands.UpdateProgramLanguage;
using Application.Features.ProgramLanguages.Dtos;
using Application.Features.ProgramLanguages.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.ProgramLanguages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgrammingLanguage, CreatedProgramLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, CreateProgramLanguageCommand>().ReverseMap();
            CreateMap<IPaginate<ProgrammingLanguage>, ProgramLanguageListModel>().ReverseMap();
            CreateMap<ProgrammingLanguage, ProgramLanguageListDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, ProgramLanguageGetByIdDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, UpdatedProgramLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, UpdateProgramLanguageCommand>().ReverseMap();
            CreateMap<ProgrammingLanguage, DeletedProgramLanguageDto>().ReverseMap();
        }
    }
}
