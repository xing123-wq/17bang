using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    public sealed class AtRequiredAttrbute : RequiredAttribute
    {
        public override string FormatErrorMessage(string name) => $"* {(object)name}不能为空";
    }
}
