using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VectoTask.Models;

namespace VectoTask.Dtos
{
    public class TourCategoryDto
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public string TourTitle { get; set; }
        public int CategoryId { get; set; }
        public string CategoryTitle { get; set; }

        //public List<Category> Categories { get; set; }
    }
}
