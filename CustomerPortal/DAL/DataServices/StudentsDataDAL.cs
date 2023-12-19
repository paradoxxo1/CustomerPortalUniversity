using BOL.DataBaseEntities;
using DAL.DataContext;
using Dapper;
using System.Data;

namespace DAL.DataServices
{
    public class StudentsDataDAL : IStudentsDataDAL
    {
        private readonly IDapperOrmHelper _dapperOrmHelper;

        public StudentsDataDAL(IDapperOrmHelper dapperOrmHelper)
        {
            _dapperOrmHelper = dapperOrmHelper;
        }

        public List<Students> GetStudentsListDAL()
        {
            List<Students> students = new List<Students>();

            try
            {

                using (IDbConnection dbConnection = _dapperOrmHelper.GetDapperContextHelper())
                {
                    string SqlQuery = "SELECT * FROM Students";
                    students = dbConnection.Query<Students>(SqlQuery, commandType: CommandType.Text).ToList();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            return students;


        }

        public string SaveStudentRecordDal(Students FormData)
        {
            string result = string.Empty;

            try
            {

                using (IDbConnection dbConnection = _dapperOrmHelper.GetDapperContextHelper())
                {
                    dbConnection.Execute(@"INSERT INTO Students(FirstName, LastName, Email)VALUES(@FirstName, @LastName, @Email)",
                        new
                        {
                            FirstName= FormData.FirstName, LastName = FormData.LastName, Email = FormData.Email
                        },
                        commandType: CommandType.Text);

                    result = "Saved Successfully";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return result;
        }
    }
}
