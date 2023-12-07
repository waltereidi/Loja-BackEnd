﻿using Dominio.loja.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Attributes
{
    [AttributeUsage(AttributeTargets.Field  | AttributeTargets.Property, AllowMultiple = true)]
    public class ExcelValidationAttributes : Attribute
    {
        public ExcelValidation Validation { get; set; }
        public string? ValidationParameters { get; set; }
        public int MaxLength { get; set; }
        public int MinLength { get; set; }

        public ExcelValidationAttributes(ExcelValidation validation , string? validationParameter )
        {
            Validation = validation;
            ValidationParameters = validationParameter;
        }
        public ExcelValidationAttributes(ExcelValidation validation, int minLen, int maxLen) 
        {
            if (validation != ExcelValidation.StringLength)
                throw new InvalidOperationException("This constructor can only be used by StringLength");

            if (minLen >= maxLen)
                throw new InvalidDataException("minLen must be smaller or equals than maxLen");
            

            Validation = validation;
            MinLength = minLen;
            MaxLength = maxLen;
        }
        public ExcelValidationAttributes(ExcelValidation validation)
        {
            if (validation != ExcelValidation.IsNumber && validation != ExcelValidation.Required)
                throw new InvalidDataException("Only IsNumber and Required can be provided to this constructor");

            Validation = validation;
        }

        public Tuple<bool , string> StringLength(string value)
        {
            

            if(MinLength >= 0 && MaxLength >= 0 || MinLength <=  MaxLength )
            {
                Tuple<bool , string> invalidatedString = new Tuple<bool, string>(false, $"String must be smaller than {MinLength} and bigger than {MaxLength}");

                return ( value.Length >= MinLength && value.Length <= MaxLength) ? new Tuple<bool, string>(true, "") : invalidatedString; 
            }
            else
            {
                return new Tuple<bool, string>(false, "Invalid Constructor of method, parameters not set at attribute declaration");
                throw new InvalidDataException("minLen and maxLen must be setted , maxLen must be bigger than minLen and the provided value must be a string");
            }

        }
        public Tuple<bool , string> IsNumber(string value)
        {
            int numberValue = 0;
            if (int.TryParse(value, out numberValue))
            {
                return new Tuple<bool, string>(true , "");
            }
            else
            {
                return new Tuple<bool, string>(false, "Invalid number");
            }
        }

        public Tuple<bool , string> Required(string value)
        {
            if(value.IsNullOrEmpty())
            {
                return new Tuple<bool, string>(false, "This value cannot be not empty");
            }else
            {
                return new Tuple<bool, string>(true , "");
            }

            
        }

        public Tuple<bool , string> DateTimeFormat(string value)
        {
            return new Tuple<bool, string>(false, "");
        }
    }
}
