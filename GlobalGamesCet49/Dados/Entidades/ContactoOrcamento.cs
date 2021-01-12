using System.ComponentModel.DataAnnotations;

namespace GlobalGamesCet49.Dados.Entidades
{
    public class ContactoOrcamento
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Mensagem { get; set; }





    }
}
