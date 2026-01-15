using FluentValidation;
using WebShop_Shared.Model.Binding.ProductModels;
using WebShop_Shared.Model.Dto;
using WebShop_WebApp.Services.Interfaces;

namespace WebShop_WebApp.FluentValidation
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


    public class ProductUpdateBindingValidator : AbstractValidator<ProductUpdateBinding>
    {
        public ProductUpdateBindingValidator(IValidationService validationService)
        {


            RuleFor(x => x.Id)
                .NotEmpty().WithErrorCode(ErrorCodes.MissingValue)
                .MustAsync(async (id, cancellation) => await validationService.ProductExists(id))
                .WithErrorCode(ErrorCodes.NotFound);

            RuleFor(x => x.Name)
                .NotEmpty().WithErrorCode(ErrorCodes.MissingValue)
                .MaximumLength(200).WithErrorCode(ErrorCodes.InvalidLength);

            RuleFor(x => x.Description)
                .NotEmpty().WithErrorCode(ErrorCodes.MissingValue)
                .MaximumLength(1000).WithErrorCode(ErrorCodes.InvalidLength);

            RuleFor(x => x.Price)
                .GreaterThan(0).WithErrorCode(ErrorCodes.OutOfAllowedRange);

            RuleFor(x => x.QuantityTypeId)
                .NotEmpty().WithErrorCode(ErrorCodes.MissingValue)
                .MustAsync(async (id, cancellation) => await validationService.QuantityTypeExists(id))
                .WithErrorCode(ErrorCodes.NotFound);



        }
    }
}
