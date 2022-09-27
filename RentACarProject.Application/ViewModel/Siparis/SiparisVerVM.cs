using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.ViewModel.Siparis
{
    public class SiparisVerVM
    {
        public Guid KullaniciId { get; set; }
        public Guid AracId { get; set; }
        public Guid SubeId { get; set; }
        public Guid TSubeId { get; set; }
        public DateTime Alis { get; set; }
        public DateTime Teslim { get; set; }
    }
}
