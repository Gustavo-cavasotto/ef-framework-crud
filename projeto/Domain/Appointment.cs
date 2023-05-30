using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto.Domain
{
    public class Appointment
    {
        public int Id {get; set; }
        public DateTime date {get; set; }
        public Doctor doctor {get; set; }
        public Patient patient {get; set; }

    }

}