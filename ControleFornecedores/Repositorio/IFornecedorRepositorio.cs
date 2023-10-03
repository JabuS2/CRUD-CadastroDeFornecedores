using ControleFornecedores.Models;

namespace ControleFornecedores.Repositorio
{
    public interface IFornecedorRepositorio
    {
        Fornecedor ListarPorId(int id);
        List<Fornecedor> BuscarTodos();
        Fornecedor Adicionar(Fornecedor fornecedor);

        Fornecedor Atualizar(Fornecedor fornecedor);
        bool Excluir(int id);
    }
}
