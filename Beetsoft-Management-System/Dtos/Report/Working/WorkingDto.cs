using Beetsoft_Management_System.Data.Entities;
using Beetsoft_Management_System.Data.Enums;

namespace Beetsoft_Management_System.Dtos.Report.Working
{
    public class WorkingDto
    {
        
    }

    public class WorkingQuery
    {
        public int Id {set;get;}
        
        public float Time {set;get;}

        public DateTime Day {set;get;}

        public WorkingType Type {set;get;}

        public string Note {set;get;}

        public  Project Project {set;get;}

        public Status Status {set;get;}

        // public IEnumerable<Position> Positions {set;get;}

        public IEnumerable<string> positionNames {set;get;}

    }
   
}