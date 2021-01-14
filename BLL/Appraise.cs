using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Appraise : BaseEntity
    {
        public int AgreeCount { get; protected internal set; }
        public int DisagreeCount { get; protected internal set; }
        public virtual void Agree(Content votee, Users voter, int amount)
        {
            CheckCanVote(votee, voter);

            //投票人消耗了帮帮豆
            voter.BallotConsumed(amount);

            //投票人获得帮帮点和通知

            //被投票人获得帮帮点和通知

            AgreeCount += amount;
        }

        private void CheckCanVote(Content votee, Users voter)
        {
            if (voter == votee.Author)
            {
                throw new Exception(string.Format(
                    "用户（id={0}）试图评价自己的内容（id={1}，type={0}）",
                    voter.Id, Id, votee.GetType().Name));
            }
        }
    }
}
