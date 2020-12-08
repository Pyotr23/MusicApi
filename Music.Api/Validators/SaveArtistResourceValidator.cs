using FluentValidation;
using Music.Api.Resources;

namespace Music.Api.Validators
{
    public class SaveArtistResourceValidator : AbstractValidator<SaveArtistResource>
    {
        public SaveArtistResourceValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .MaximumLength(50);                
        }
    }
}
