using System;
using System.Collections.Generic;
using System.Text;

namespace tcc.Model
{

    //OBJETOS DE PEDIDO INDIVIDUAL
    public class PedidoIndividualModel
    {
        public int quant { get; set; }
        public string id { get; set; }
        public Cliente cliente { get; set; }
        public Pagamento pagamento { get; set; }
        public Itens[] itens { get; set; }
    }
    public class Cliente
    {
        public string nomeCliente { get; set; }
        public string endereco { get; set; }
        public string num { get; set; }
        public string cpf { get; set; }
    }
    public class Pagamento
    {
        public string confirmacao { get; set; }
        public string TipoPagamento { get; set; }
        public string total { get; set; }
    }
    public class SacolaModel
    {
        public string id { get; set; }
        public string total { get; set; }
        public Itens[] itens { get; set; }
    }
    public class Itens
    {
        public string cod_barra { get; set; }
        public string quantidade { get; set; }
        public string nomeProduto { get; set; }
        public string peso { get; set; }
        public string itemid { get; set; }
    }





    public class PedidoEntregaModel
    {
        public Pedido[] pedidos { get; set; }
        public bool FlagVazio { get; set; }
        public int quant { get; set; }
    }

    public class Pedido
    {
        public string idpedido { get; set; }
        public string total { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string endereco { get; set; }
        public string numero { get; set; }
        public string DataVenda { get; set; }
        public string FlagEntrega { get; set; }
        public string DataEntrega { get; set; }
        public string Troco { get; set; }
        public string TipoPagamento { get; set; }
    }



    public class RastreioModel
    {
        public Rastreio[] Rastreio { get; set; }
    }


    public class RelatorioClienteModel
    {
        public Rastreio[] Pedidos { get; set; }
    }

    public class Rastreio
    {
        public string id { get; set; }
        public string total { get; set; }
        public string mercado { get; set; }
        public string status { get; set; }
        public bool IsVisible { get; set; }
        public string cnpj { get; set; }
        public string data { get; set; }
    }

}
