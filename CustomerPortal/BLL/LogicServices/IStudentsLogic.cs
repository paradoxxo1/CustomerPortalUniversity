using BOL.DataBaseEntities;

namespace BLL.LogicServices
{
    public interface IStudentsLogic
    {
        List<Students> GetStudentsListLogic();
        string SaveStudentRecordLogic(Students FomrData);
    }
}
