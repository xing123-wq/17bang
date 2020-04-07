using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    public class Appraise
    {
        Content Iarget { get; set; }
        User Wotter { get; set; }
        /// <summary>
        /// 同意或不同意
        /// </summary>
        public bool? AgreeOrNot
        {
            get => AgreeOrNot;
            set
            {
                if (AgreeOrNot == true)
                {
                    AgreeNumber++;
                }
                else
                {
                    NotNumber++;
                }
            }
        }
        /// <summary>
        /// 同意数量
        /// </summary>
        public int AgreeNumber { get; set; }
        /// <summary>
        /// 不同意数量
        /// </summary>
        public int NotNumber { get; set; }
        void Agree()
        {

        }
        void Disagree()
        {

        }
    }
}
