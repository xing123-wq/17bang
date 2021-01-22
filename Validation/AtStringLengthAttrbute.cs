using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    public class AtStringLengthAttrbute:StringLengthAttribute
    {
        public AtStringLengthAttrbute(int maximumLength) : base(maximumLength)
        {
        }

        public override string FormatErrorMessage(string name)
        {
            if (this.MinimumLength == this.MaximumLength)
                return $"* {(object) name}的长度只能等于{(object) this.MinimumLength}";
            
            return this.MinimumLength == 0 ? $"* {(object) name}的长度不能大于{(object) this.MaximumLength}"
                : $"* {(object) name}的长度不能小于{(object) this.MinimumLength}，大于{(object) this.MaximumLength}";
        }
    }
}
