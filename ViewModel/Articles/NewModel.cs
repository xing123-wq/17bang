﻿using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ViewModel.Ad;
using ViewModel.Category;

namespace ViewModel.Articles
{
    public class NewModel
    {
        public Articles._InputeModel _Inpute { get; set; }
        public IList<_adItmeModel> _Items { get; set; }
        public IList<_SeriesItemMdodel> _Series { get; set; }

    }
  
}
