using System.Data;

namespace DAL.DataContext
{
    public interface IDapperOrmHelper
    {
        IDbConnection GetDapperContextHelper();
    }
}
