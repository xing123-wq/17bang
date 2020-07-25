using AutoMapper;
using BLL;
using Repositorys;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProdService
{
    public class BaseService : IBaseService
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
                SQLContext context = HttpContext.Current.Items["dbContext"] as SQLContext;
                if (context == null)
                {
                    context = new SQLContext();
                    context.Database.BeginTransaction();
                    HttpContext.Current.Items["dbContext"] = context;
                }
                return context;
            }
        }
        public User GetByCurrentUser()
        {
            int userId = Convert.ToInt32(HttpContext.Current.Request.Cookies["UserId"].Value);
            string password = HttpContext.Current.Request.Cookies["UserPassword"].Value;
            User user = new User();
            user = _userRepositroy.GetById(userId);
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

        public void Commit()
        {
            using (SQLContext context = HttpContext.Current.Items["dbContext"] as SQLContext)
            {
                if (context != null)
                {
                    DbContextTransaction transaction = context.Database.CurrentTransaction;
                    using (transaction)
                    {
                        try
                        {
                            context.SaveChanges();
                            transaction.Commit();
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
        }
        public void Rollback()
        {
            using (SQLContext context = HttpContext.Current.Items["dbContext"] as SQLContext)
            {
                DbContextTransaction transaction = context.Database.CurrentTransaction;
                using (transaction)
                {
                    transaction.Rollback();
                }
            }
        }

        public void ClearContext()
        {
            HttpContext.Current.Items["dbContext"] = null;
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
                cfg.CreateMap<User, ViewModel.Register.IndexModel>(MemberList.None)
                .ForMember(i => i.UserName, opt => opt.MapFrom(u => u.Name))
                .ForMember(i => i.ConfirmPassword, opt => opt.Ignore())
                .ForMember(i => i.SecurityCode, opt => opt.Ignore())
                .ForMember(i => i.Inviter, opt => opt.Ignore())
                .ForMember(i => i.InviterCode, opt => opt.MapFrom(u => u.InviterCode))
                .ReverseMap()
                .ForMember(u => u.Inviter, opt => opt.Ignore());

                cfg.CreateMap<User, ViewModel.LogOn.IndexModel>(MemberList.None)
                .ForMember(i => i.UserName, opt => opt.MapFrom(u => u.Name))
                .ForMember(i => i.Password, opt => opt.MapFrom(u => u.Password))
                .ForMember(i => i.SecurityCode, opt => opt.Ignore())
                .ForMember(i => i.RememberMe, opt => opt.Ignore())
                .ReverseMap();

                cfg.CreateMap<Advertising, ViewModel.Ad.IndexModel>(MemberList.None)
                .ForMember(i => i.Title, opt => opt.MapFrom(a => a.Title))
                .ForMember(i => i.Url, opt => opt.MapFrom(u => u.Url))
                .ReverseMap();

                cfg.CreateMap<Article, ViewModel.Articles.IndexModel>(MemberList.None)
                .ForMember(i => i.Title, opt => opt.MapFrom(a => a.Title))
                .ForMember(i => i.Body, opt => opt.MapFrom(a => a.Content))
                .ForMember(i => i.Id, opt => opt.MapFrom(a => a.Id))
                .ForMember(i => i.PublishTime, opt => opt.MapFrom(a => a.PublishTime))
                .ForMember(i => i.Keyword, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(a => a.Author, opt => opt.Ignore())
                .ForMember(a => a.Keywords, opt => opt.Ignore())
                .ForMember(a => a.Series, opt => opt.Ignore())
                .ForMember(a => a.Advertising, opt => opt.Ignore());

                cfg.CreateMap<Article, ViewModel.Articles.NewModel>(MemberList.None)
                .ForMember(i => i.Title, opt => opt.MapFrom(a => a.Title))
                .ForMember(i => i.Body, opt => opt.MapFrom(a => a.Content))
                .ForMember(i => i.Keyword, opt => opt.MapFrom(a => a.Keywords.Select(k => k.Keyword)))
                .ForMember(i => i.Series, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(a => a.Series, opt => opt.Ignore());

                cfg.CreateMap<Series, ViewModel.Articles.SeriesModel>(MemberList.None)
                .ForMember(i => i.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(i => i.Body, opt => opt.MapFrom(s => s.Describe))
                .ReverseMap();
            });
#if DEBUG   //复习：这是什么？
            autoMapperConfig.AssertConfigurationIsValid();
#endif
        }
    }
}

