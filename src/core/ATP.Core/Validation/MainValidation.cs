using ATP.Core.Validation.Models;
using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ATP.Core.Validation
{
    public abstract class MainValidation<T> : AbstractValidator<T> where T : class
    {
        protected async Task<ResultValidation> ValidarAsync(T obj)
        {
            var validation = await ValidateAsync(obj);

            return BindValidation(validation);
        }

        private ResultValidation BindValidation(ValidationResult validation)
        {
            return new ResultValidation
            {
                EhValido = validation.IsValid,
                Errors = validation.Errors == null ? null : BindErrors(validation.Errors)
            };
        }

        private IEnumerable<ErrorsValidation> BindErrors(IList<ValidationFailure> errors)
        {
            foreach (var item in errors)
            {
                yield return new ErrorsValidation
                {
                    Mensagem = item.ErrorMessage,
                    NomePropriedade = item.PropertyName,
                    ValorInformado = item.AttemptedValue
                };
            }
        }
    }
}
