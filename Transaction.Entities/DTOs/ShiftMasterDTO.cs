using System;


namespace Transaction.Entities.DTOs
{
    public class ShiftMasterDTO
    {

        public string ShiftGuid { get; set; }

        public string ShiftName { get; set; }


        public int? ShiftDay { get; set; }

        public DateTime? StartDate { get; set; }


        public bool? Active { get; set; }
    }
}
