
using ControleFornecedores.Data;
using ControleFornecedores.Models;

namespace ControleFornecedores.Repositorio
{
    public class FornecedorRepositorio : IFornecedorRepositorio
    {
        private readonly BancoContext _context;

        public FornecedorRepositorio(BancoContext bancocontext)
        {
            _context = bancocontext;
        }

        public Fornecedor ListarPorId(int id)
        {
            return _context.Fornecedores.FirstOrDefault(x => x.Id == id);
        }

        public Fornecedor Adicionar(Fornecedor fornecedor)
        {
            _context.Fornecedores.Add(fornecedor);
            _context.SaveChanges();
            return fornecedor;
        }

        public List<Fornecedor> BuscarTodos()
        {
            return _context.Fornecedores.ToList();
        }

        public Fornecedor Atualizar(Fornecedor fornecedor)
        {
            Fornecedor fornecedorDB = ListarPorId(fornecedor.Id);

            if (fornecedorDB == null) throw new System.Exception("Houve um erro na atualização de fornecedor");

            fornecedorDB.NomeFantasia = fornecedor.NomeFantasia;
            fornecedorDB.Email = fornecedor.Email;
            fornecedorDB.Telefone = fornecedor.Telefone;
            fornecedorDB.RazãoSocial = fornecedor.RazãoSocial;
            fornecedorDB.Endereco = fornecedor.Endereco;

            _context.Fornecedores.Update(fornecedorDB);
            _context.SaveChanges();

            return fornecedorDB;
        }

        public bool Excluir(int id)
        {
            Fornecedor fornecedorDB = ListarPorId(id);

            if (fornecedorDB == null) throw new System.Exception("Houve um erro na deleção de contato");

            _context.Fornecedores.Remove(fornecedorDB);
            _context.SaveChanges();

            return true;
        }
    }
}
