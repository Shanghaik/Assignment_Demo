using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ModelsClass
{
    public class Giohang
    {
        public Guid ID { get; set; }
        public Guid IDKhach { get; set; }
        public bool TrangThai { get; set; }
        public IEnumerable<Giohangchitiet> Giohangchitiets { get; set; }
    }
}
