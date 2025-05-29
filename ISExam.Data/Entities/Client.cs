using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ISExam.Data.Entities
{
    public class Client
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public int MembershipCardNumber { get; set; }
        public DateTime MembershipValidityDate { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        [ForeignKey("MovieId")]
        public virtual Movie? Movie {get; set; }
        public int MovieId { get; set; }
    }
}
