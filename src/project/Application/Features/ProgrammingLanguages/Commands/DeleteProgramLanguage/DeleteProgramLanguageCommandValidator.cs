using FluentValidation;

namespace Application.Features.ProgramLanguages.Commands.DeleteProgramLanguage
{
    public class DeleteProgramLanguageCommandValidator : AbstractValidator<DeleteProgramLanguageCommand>
    {
        public DeleteProgramLanguageCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
        }
    }
}
