using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ModelsClass
{
    [Serializable]
    public class Sanpham
    {
        public Guid Id { get; set; }
        [StringLength(100)]
        //[RegularExpression(@"/^[a-z ,.'-]+$/i")]
        //Yêu cầu chuỗi phải phù hợp với Regex
        public string Ten { get; set; }
        public decimal Gia { get; set; }
        [Range(0, 1000)] // Số lượng phải trong khoảng từ 0 đến 1000
        public int Soluong { get; set; }
        public bool Trangthai { get; set; }
        //public IEnumerable<Giohangchitiet>? Giohangchitiets { get; set; }
    }
}
