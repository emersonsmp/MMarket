using System;
using System.Collections.Generic;
using System.Text;

namespace tcc.Model
{
    public class CupomModel
    {
        public Cupon[] cupons { get; set; }
    }

    public class Cupon
    {
        public string cod { get; set; }
        public string nome { get; set; }
        public string validade { get; set; }
        public string percent { get; set; }
        public string cnpj { get; set; }
    }


}
