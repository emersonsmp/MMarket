using System;
using System.Collections.Generic;
using System.Text;

namespace tcc.Model
{
    public class AvaliacoesModel
    {
        public string mercado {get; set;}
        public string rating { get; set; }
        public Avaliacoes[] avaliacoes { get; set; }
    }

    public class Avaliacoes
    {
        public string nome { get; set; }
        public string descricao { get; set; }
        public string estrela { get; set; }
    }

}
