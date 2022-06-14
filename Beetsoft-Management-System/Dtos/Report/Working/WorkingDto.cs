using Beetsoft_Management_System.Data.Entities;


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

        public int Type {set;get;}

        public string Note {set;get;}

        public  Project Project {set;get;}

        public int Status {set;get;}

        // public IEnumerable<Position> Positions {set;get;}

        public IEnumerable<string> positionNames {set;get;}

    }
   
}