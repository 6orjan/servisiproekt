using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISExam.Service.DTOs
{
    public class MovieDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public float Rating { get; set; }
        public float BoxOfficeEarnings { get; set; }
    }
}
