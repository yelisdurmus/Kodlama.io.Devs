using Application.Features.ProgramLanguages.Dtos;
using Application.Features.ProgramLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgramLanguages.Commands.DeleteProgramLanguage
{
    public class DeleteProgramLanguageCommand : IRequest<DeletedProgramLanguageDto>
    {
        public int Id { get; set; }

        public class DeleteProgramLanguageCommandHandler : IRequestHandler<DeleteProgramLanguageCommand, DeletedProgramLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgramLanguageBusinessRules _programLanguageBusinessRules;

            public DeleteProgramLanguageCommandHandler(IProgrammingLanguageRepository programLanguageRepository, IMapper mapper, ProgramLanguageBusinessRules programLanguageBusinessRules)
            {
                _programLanguageRepository = programLanguageRepository;
                _mapper = mapper;
                _programLanguageBusinessRules = programLanguageBusinessRules;
            }

            public async Task<DeletedProgramLanguageDto> Handle(DeleteProgramLanguageCommand request, CancellationToken cancellationToken)
            {
                await _programLanguageBusinessRules.ProgramLanguageNameCanNotBeWhenDeleted(request.Id);

                ProgrammingLanguage getProgramLanguage = _programLanguageRepository.Get(b => b.Id == request.Id); ;
                ProgrammingLanguage deletedProgramLanguage = await _programLanguageRepository.DeleteAsync(getProgramLanguage);
                DeletedProgramLanguageDto deletedProgramLanguageDto = _mapper.Map<DeletedProgramLanguageDto>(deletedProgramLanguage);

                return deletedProgramLanguageDto;
            }
        }
    }
}