﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Article;

namespace ServiceInterface.Article
{
    public interface INewArticleService
    {
        int Publish(IndexModel model);

    }
}