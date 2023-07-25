
using Application.Features.ProgramLanguages.Dtos;
using Application.Features.ProgramLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgramLanguages.Queries.GetByIdProgramLanguage
{
    public class GetByIdProgramLanguageQuery : IRequest<ProgramLanguageGetByIdDto>
    {
        public int Id { get; set; }
        public class GetByIdProgramLanguageQueryHandler : IRequestHandler<GetByIdProgramLanguageQuery, ProgramLanguageGetByIdDto>
        {
            private readonly IProgrammingLanguageRepository _programLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgramLanguageBusinessRules _programLanguageBusinessRules;

            public GetByIdProgramLanguageQueryHandler(IProgrammingLanguageRepository programLanguageRepository, IMapper mapper, ProgramLanguageBusinessRules programLanguageBusinessRules)
            {
                _programLanguageRepository = programLanguageRepository;
                _mapper = mapper;
                _programLanguageBusinessRules = programLanguageBusinessRules;
            }

            public async Task<ProgramLanguageGetByIdDto> Handle(GetByIdProgramLanguageQuery request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage? programLanguage = await _programLanguageRepository.GetAsync(b => b.Id == request.Id);

                _programLanguageBusinessRules.ProgramLanguageShouldExistWhenRequested(programLanguage);

                ProgramLanguageGetByIdDto programLanguageGetByIdDto = _mapper.Map<ProgramLanguageGetByIdDto>(programLanguage);
                return programLanguageGetByIdDto;
            }
        }
    }
}
