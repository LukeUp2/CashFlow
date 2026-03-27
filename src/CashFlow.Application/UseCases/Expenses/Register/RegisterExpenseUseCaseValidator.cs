using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CashFlow.Communication.Requests;
using CashFlow.Exception;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses.Register
{
    public class RegisterExpenseUseCaseValidator : AbstractValidator<RequestRegisterExpenseJson>
    {
        public RegisterExpenseUseCaseValidator()
        {
            RuleFor(expense => expense.Title)
                .NotEmpty().WithMessage(ResourceErrorMessage.TITLE_REQUIRED);

            RuleFor(expense => expense.Amount)
                .GreaterThan(0).WithMessage(ResourceErrorMessage.AMOUNT_MUST_BE_GREATHER_THAN_ZERO);

            RuleFor(expense => expense.Date)
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage(ResourceErrorMessage.EXPENSES_CANNOT_BE_IN_FUTURE);

            RuleFor(expense => expense.PaymentType)
                .IsInEnum().WithMessage(ResourceErrorMessage.INVALID_PAYMENT);
        }
    }
}