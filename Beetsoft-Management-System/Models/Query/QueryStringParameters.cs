namespace Beetsoft_Management_System.Models.Query
{
    public class QueryStringParameters
    {
        const int maxPageSize = 50;

        public int PageNumber {set;get;} =1;
        
        private int _pageSize = 10;

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value >maxPageSize)  ? maxPageSize : value ; 
            }
        }

        public string OrderBy {set;get;}
    }
}