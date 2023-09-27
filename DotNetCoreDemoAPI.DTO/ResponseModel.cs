using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfucareRx.PatientHealthApp.DTO
{
    public class ResponseModel<T>
    {
        public string? Message { get; set; }
        public bool Success { get; set; }
        public T? Date { get; set; }
    }
}
