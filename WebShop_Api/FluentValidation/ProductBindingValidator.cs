using FluentValidation;
using WebShop_Api.Services.Interfaces;
using WebShop_Shared.Model.Binding.ProductModels;
using WebShop_Shared.Model.Dto;

namespace WebShop_Api.FluentValidation
{
    public class ProductBindingValidator : AbstractValidator<ProductBinding>
    {
        public ProductBindingValidator(IValidationService validationService)
        {

            RuleFor(x => x.Name)
                .NotEmpty().WithErrorCode(ErrorCodes.MissingValue)
                .MaximumLength(200).WithErrorCode(ErrorCodes.InvalidLength);


            RuleFor(x => x.Description)
                .NotEmpty().WithErrorCode(ErrorCodes.MissingValue)
                .MaximumLength(1000).WithErrorCode(ErrorCodes.InvalidLength);

            RuleFor(x => x.Price)
                .GreaterThan(0).WithErrorCode(ErrorCodes.OutOfAllowedRange);

            RuleFor(x => x.ProductCategoryId)
                .NotEmpty().WithErrorCode(ErrorCodes.MissingValue)
                .MustAsync(async (id, cancellation) => await validationService.ProductCategoryExists(id))
                .WithErrorCode(ErrorCodes.NotFound);

            RuleFor(x => x.QuantityTypeId)
                .NotEmpty().WithErrorCode(ErrorCodes.MissingValue)
                .MustAsync(async (id, cancellation) => await validationService.QuantityTypeExists(id))
                .WithErrorCode(ErrorCodes.NotFound);



        }
    }
}
