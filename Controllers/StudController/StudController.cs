using Microsoft.AspNetCore.Mvc;
using University.DAL.Repositories.Interfaces;
using University.Domain.Entity;
using University.Models;

namespace University.Controllers.StudController
{
    public class StudController : Controller
    {
        private readonly IStudRepository _studRepository;

        public StudController(IStudRepository studRepository)

        {
            _studRepository = studRepository;
        }

      

        [HttpGet]
        public async Task<IActionResult> GetStud()


        {
            var response = await _studRepository.Select();
                                
            var stud = new Stud()
            {
                Kurs=2,
                Lastname = "Skvortsov",
                Firstname = "Oleg",
                Surname = "Nikolayevich",
               
            };

            await _studRepository.Create(stud);
            await _studRepository.Delete(stud);
            

            return View(response);
        }

        [HttpGet]
        public async Task<IActionResult> SelectAll()//вывод лекций студентов
        {

            var viewModel = new ViewModelStudLec();

            viewModel.Studs = await _studRepository.SelectAll(2);

            viewModel.Lectures = viewModel.Studs.Where(s => s.StudId == 2).Single().Lecture;           

            return View(viewModel);       
        }

       // [HttpGet]
      //  public async Task<IActionResult> SelectLabworksWithReview()//вывод лабораторных студентов
      // {

      //     var viewModel = new ViewModelStudLec();

      //      viewModel.Studs = await _studRepository.SelectLabworksWithReview(1,2);

      //     viewModel.Labworks = viewModel.Studs.Where(s => s.StudId == 1).Single().Labwork;

      //      viewModel.Review= viewModel.Labworks.Where (l=>l.LabworkId==2).Single().Review;

      //     return View(viewModel);
      //  }

    }

}
