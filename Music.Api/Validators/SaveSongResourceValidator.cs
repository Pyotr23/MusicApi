using FluentValidation;
using Music.Api.Resources;

namespace Music.Api.Validators
{
    public class SaveSongResourceValidator : AbstractValidator<SaveSongResource>
    {
        public SaveSongResourceValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(a => a.ArtistId)
                .NotEmpty()
                .WithMessage("\"Artist Id\" must not be 0.");
        }
    }
}
