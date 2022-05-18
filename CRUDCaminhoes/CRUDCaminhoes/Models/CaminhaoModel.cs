using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDCaminhoes.Models
{
    public class CaminhaoModel
    {
        public int Id { get; set; }
       
        public string Nome { set; get; }
        public string Descricao { get; set; }
        public DateTime DataDeCriacao { get; set; }

    }
}
