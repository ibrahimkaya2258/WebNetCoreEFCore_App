using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebNetCoreEFCore_App.Data.Views
{
    public class ProductView
    {
        public string Urun { get; set; }
        public decimal Fiyat { get; set; }
        public int Stok { get; set; }
        public string Kategori { get; set; }
        public string Tedarikci { get; set; }
    }
}
