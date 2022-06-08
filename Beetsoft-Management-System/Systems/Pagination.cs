namespace Beetsoft_Management_System.Systems
{
    public class Pagination<T>
    {
        public ICollection<T> Items { get; set; }

        public int TotalRecords { get; set; }
    }
}
