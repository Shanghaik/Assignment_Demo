using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ModelsClass
{
    public class Giohangchitiet
    {
        public Guid IDSanpham { get; set; }
        public Guid IDGiohang { get; set; }
        public int Soluong { get; set; }
        public decimal Gia { get; set; }
        public Sanpham Sanpham { get; set; }
        public Giohang Giohang { get; set; }
    }
}
