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
using ViewModel.Register;

namespace ProdService
{
    public class BaseService
    {
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
                cfg.CreateMap<User, IndexModel>()
                .ForMember(i => i.UserName, opt => opt.MapFrom(u => u.Name))
                .ForMember(i => i.ConfirmPassword, opt => opt.Ignore())
                .ForMember(i => i.SecurityCode, opt => opt.Ignore())
                .ForMember(i => i.Inviter, opt => opt.Ignore())
                .ForMember(i => i.InviterCode, opt => opt.MapFrom(u => u.InviterCode))
                .ReverseMap()
                .ForMember(u => u.Inviter, opt => opt.Ignore());
            });
#if DEBUG   //复习：这是什么？
            autoMapperConfig.AssertConfigurationIsValid();
#endif
        }
    }
}

