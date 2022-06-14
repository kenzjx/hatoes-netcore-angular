namespace Beetsoft_Management_System.Systems
{

    public class WorkingView
    {
        public int Id { get; set; }

        public float? Time { get; set; }

        public DateTime? Date { get; set; }


        public string? Note { get; set; }

        public int? Status { get; set; }

        public int? Type { get; set; }

        public int ProjectId { set; get; }

        public string UserId { set; get; }

        public string ProjectName { set; get; }

        public IEnumerable<Postition> Postions {set;get;}

    }
    public class Postition
    {
        public int positionId { set; get; }

        public string PositionName { set; get; }
    }
}
