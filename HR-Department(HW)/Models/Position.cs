using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Department_HW_.Models
{
    public class Position
    {
        public int PositionId { get; set; }
        public string PositionName { get; set; }
        public decimal PositionSalary { get; set; }
        public List<Worker> Workers { get; set; }
    }
}
