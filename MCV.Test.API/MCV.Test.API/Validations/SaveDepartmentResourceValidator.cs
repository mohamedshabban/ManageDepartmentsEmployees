using FluentValidation;
using MCV.Test.API.Data.Dtos;

namespace MCV.Test.API.Validations
{
    public class SaveDepartmentResourceValidator : AbstractValidator<SaveDepartmentResource>
    {
        public SaveDepartmentResourceValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .MaximumLength(50);           
        }
    }
}
