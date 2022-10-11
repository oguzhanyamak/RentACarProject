using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Domain.Entites
{
    public class Arac: BaseEntity
    {
        public string Marka { get; set; }
        public string Model { get; set; }
        public string MotorHacmi { get; set; }
        public string BeygirGucu { get; set; }
        public string Plaka { get; set; }
        public string VitesTuru { get; set; }
        public float SaatUcreti { get; set; }

        //Şuan Bekliyor mu ?
        public bool OzelDurum { get; set; } = true;

        //Arac çalışır durumda mı ? Hurda mı
        public bool GenelDurum { get; set; } = true;
        public virtual Sube Sube { get; set; }
    }
}
