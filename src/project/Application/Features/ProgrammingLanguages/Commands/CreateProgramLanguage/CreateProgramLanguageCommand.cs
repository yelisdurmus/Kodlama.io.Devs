using Application.Features.ProgramLanguages.Dtos;
using Application.Features.ProgramLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgramLanguages.Commands.CreateProgramLanguage
{
    public class CreateProgramLanguageCommand : IRequest<CreatedProgramLanguageDto>
    {
        public string Name { get; set; }

        public class CreateProgramLanguageCommandHandler : IRequestHandler<CreateProgramLanguageCommand, CreatedProgramLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _ProgramLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgramLanguageBusinessRules _ProgramLanguageBusinessRules;

            public CreateProgramLanguageCommandHandler(IProgrammingLanguageRepository ProgramLanguageRepository, IMapper mapper, ProgramLanguageBusinessRules ProgramLanguageBusinessRules)
            {
                _ProgramLanguageRepository = ProgramLanguageRepository;
                _mapper = mapper;
                _ProgramLanguageBusinessRules = ProgramLanguageBusinessRules;
            }

            public async Task<CreatedProgramLanguageDto> Handle(CreateProgramLanguageCommand request, CancellationToken cancellationToken)
            {
                await _ProgramLanguageBusinessRules.ProgramLanguageNameCanNotBeDuplicatedWhenInserted(request.Name);

                ProgrammingLanguage mappedProgramLanguage = _mapper.Map<ProgrammingLanguage>(request);
                ProgrammingLanguage createdProgramLanguage = await _ProgramLanguageRepository.AddAsync(mappedProgramLanguage);
                CreatedProgramLanguageDto createdProgramLanguageDto = _mapper.Map<CreatedProgramLanguageDto>(createdProgramLanguage);

                return createdProgramLanguageDto;
            }
        }
    }
}