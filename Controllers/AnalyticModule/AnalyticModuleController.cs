using Microsoft.AspNetCore.Mvc;
using University.DAL.Repositories;
using University.DAL.Repositories.Interfaces;

namespace University.Controllers.AnalyticModule
{
    public class AnalyticModuleController : Controller

    {
        private readonly AnalyticModuleRepo _analyse;

        public AnalyticModuleController(AnalyticModuleRepo analyse)

        {
            _analyse = analyse;
        }
        public async Task <IActionResult> SelectFailingStudent()
        {
            
            var response = await _analyse.SelectFailingStudent();   

            return View(response);
        }
    }
}
