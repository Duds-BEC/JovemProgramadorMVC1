using JovemProgramadorMVC1.Models;
using System.Collections.Generic;
namespace JovemProgramadorMVC1.Data.Repositorio.Interface
{
    public interface IAlunoRepositorio
    {
        void InserirAluno(AlunoModel alunos);
        List<AlunoModel> BuscarAlunos();
    }
}
