﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    internal class Problem : Content
    {
        public Problem(string kind) : base(kind) { }
        internal string Title { get; set; }
        public string Body { get; set; }
        public int _reward;
        public int Reward
        {
            get { return _reward; }
            set
            {
                if (_reward > 0)
                {
                    _reward = value;
                }
            }
        }
        public DateTime PublishDateTime { get; set; }
        internal User Author { get; set; }
        internal void Publish()
        {
            Author.credit++;
        }
        public static void Load(int Id)
        {

        }
        static void Delete(int id)
        {

        }
        private readonly static repoistory _repoistory;

        public class repoistory
        {

        }


    }

}
