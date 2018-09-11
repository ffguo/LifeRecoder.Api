using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LifeRecoder.Domain.Validations
{
    public class SplitAttribute : ValidationAttribute
    {
        private readonly string _splitType;

        private readonly string[] _exculdSplitType = new string[] { " ", ".", "，", "-", "'", "\"" };

        public SplitAttribute(string splitType)
        {
            _splitType = splitType;
            ErrorMessage = "请用[" + _splitType + "]分割";
        }

        public override bool IsValid(object value)
        {
            //if (!value.ToString().Contains(_splitType))
                //return false;
            return true;
        }
    }
}
