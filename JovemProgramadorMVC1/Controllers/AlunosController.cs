using Microsoft.AspNetCore.Mvc;


namespace JovemProgramadorMVC1.Controllers
{
    public class AlunosController : Controller
    {
        private readonly IAlunoReposotorio _alunoRepositorio;
        public AlunosController(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio; 
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Adicionar()
        {
            return View();
        }
        public IActionResult InserirAluno()
        {
            _alunoRepositorio.InserirAluno();
            return View();
        }
    }
}
