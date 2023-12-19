using BLL.LogicServices;
using BOL.CommonEntities;
using BOL.DataBaseEntities;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace CustomerPortal.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentsLogic _studentsLogic;

        public StudentsController(IStudentsLogic studentsLogic)
        {
            this._studentsLogic = studentsLogic;
        }

        [HttpGet]
        public IActionResult StudentsList()
        {

            //--Main Model

            StudentModule model = new StudentModule();


            //--get students List
            model.studentsList = _studentsLogic.GetStudentsListLogic().ToList();

            return View(model);
        }


        [HttpGet]
        public IActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateStudentPost(Students FormData)
        {

            //-- Save Students Records
            string result = _studentsLogic.SaveStudentRecordLogic(FormData);
            if (result == "Saved Successfully")
            {
                return RedirectToAction("StudentsList", "Students");
            }else
            {
                TempData["ErrorTemp"] = result;
                return RedirectToAction("CreateStudent", "Students");
            }
        }
    }
}
