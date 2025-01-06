using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Department_HW_.Models
{
    public class Worker
    {
        public int WorkerId { get; set; }
        public string WorkerName { get; set; }
        public string WorkerSurname { get; set; }

        public int WorkerAge { get; set; }

        public bool MillitaryDocument { get; set; }

        public int RKNOPP { get; set; }

        public int PasportSerial { get; set; }
        public bool BachelorGrade { get; set; }
        public int TotalECTS { get; set; }

        public int PositionId { get; set; }
        public int DepartmentId { get; set; }

        public Position Position { get; set; }
        public Department Department { get; set; }
    }
}
