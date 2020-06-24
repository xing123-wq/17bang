using AutoMapper;
using BLL;
using Repositorys;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProdService
{
    public class BaseService
    {
        protected UserRepositroy _userRepositroy;
        public BaseService()
        {
            _userRepositroy = new UserRepositroy(context);
        }
        protected SQLContext context
        {
            get
            {
                if (HttpContext.Current.Items["dbContext"] == null)
                {
                    HttpContext.Current.Items["dbContext"] = new SQLContext();
                }
                return (SQLContext)HttpContext.Current.Items["dbContext"];
            }
        }
        public User GetByCurrentUserId()
        {
            int userId = Convert.ToInt32(HttpContext.Current.Request.Cookies["UserId"].Value);
            string password = HttpContext.Current.Request.Cookies["UserPassword"].Value;
            User user = _userRepositroy.GetById(userId);
            if (user == null)
            {
                throw new Exception($"通过Id:{userId},没有查询到该Id所对应的用户");
            }
            if (password != user.Password)
            {
                throw new Exception("该用户密码错误");
            }
            return user;
        }
        private static MapperConfiguration autoMapperConfig;
        protected IMapper mapper
        {
            get
            {
                return autoMapperConfig.CreateMapper();
            }
        }
        static BaseService()
        {
            autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, ViewModel.Register.IndexModel>()
                .ForMember(i => i.UserName, opt => opt.MapFrom(u => u.Name))
                .ForMember(i => i.ConfirmPassword, opt => opt.Ignore())
                .ForMember(i => i.SecurityCode, opt => opt.Ignore())
                .ForMember(i => i.Inviter, opt => opt.Ignore())
                .ForMember(i => i.InviterCode, opt => opt.MapFrom(u => u.InviterCode))
                .ReverseMap()
                .ForMember(u => u.Inviter, opt => opt.Ignore());

                cfg.CreateMap<User, ViewModel.LogOn.IndexModel>()
                .ForMember(i => i.UserName, opt => opt.MapFrom(u => u.Name))
                .ForMember(i => i.Password, opt => opt.MapFrom(u => u.Password))
                .ForMember(i => i.SecurityCode, opt => opt.Ignore())
                .ForMember(i => i.RememberMe, opt => opt.Ignore())
                .ReverseMap();

            });
#if DEBUG   //复习：这是什么？
            autoMapperConfig.AssertConfigurationIsValid();
#endif
        }
    }
}

