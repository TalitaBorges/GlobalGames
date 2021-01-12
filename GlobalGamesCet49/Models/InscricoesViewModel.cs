namespace GlobalGamesCet49.Models
{
    using System.ComponentModel.DataAnnotations;
    using GlobalGamesCet49.Dados.Entidades;
    using Microsoft.AspNetCore.Http;
    

    public class InscricoesViewModel : Jogador
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }



        /*
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Apelido { get; set; }

        public string Morada { get; set; }

        public string Localidade { get; set; }

        [Display(Name = "Cartão Cidadão")]
        public string CartaoCidadao { get; set; }

        [Display(Name = "Data de Nascimento")]
        public string DataNascimento { get; set; }

        [Display(Name = "Image")]
        public string ImageURL { get; set; }*/
    }
}
