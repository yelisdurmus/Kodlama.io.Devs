using FluentValidation;

namespace Application.Features.ProgramLanguages.Commands.UpdateProgramLanguage
{
    public class UpdateProgramLanguageCommandValidator : AbstractValidator<UpdateProgramLanguageCommand>
    {
        public UpdateProgramLanguageCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).MinimumLength(1);
        }
    }
}
