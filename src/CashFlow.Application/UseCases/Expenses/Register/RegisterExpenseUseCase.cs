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
            var titleIsEmpty = string.IsNullOrWhiteSpace(request.Title);
            if (titleIsEmpty)
            {
                throw new ArgumentException("O título da despesa é obrigatório.");
            }

            if (request.Amount <= 0)
            {
                throw new ArgumentException("O valor da despesa deve ser maior que zero.");
            }

            var result = DateTime.Compare(request.Date, DateTime.UtcNow);
            if (result > 0)
            {
                throw new ArgumentException("A data da despesa não pode ser no futuro.");
            }

            var paymentTypeIsValid = Enum.IsDefined(typeof(Communication.Enuns.PaymentType), request.PaymentType);
            if (!paymentTypeIsValid)
            {
                throw new ArgumentException("O tipo de pagamento é inválido.");
            }
        }
    }
}