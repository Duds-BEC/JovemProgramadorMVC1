using Microsoft.AspNetCore.Mvc;
using JovemProgramadorMVC1.Data.Repositório.Interface;
using JovemProgramadorMVC1.Models;


namespace JovemProgramadorMVC1.Controllers
{
    public class AlunosController : Controller
    {
        private readonly IAlunoRepositorio _alunoRepositorio;

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
        public IActionResult InserirAluno(AlunoModel alunos)
        {
            _alunoRepositorio.InserirAluno(alunos);
            return RedirectToAction("Index");
        }
    }
}
