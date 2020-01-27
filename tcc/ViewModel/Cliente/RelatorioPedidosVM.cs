using System;
using System.Collections.Generic;
using System.Text;
using tcc.Model;

namespace tcc.ViewModel.Cliente
{
    class RelatorioPedidosVM
    {
        public List<Rastreio> ListaDePedidos { get; set; }
        public RelatorioPedidosVM()
        {
            ListaDePedidos = new List<Rastreio>();
            PovoaListaDePedidos();
        }

        private void PovoaListaDePedidos()
        {
            string cpf = App.Current.Properties["Cpf_user"].ToString();

            try
            {
                RelatorioClienteModel Resp = Service.Service.GetRelatorioCliente(cpf);

                if (Resp != null)
                {
                    List<Rastreio> Lista = new List<Rastreio>((IEnumerable<Rastreio>)Resp.Pedidos);

                    for (int i = 0; i < Lista.Count; i++)
                    {
                        ListaDePedidos.Add(Lista[i]);
                    }
                }
                else
                {
                    App.Current.MainPage.DisplayAlert("Atenção", "Carrinho vazio", "ok");
                }
            }
            catch
            {
                App.Current.MainPage.DisplayAlert("Atenção", "ERRO", "ok");
            }
        }
    }
}
