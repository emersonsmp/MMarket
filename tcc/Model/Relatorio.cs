using System;
using System.Collections.Generic;
using System.Text;

namespace tcc.Model
{
        public class RelatorioModel
        {
            public string Totalganho { get; set; }
            public string views { get; set; }
            public int TotalPedidos { get; set; }
            public Pedidos[] pedidos { get; set; }
        }

        public class Pedidos
        {
            public string idpedido { get; set; }
            public string DataVenda { get; set; }
            public string DataEntrega { get; set; }
            public string Pagamento { get; set; }
            public string TipoPagamento { get; set; }
            public string Cliente_cpf { get; set; }
            public string total { get; set; }
        }
}
