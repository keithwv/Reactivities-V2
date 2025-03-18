using Application.Activities.Commands;
using Application.Activities.DTOs;
using Application.Activities.Valiators;
using FluentValidation;

namespace Application.Validators;

public class EditActivityValidator : BaseActivityValidator<EditActivity.Command, EditActivityDto>
{
    public EditActivityValidator() : base(x => x.ActivityDto)
    {
        RuleFor(x => x.ActivityDto.Id)
            .NotEmpty().WithMessage("Id is required");
        
    }
}