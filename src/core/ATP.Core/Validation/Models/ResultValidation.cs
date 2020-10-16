using System;
using System.Collections.Generic;
using System.Text;

namespace ATP.Core.Validation.Models
{
    public class ResultValidation
    {
        public virtual bool EhValido { get; set; }
        
        public IEnumerable<ErrorsValidation> Errors { get; set; }        
    }
}
