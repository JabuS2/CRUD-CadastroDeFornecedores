namespace ControleFornecedores.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public required string NomeFantasia { get; set; }
        public required string RazãoSocial { get; set; }
        public required string Telefone {  get; set; }
        public required string Email { get; set; }
        public required string Endereco { get; set; }

    }
}
