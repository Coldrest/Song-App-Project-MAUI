using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Model
{

    public class Rootobject1
    {
        public KullanıcıM[] Property1 { get; set; }
    }

    public class KullanıcıM
    {
        public Guid Id { get; set; }
        public string KullanıcıAdi { get; set; }
        public string Sifre { get; set; }
        public string Cinsiyet { get; set; }
        public DateTime DogumTarihi { get; set; }

    }

}
