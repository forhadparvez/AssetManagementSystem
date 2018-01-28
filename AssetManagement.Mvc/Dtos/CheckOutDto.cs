using System;
using System.Collections.Generic;

namespace AssetManagement.Mvc.Dtos
{
    public class CheckOutDto
    {
        public int EmployeeId { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int AssetLocationId { get; set; }
        public string Commants { get; set; }
        public List<int> AssetIds { get; set; }
    }
}