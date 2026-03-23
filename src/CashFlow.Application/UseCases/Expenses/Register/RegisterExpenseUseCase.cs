using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Register
{
    public class RegisterExpenseUseCase
    {
        public ResponseRegisterExpenseJson Execute(RequestRegisterExpenseJson request)
        {
            Validate(request);

            return new ResponseRegisterExpenseJson
            {
                Title = request.Title
            };
        }

        private static void Validate(RequestRegisterExpenseJson request)
        {
            var result = new RegisterExpenseUseCaseValidator().Validate(request);

            if (result.IsValid is false)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ArgumentException(string.Join("; ", errors));
            }
        }
    }
}