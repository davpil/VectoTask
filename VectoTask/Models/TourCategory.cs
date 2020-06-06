using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VectoTask.Models
{
    public class TourCategory
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int TourId { get; set; }
        public Tour Tour { get; set; }
    }
}
