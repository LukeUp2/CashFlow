using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpensesController : ControllerBase
    {
        [HttpPost]
        public IActionResult Register([FromBody] RequestRegisterExpenseJson request)
        {
            try
            {
                var useCase = new RegisterExpenseUseCase();
                var response = useCase.Execute(request);
                return Created(string.Empty, response);
            }
            catch (ArgumentException ex)
            {
                var errorResponse = new ResponseErrorJson(ex.Message);
                return BadRequest(errorResponse);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro inesperado.");
            }
        }
    }
}