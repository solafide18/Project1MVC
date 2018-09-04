using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSCF.Model
{
    public class EMPLOYEE
    {
        [StringLength(10)]
        [Column(TypeName = "varchar")]
        [Key]
        public string EMP_ID { get; set; }
        [StringLength(100)]
        [Column(TypeName = "varchar")]
        public string NAME { get; set; }
        [StringLength(100)]
        [Column(TypeName = "varchar")]
        public string EMAIL { get; set; }
        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string DEPT_ID { get; set; }
        [Required]
        public bool ACTIVE { get; set; }
    }
}
