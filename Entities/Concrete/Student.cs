using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Student
    {
        [Key]
        public Guid StudentGuidId { get; set; }
        public string NameSurname { get; set; }
        public string Email{ get; set; }
        public byte[] ImageByte { get; set; }
        public string StudentNo { get; set; }
        public string Faculty{ get; set; }
        public string FacultyDepartment { get; set; }
        public int StudentClass { get; set; }
        public Guid JobUnitGuidId { get; set; }
        public JobUnit JobUnit { get; set; }
        public List<Tally> Tallies { get; set; }
        public List<WeekTally> WeekTallies { get; set; }
        public List<Syllabus> Syllabi { get; set; }


    }
}
