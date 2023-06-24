using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Model
{

    public class Rootobject
    {
        public SarkıM[] Property1 { get; set; }
    }

    public class SarkıM
    {
        public Guid Id { get; set; }
        public string Baslik { get; set; }
        public string SarkıAd { get; set; }
        public string Sarkıcı { get; set; }
        public double Sure { get; set; }
        public string FotoUrl { get; set; }
    }

}
