using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models
{
    public class MyValidationAttribute : ValidationAttribute
    {
        public MyValidationAttribute() : base("MyValidation")
        {
            ErrorMessage = "此欄位必須為偶數";
        }


        public override bool IsValid(object value)
        {
            if(value == null)
            { return true; }

            var num = 0;
            int.TryParse(value.ToString(),out num);

            if(num % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}