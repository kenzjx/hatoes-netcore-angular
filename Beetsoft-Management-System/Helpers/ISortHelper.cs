using System.Linq;
namespace Beetsoft_Management_System.Helpers
{
    public interface ISortHelper<T>
    {
        IQueryable<T> AppySort(IQueryable<T> entities,string orderByQueryString);
    }
}