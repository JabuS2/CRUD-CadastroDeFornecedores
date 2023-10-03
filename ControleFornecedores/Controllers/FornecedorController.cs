using ControleFornecedores.Models;
using ControleFornecedores.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleFornecedores.Controllers
{
    public class FornecedorController : Controller
    {

        private readonly IFornecedorRepositorio _FornecedorRepositorio;
        public FornecedorController(IFornecedorRepositorio fornecedorRepositorio)
        {
            _FornecedorRepositorio = fornecedorRepositorio;
        }
        public IActionResult Index()
        {
            List<Fornecedor> fornecedor = _FornecedorRepositorio.BuscarTodos();
            return View(fornecedor);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            Fornecedor fornecedor= _FornecedorRepositorio.ListarPorId(id);
            return View(fornecedor);
        }

        public IActionResult Apagar(int id)
        {
            Fornecedor fornecedor = _FornecedorRepositorio.ListarPorId(id);
            return View(fornecedor);
        }

        public IActionResult Excluir(int id)
        {
            _FornecedorRepositorio.Excluir(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(Fornecedor fornecedor)
        {
            _FornecedorRepositorio.Adicionar(fornecedor);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Alterar(Fornecedor fornecedor)
        {
            _FornecedorRepositorio.Atualizar(fornecedor);
            return RedirectToAction("Index");
        }
    }
}
