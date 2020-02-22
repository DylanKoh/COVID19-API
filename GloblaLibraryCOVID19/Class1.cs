using System;

namespace GloblaLibraryCOVID19
{
    public class FTEs
    {
        public long ID { get; set; }
        public string NRIC { get; set; }
        public string UserID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
    }
    public class ContactTracing
    {
        public long ID { get; set; }
        public Nullable<long> FTE_ID { get; set; }
        public long LocationID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public decimal Temp { get; set; }
        public System.DateTime RegisterDateTime { get; set; }
        public Nullable<System.DateTime> ExitDateTime { get; set; }
    }
    public class Locations
    {
        public long ID { get; set; }
        public string LocationName { get; set; }
        public byte LocationFloor { get; set; }
        public string LocationBuildingName { get; set; }
        public byte LocationUnitNumber { get; set; }
    }
}
