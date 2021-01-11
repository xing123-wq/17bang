﻿using AutoMapper;
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
        public Users GetByCurrentUser()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["UserId"];
            if (cookie != null)
            {
                int userId = Convert.ToInt32(cookie.Value);
                string password = HttpContext.Current.Request.Cookies["UserPassword"].Value;
                Users user = new Users();
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
            return null;
        }
        public int? CurrentUserId
        {
            get
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["UserId"];
                if (cookie != null)
                {
                    int userId = Convert.ToInt32(cookie.Value);
                    string password = HttpContext.Current.Request.Cookies["UserPassword"].Value;
                    Users user = _userRepositroy.GetById(userId);
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
                return null;
            }
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
        public bool IsAdmin()
        {
            if (GetByCurrentUser().Role == Role.Admin)
            {
                return true;
            }//eles do nothing
            return false;
        }
        public bool IsBlogger()
        {
            if (GetByCurrentUser().Role == Role.Blogger || IsAdmin())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Role GetCurrentRole()
        {
            return GetByCurrentUser().Role;
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

        /// <summary>
        /// model和entity映射
        /// </summary>
        static BaseService()
        {
            autoMapperConfig = new MapperConfiguration(cfg =>
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

                cfg.CreateMap<Advertising, ViewModel.Ad.IndexModel>(MemberList.None)
                .ForMember(i => i.Title, opt => opt.MapFrom(a => a.Title))
                .ForMember(i => i.Url, opt => opt.MapFrom(u => u.Url))
                .ReverseMap();

                cfg.CreateMap<Advertising, ViewModel.Ad._adItmeModel>(MemberList.None)
                .ReverseMap();

                cfg.CreateMap<Article, ViewModel.Articles._SingleItemModel>(MemberList.None)
                .ForMember(m => m.CategoryId, opt => opt.MapFrom(a => a.Series.Id))
                .ForMember(i => i.Keywords, opt => opt.MapFrom(a => a.Keywords));

                cfg.CreateMap<ArticleAndKeyword, ViewModel.Shared.ArticleAndKeywordModel>(MemberList.None)
                .ForMember(m => m._Keyword, opt => opt.MapFrom(k => k.Keyword))
                .ForMember(m => m._Article, opt => opt.MapFrom(k => k.Article));

                cfg.CreateMap<Keyword, ViewModel.Shared._KeywordModel>(MemberList.None)
                .ForMember(m => m.articles, opt => opt.MapFrom(k => k.Articles));


                cfg.CreateMap<Article, ViewModel.Articles.NewModel>(MemberList.None)
                .ForMember(n => n._Items, opt => opt.Ignore())
                .ForMember(n => n._Series, opt => opt.Ignore());

                cfg.CreateMap<Article, ViewModel.Articles._PreAndNextModel>(MemberList.None);

                cfg.CreateMap<Article, ViewModel.Articles.LiteTitleModel>(MemberList.None);


                cfg.CreateMap<Article, ViewModel.Shared.Article._WidgetModel>(MemberList.None);


                cfg.CreateMap<Article, ViewModel.Articles._InputeModel>(MemberList.None)
                .ForMember(m => m.Interlinkage, opt => opt.MapFrom(a => a.Advertising.Url))
                .ForMember(m => m.text, opt => opt.MapFrom(a => a.Advertising.Title))
                .ForMember(m => m.Body, opt => opt.MapFrom(a => a.Content))
                .ReverseMap();

                cfg.CreateMap<Email, ViewModel.Email.ActivateModel>(MemberList.None);


                cfg.CreateMap<Series, ViewModel.Category.ManageModel>(MemberList.None)
                .ReverseMap();

                cfg.CreateMap<Series, ViewModel.Category._InputModel>(MemberList.None)
                .ReverseMap();

                cfg.CreateMap<Series, ViewModel.Category._SeriesItemMdodel>(MemberList.None)
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
            autoMapperConfig.AssertConfigurationIsValid();
#endif
        }
    }
}

