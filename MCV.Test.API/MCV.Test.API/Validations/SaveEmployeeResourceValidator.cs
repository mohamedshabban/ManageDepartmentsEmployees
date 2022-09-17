using FluentValidation;
using MCV.Test.API.Data.Dtos;

namespace MCV.Test.API.Validations
{
    public class SaveEmployeeResourceValidator : AbstractValidator<SaveEmployeeResource>
    {
        public SaveEmployeeResourceValidator()
        {
            //RuleFor(m => m.Name)
            //    .NotEmpty()
            //    .MaximumLength(50);

            //RuleFor(m => m.DepartmentId)
            //    .NotEmpty()
            //    .WithMessage("'Department Id' must not be 0.");
        }
    }
}
