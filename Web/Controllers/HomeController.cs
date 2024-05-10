using Core;
using Core.Interfaces;
using Core.Models;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICalculator _calc;
        private IRepository<MathProblem> _mathProblemRepository;

        public HomeController(ILogger<HomeController> logger, IRepository<MathProblem> mathProblemRepository, ICalculator calculator)
        {
            _logger = logger;
            _mathProblemRepository = mathProblemRepository;
            _calc = calculator;
        }

        public IActionResult Index()
        {
            List<MathProblem> list = _mathProblemRepository.GetAll().TakeLast<MathProblem>(10).ToList<MathProblem>();
            return View(list);
        }

        [HttpPost]
        public JsonResult CalculateMathProblem(string mathProblem)
        {
            try
            {
                MathProblem newMathProblem = MathProblem.Parse(mathProblem);
                newMathProblem.Result = _calc.Solve(newMathProblem.FirstNumber, newMathProblem.SecondNumber, newMathProblem.Operation);
                _mathProblemRepository.Add(newMathProblem);
                return Json(newMathProblem);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return null;
            }
            

            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
