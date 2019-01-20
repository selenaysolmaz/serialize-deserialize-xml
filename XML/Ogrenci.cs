using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML
{
    public class Ogrenci
    {
        public Guid Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime DogumTarihi { get; set; }


        public Ogrenci()
        {
            this.Id = Guid.NewGuid();
        }

        //to string cagırdıgımız her yerde ad return edicek.
        public override string ToString()
        {
            return Ad;
        }


    }
}
