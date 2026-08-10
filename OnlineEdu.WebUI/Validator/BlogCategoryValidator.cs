using FluentValidation;
using OnlineEdu.DTO.DTOS.BlogCategoryDtos;

namespace OnlineEdu.WebUI.Validator
{
    public class BlogCategoryValidator: AbstractValidator<CreateBlogCategoryDto>
    {
        public BlogCategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Blog kategorisi adı boş bırakılamaz.");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Blog kategorisi adı 30 karakterden fazla olamaz.");
        }
    }
}
