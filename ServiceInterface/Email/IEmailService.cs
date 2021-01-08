using Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Email;

namespace ServiceInterface.Email
{
    public interface IEmailService
    {
        ActivateModel GetActivate();
        EmailValidationResult Send(string address);
        bool IsDuplicatedOnAddress(string address);
        bool PassedValidation(ActivateModel model);
    }
}
