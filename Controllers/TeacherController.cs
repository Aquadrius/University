using Microsoft.AspNetCore.Mvc;
using Namotion.Reflection;
using University.DAL.Repositories;
using University.DAL.Repositories.Interfaces;
using University.Domain.Entity;
using University.Models;

namespace University.Controllers
{
    public class TeacherController:Controller
    {
        private readonly ITeachersRepository _teachersRepository;

        public TeacherController(ITeachersRepository teachersRepository)

        {
            _teachersRepository = teachersRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetTeachers()
        {
            var response = await _teachersRepository.GetTeachers();

            return View (response);
        }

        [HttpPost]

        public async Task <IActionResult> Add()
        {
            var response = new Teacher()
            {
                Lastname = "Popov",
                Firstname = "Oleg",
                Surname = "Nikolayevich"
            };


             await _teachersRepository.Add(response);
           
            return View (response);
            
        }

        [HttpGet]
        public async Task<IActionResult> SelectLec()//вывод лекций преподавателей
        {

            var viewModel = new ViewModelStudLec();

            viewModel.Teachers = await _teachersRepository.Select(2);

            viewModel.Lectures = viewModel.Teachers.Where(t => t.TeacherId == 2).Single().Lecture;

            return View(viewModel);
        }

    }
}
