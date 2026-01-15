using FluentValidation;
using WebShop_Api.Services.Interfaces;
using WebShop_Shared.Model.Binding.ProductModels;
using WebShop_Shared.Model.Dto;

namespace WebShop_Api.FluentValidation
{
    public class ProductCategoryBindingValidator : AbstractValidator<ProductCategoryBinding>
    {
        public ProductCategoryBindingValidator(IValidationService validationService)
        {

            RuleFor(x => x.Name)
                .NotEmpty().WithErrorCode(ErrorCodes.MissingValue)
                .MaximumLength(200).WithErrorCode(ErrorCodes.InvalidLength);


            RuleFor(x => x.Description)
                .NotEmpty().WithErrorCode(ErrorCodes.MissingValue)
                .MaximumLength(1000).WithErrorCode(ErrorCodes.InvalidLength);




        }
    }


    public class ProductCategoryUpdateBindingValidator : AbstractValidator<ProductCategoryUpdateBinding>
    {
        public ProductCategoryUpdateBindingValidator(IValidationService validationService)
        {


            RuleFor(x => x.Id)
                .NotEmpty().WithErrorCode(ErrorCodes.MissingValue)
                .MustAsync(async (id, cancellation) => await validationService.ProductCategoryExists(id))
                .WithErrorCode(ErrorCodes.NotFound);

            RuleFor(x => x.Name)
                .NotEmpty().WithErrorCode(ErrorCodes.MissingValue)
                .MaximumLength(200).WithErrorCode(ErrorCodes.InvalidLength);

            RuleFor(x => x.Description)
                .NotEmpty().WithErrorCode(ErrorCodes.MissingValue)
                .MaximumLength(1000).WithErrorCode(ErrorCodes.InvalidLength);





        }
    }


    public class ProductCategoryIdBindingValidator : AbstractValidator<ProductCategoryIdBinding>
    {
        public ProductCategoryIdBindingValidator(IValidationService validationService)
        {


            RuleFor(x => x.Id)
                .NotEmpty().WithErrorCode(ErrorCodes.MissingValue)
                .MustAsync(async (id, cancellation) => await validationService.ProductCategoryExists(id))
                .WithErrorCode(ErrorCodes.NotFound);

 
        }
    }
}
