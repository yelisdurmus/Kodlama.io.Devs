using FluentValidation;

namespace Application.Features.ProgramLanguages.Commands.CreateProgramLanguage
{
    public class CreateProgramLanguageCommandValidator : AbstractValidator<CreateProgramLanguageCommand>
    {
        public CreateProgramLanguageCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).MinimumLength(1);
        }
    }
}
