using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
    public class EmailRepository : BaseRepository<Email>
    {
        public EmailRepository(SqlContext context) : base(context)
        {
        }
        public bool IsDuplication(string address)
        {
            return entities.Where(e => e.Address == address).FirstOrDefault() != null;
        }
    }
}
