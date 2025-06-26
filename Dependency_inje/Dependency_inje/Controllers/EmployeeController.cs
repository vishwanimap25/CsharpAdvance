using Dependency_inje.Modal;
using Microsoft.AspNetCore.Mvc;

namespace Dependency_inje.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _employeeRepository;
        public IActionResult Index(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            return View();
        }

        public string Index()
        {
            return _employeeRepository.GetEmployee(1).Name;
        }
    }
}
