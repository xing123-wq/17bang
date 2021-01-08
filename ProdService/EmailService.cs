using BLL;
using Global;
using Repositorys;
using ServiceInterface.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Email;

namespace ProdService
{
    public class EmailService : BaseService, IEmailService
    {
        private EmailRepository repository;
        private UserRepositroy userRepositroy;
        public EmailService()
        {
            repository = new EmailRepository(context);
            userRepositroy = new UserRepositroy(context);
        }
        public ActivateModel GetActivate()
        {
            Email email = userRepositroy.GetEmail().Email;
            if (email != null)
            {
                if (!string.IsNullOrEmpty(email.Address))
                {
                    return mapper.Map<ActivateModel>(email);
                }
            }
            return null;
        }

        public bool IsDuplicatedOnAddress(string address)
        {
            return repository.IsDuplication(address);
        }

        public bool PassedValidation(ActivateModel model)
        {
            Email current = userRepositroy.GetEmail().Email;
            if (current == null)
            {
                throw new Exception(string.Format(
                    "用户（id={0}）还没有Email，无法验证", current.Id));
            }
            bool result = current.Address == model.Address &&
                current.AuthCode == model.AuthCode;
            if (result)
            {
                current.IsActive = true;
                repository.Update(current);
            }
            return result;
        }

        public EmailValidationResult Send(string address)
        {
            Users current = GetByCurrentUser();
            Email email = null;

            if (string.IsNullOrWhiteSpace(address))
            {
                throw new ArgumentNullException(
                    string.Format("用户（id={0}）发送Email时address为空", current.Id));
            }

            if (current.Email == null)
            {
                email = new Email();
                repository.Add(email);
                current.Email = email;
            }
            else
            {
                email = current.Email;
                //NOTE：已验证不要重复发送
                if (email.Address == address && email.IsActive)
                {
                    return EmailValidationResult.Duplicated;
                }
            }

            email.Address = address;
            email.Send();
            return EmailValidationResult.HasSend;
        }
    }
}
