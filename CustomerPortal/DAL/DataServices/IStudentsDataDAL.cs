using BOL.DataBaseEntities;

namespace DAL.DataServices
{
    public interface IStudentsDataDAL
    {

        List<Students> GetStudentsListDAL();
        string SaveStudentRecordDal(Students FormData);
    }
}
