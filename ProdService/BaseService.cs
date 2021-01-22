using AutoMapper;
using BLL;
using Global;
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
        protected UserRepositroy UserRepositroy;
        public BaseService()
        {
            UserRepositroy = new UserRepositroy(Context);
        }

        protected SqlContext Context
        {
            get
            {
                var context = HttpContext.Current.Items["dbContext"] as SqlContext;
                if (context == null)
                {
                    context = new SqlContext();
                    context.Database.BeginTransaction();
                    HttpContext.Current.Items["dbContext"] = context;
                }
                return context;
            }
        }
        public Users GetByCurrentUser()
        {
            var cookie = HttpContext.Current.Request.Cookies["UserId"];

            if (cookie == null) return null;

            var userId = Convert.ToInt32(cookie.Value);
            var password = HttpContext.Current.Request.Cookies["UserPassword"]?.Value;
            var user = UserRepositroy.GetById(userId);

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
        public int? CurrentUserId
        {
            get
            {
                var cookie = HttpContext.Current.Request.Cookies["UserId"];

                if (cookie == null) return null;

                var userId = Convert.ToInt32(cookie.Value);
                var password = HttpContext.Current.Request.Cookies["UserPassword"]?.Value;
                var user = UserRepositroy.GetById(userId);

                if (user == null)
                {
                    throw new Exception($"通过Id:{userId},没有查询到该Id所对应的用户");
                }
                if (password != user.Password)
                {
                    throw new Exception("该用户密码错误");
                }

                return userId;
            }
        }
        public void Commit()
        {
            using (var context = HttpContext.Current.Items["dbContext"] as SqlContext)
            {
                if (context != null)
                {
                    var transaction = context.Database.CurrentTransaction;
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
            using (var context = HttpContext.Current.Items["dbContext"] as SqlContext)
            {
                if (context == null) return;
                var transaction = context.Database.CurrentTransaction;
                using (transaction)
                {
                    transaction.Rollback();
                }
            }
        }
        public bool IsAdmin()
        {
            return GetByCurrentUser().Role == Role.Admin;
        }
        public bool IsBlogger()
        {
            return GetByCurrentUser().Role == Role.Blogger || IsAdmin();
        }

        public Role GetCurrentRole()
        {
            return GetByCurrentUser().Role;
        }
        public void ClearContext()
        {
            HttpContext.Current.Items["dbContext"] = null;
        }

        private protected static readonly MapperConfiguration AutoMapperConfig;
        protected IMapper Mapper => AutoMapperConfig.CreateMapper();

        /// <summary>
        /// model和entity映射
        /// </summary>
        static BaseService()
        {
            AutoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Users, ViewModel.Register.IndexModel>(MemberList.None)
                .ForMember(i => i.UserName, opt => opt.MapFrom(u => u.Name))
                .ForMember(i => i.ConfirmPassword, opt => opt.Ignore())
                .ForMember(i => i.SecurityCode, opt => opt.Ignore())
                .ForMember(i => i.Inviter, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(u => u.Inviter, opt => opt.Ignore());

                cfg.CreateMap<Users, ViewModel.LogOn.IndexModel>(MemberList.None)
                .ForMember(i => i.UserName, opt => opt.MapFrom(u => u.Name))
                .ForMember(i => i.Password, opt => opt.MapFrom(u => u.Password))
                .ForMember(i => i.SecurityCode, opt => opt.Ignore())
                .ForMember(i => i.RememberMe, opt => opt.Ignore())
                .ReverseMap();

                cfg.CreateMap<Users, ViewModel.Shared._UserModel>(MemberList.None)
                ;

                cfg.CreateMap<AdInWidget, ViewModel.Ad.IndexModel>(MemberList.None)
                .ReverseMap();

                cfg.CreateMap<AdInWidget, ViewModel.Ad._adItmeModel>(MemberList.None)
                .ReverseMap();

                cfg.CreateMap<Appraise, ViewModel.Shared.AppraiseManagerModel>(MemberList.None)
                    .ReverseMap();

                cfg.CreateMap<Article, ViewModel.Articles._SingleItemModel>(MemberList.None)
                .ForMember(m => m.CategoryId, opt => opt.MapFrom(a => a.Series.Id))
                .ForMember(m => m.Keywords, opt => opt.MapFrom(a => a.Keywords))
                .ForMember(m => m.Body, opt => opt.MapFrom(a => a.Body));

                cfg.CreateMap<ArticleAndKeyword, ViewModel.Shared.ArticleAndKeywordModel>(MemberList.None)
                .ForMember(m => m._Keyword, opt => opt.MapFrom(k => k.Keyword))
                .ForMember(m => m._Article, opt => opt.MapFrom(k => k.Article));

                cfg.CreateMap<Keyword, ViewModel.Shared._KeywordModel>(MemberList.None)
                .ForMember(m => m.articles, opt => opt.MapFrom(k => k.Articles));

                cfg.CreateMap<Article, ViewModel.Articles._PreAndNextModel>(MemberList.None);

                cfg.CreateMap<Article, ViewModel.Articles.LiteTitleModel>(MemberList.None);


                cfg.CreateMap<Article, ViewModel.Shared.Article._WidgetModel>(MemberList.None);


                cfg.CreateMap<Article, ViewModel.Articles.InputeModel>(MemberList.None);

                cfg.CreateMap<AdInWidget, ViewModel.Shared.EditorTemplates.AdContentModel>(MemberList.None);


                cfg.CreateMap<Email, ViewModel.Email.ActivateModel>(MemberList.None);


                cfg.CreateMap<BLL.Category, ViewModel.Category.ManageModel>(MemberList.None)
                .ReverseMap();

                cfg.CreateMap<BLL.Category, ViewModel.Category.InputModel>(MemberList.None)
                .ReverseMap();

                cfg.CreateMap<BLL.Category, ViewModel.Category.SeriesItemMdodel>(MemberList.None)
                .ReverseMap();

                cfg.CreateMap<Chat, ViewModel.Chat.ChatItemModel>(MemberList.None)
                .ForMember(v => v.ChatAuthorId, opt => opt.MapFrom(c => c.AuthorId))
                .ForMember(v => v.Content, opt => opt.MapFrom(c => c.Content))
                .ForMember(v => v.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(v => v.PublishTime, opt => opt.MapFrom(c => c.PublishTime))
                .ForMember(v => v.ReplyId, opt => opt.MapFrom(c => c.ReplyId))
                .ReverseMap();
            });
#if DEBUG   //复习：这是什么？
            AutoMapperConfig.AssertConfigurationIsValid();
#endif
        }
    }
}

