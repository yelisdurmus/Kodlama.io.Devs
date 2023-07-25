using Application.Features.ProgramLanguages.Dtos;
using Application.Features.ProgramLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgramLanguages.Commands.UpdateProgramLanguage
{
    public class UpdateProgramLanguageCommand : IRequest<UpdatedProgramLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateProgramLanguageCommandHandler : IRequestHandler<UpdateProgramLanguageCommand, UpdatedProgramLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgramLanguageBusinessRules _programLanguageBusinessRules;

            public UpdateProgramLanguageCommandHandler(IProgrammingLanguageRepository programLanguageRepository, IMapper mapper, ProgramLanguageBusinessRules programLanguageBusinessRules)
            {
                _programLanguageRepository = programLanguageRepository;
                _mapper = mapper;
                _programLanguageBusinessRules = programLanguageBusinessRules;
            }

            public async Task<UpdatedProgramLanguageDto> Handle(UpdateProgramLanguageCommand request, CancellationToken cancellationToken)
            {
                await _programLanguageBusinessRules.ProgramLanguageNameCanNotBeDuplicatedWhenUpdated(request.Id, request.Name);

                ProgrammingLanguage mappedProgramLanguage = _mapper.Map<ProgrammingLanguage>(request);
                ProgrammingLanguage updatedProgramLanguage = await _programLanguageRepository.UpdateAsync(mappedProgramLanguage);
                UpdatedProgramLanguageDto updatedProgramLanguageDto = _mapper.Map<UpdatedProgramLanguageDto>(updatedProgramLanguage);

                return updatedProgramLanguageDto;
            }
        }
    }
}