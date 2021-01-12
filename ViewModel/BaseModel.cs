using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class BaseModel
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishTime { get; set; }
    }
}
