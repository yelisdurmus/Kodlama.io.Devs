using Application.Features.ProgramLanguages.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgramLanguages.Queries.GetListProgramLanguage
{
    public class GetListProgramLanguageQuery : IRequest<ProgramLanguageListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListProgramLanguageQueryHandler : IRequestHandler<GetListProgramLanguageQuery, ProgramLanguageListModel>
        {
            private readonly IProgrammingLanguageRepository _programLanguageRepository;
            private readonly IMapper _mapper;

            public GetListProgramLanguageQueryHandler(IProgrammingLanguageRepository programLanguageRepository, IMapper mapper)
            {
                _programLanguageRepository = programLanguageRepository;
                _mapper = mapper;
            }

            public async Task<ProgramLanguageListModel> Handle(GetListProgramLanguageQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProgrammingLanguage> programLanguages = await _programLanguageRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                ProgramLanguageListModel mappedProgramLanguageListModel = _mapper.Map<ProgramLanguageListModel>(programLanguages);
                return mappedProgramLanguageListModel;
            }
        }
    }
}
