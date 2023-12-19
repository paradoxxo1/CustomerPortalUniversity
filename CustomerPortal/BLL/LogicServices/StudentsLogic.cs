using BOL.DataBaseEntities;
using DAL.DataServices;

namespace BLL.LogicServices
{
    public class StudentsLogic : IStudentsLogic
    {
        public readonly IStudentsDataDAL _studentDataDAL;

        public StudentsLogic(IStudentsDataDAL studentDataDAL)
        {
            this._studentDataDAL = studentDataDAL;
        }

        public List<Students> GetStudentsListLogic()
        {
            List<Students> result = new List<Students>();

            result = _studentDataDAL.GetStudentsListDAL();

            return result;
        }

        public string SaveStudentRecordLogic(Students FormData)
        {
            string result = string.Empty;
            if (String.IsNullOrWhiteSpace(FormData.FirstName) || String.IsNullOrWhiteSpace(FormData.LastName) || String.IsNullOrWhiteSpace(FormData.Email))
            {
                result = "Please Fill All Form Fields";
                return result;

            }

            if (FormData.Email.StartsWith("al"))
            {
                result = "Email should not be start with 'al'!";
                return result;
            }

            //-- call DAL method for inserting the student object

            result = _studentDataDAL.SaveStudentRecordDal(FormData);

            if(result == "Saved Successfully")
            {
                return result;
            }else
            {
                result = "An error occurred. Plase try again";
                return result;
            }
        }
    }
}
