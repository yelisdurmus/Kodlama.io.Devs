using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.ProgramLanguages.Rules
{
    public class ProgramLanguageBusinessRules
    {
        private readonly IProgrammingLanguageRepository _programLanguageRepository;

        public ProgramLanguageBusinessRules(IProgrammingLanguageRepository programLanguageRepository)
        {
            _programLanguageRepository = programLanguageRepository;
        }

        public async Task ProgramLanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgrammingLanguage> result = await _programLanguageRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Program Language name exists.");
        }

        public void ProgramLanguageShouldExistWhenRequested(ProgrammingLanguage ProgramLanguage)
        {
            if (ProgramLanguage == null) throw new BusinessException("Requested program language does not exist.");
        }

        public async Task ProgramLanguageNameCanNotBeDuplicatedWhenUpdated(int id, string name)
        {
            IPaginate<ProgrammingLanguage> result = await _programLanguageRepository.GetListAsync(b => b.Name == name && b.Id != id);
            if (result.Items.Any()) throw new BusinessException("Program Language name exists.");
        }

        public async Task ProgramLanguageNameCanNotBeWhenDeleted(int id)
        {
            IPaginate<ProgrammingLanguage> result = await _programLanguageRepository.GetListAsync(b => b.Id == id);
            if (!result.Items.Any()) throw new BusinessException("Program Language exists.");
        }
    }
}
