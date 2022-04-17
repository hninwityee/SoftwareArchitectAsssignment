using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transaction.Entities
{
    [Table("Shift_Master")]
    public partial class ShiftMaster
    {
        [Key]
        [Column("ShiftGUID")]
        [StringLength(32)]
        public string? ShiftGuid { get; set; }

        [StringLength(255)]

        [Column("ShiftName")]
        public string? ShiftName { get; set; }

        public int? ShiftDay { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StartDate { get; set; }


        [Column("ShiftStatus")]
        [StringLength(20)]
        public bool? Active { get; set; }
    }
}
