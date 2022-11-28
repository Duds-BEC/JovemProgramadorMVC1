using JovemProgramadorMVC1.Data.Repositorio.Interface;
using JovemProgramadorMVC1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace JovemProgramadorMVC1.Controllers
{
    public class AlunosController : Controller
    {
        private readonly IAlunoRepositorio _alunoRepositorio;
        private readonly IConfiguration _configuration; 
        public AlunosController(IAlunoRepositorio alunoRepositorio, IConfiguration configuration)
        {
            _alunoRepositorio = alunoRepositorio;
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            try
            {
                var alunos = _alunoRepositorio.BuscarAlunos();
                return View(alunos);
            }
            catch (System.Exception)
            {
                TempData["MensagemErro"] = "Erro na conexão com o banco de dados";
                throw;
            }
            
        }
        public IActionResult Adicionar()
        {
            try
            {
                return View();
            }
            catch (System.Exception)
            {
                TempData["MensagemErro"] = "Erro na conexão com o banco de dados";
                throw;
            }
            
        }
        public IActionResult InserirAluno(AlunoModel alunos)
        {
            try
            {
                _alunoRepositorio.InserirAluno(alunos);

                TempData["MensagemSucesso"] = "Aluno adicionado com sucesso!";

                return RedirectToAction("Index");
            }
            catch (System.Exception)
            {
                TempData["MensagemErro"] = "Erro na conexão com o banco de dados";
                throw;
            }
            
        }
        public IActionResult Editar(int id)
        {
            try
            {
                var aluno = _alunoRepositorio.BuscarId(id);
                return View(aluno);
            }
            catch (System.Exception)
            {
                TempData["MensagemErro"] = "Erro na conexão com o banco de dados";
                throw;
            }
            
        }
        public IActionResult EditarAluno(AlunoModel alunos)
        {
            try
            {
                _alunoRepositorio.EditarAluno(alunos);

                TempData["MensagemSucessoEditar"] = "Aluno editado com sucesso!";
                
                return RedirectToAction("Index");
            }
            catch (System.Exception)
            {
                TempData["MensagemErro"] = "Erro na conexão com o banco de dados";
                throw;
            }
        }
        public IActionResult ExcluirAluno(AlunoModel alunos)
        {
            try
            {
                _alunoRepositorio.ExcluirAluno(alunos);

                TempData["MensagemSucessoExcluir"] = "Aluno excluído com sucesso!";

                return RedirectToAction("Index");
            }
            catch (System.Exception)
            {
                TempData["MensagemErro"] = "Erro na conexão com o banco de dados";
                throw;
            }
         
        }
        public async Task<IActionResult> BuscarEndereco(string cep)
        {
            try
            {
                cep = cep.Replace("-", "");

                EnderecoModel enderecoModel = new();

                using var client = new HttpClient();

                var result = await client.GetAsync(_configuration.GetSection("ApiCep")["BaseUrl"] + cep + "/json");

                if (result.IsSuccessStatusCode)
                {
                    enderecoModel = JsonSerializer.Deserialize<EnderecoModel>(
                        await result.Content.ReadAsStringAsync(), new JsonSerializerOptions() { });
                }

                return View("Endereco", enderecoModel);
            }
            catch (System.Exception)
            {
                TempData["MensagemErro"] = "Erro na conexão com o banco de dados";
                throw;
            }
            
        }
    }
}
