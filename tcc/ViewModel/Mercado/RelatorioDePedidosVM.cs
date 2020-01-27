using System;
using System.Collections.Generic;
using System.Text;
using tcc.Model;

namespace tcc.ViewModel.Mercado
{
    class RelatorioDePedidosVM
    {
        public List<Pedidos> ListaDePedidos { get; set; }
        public RelatorioDePedidosVM(RelatorioModel relatorio)
        {
            ListaDePedidos = new List<Pedidos>();
            PovoaListaDePedidos(relatorio);
        }

        private void PovoaListaDePedidos(RelatorioModel relatorio)
        {
            //string cpf = App.Current.Properties["Cpf_user"].ToString();

            try
            {
               List<Pedidos> Lista = new List<Pedidos>((IEnumerable<Pedidos>)relatorio.pedidos);

               for (int i = 0; i < Lista.Count; i++)
               {
                  ListaDePedidos.Add(Lista[i]);
               }
            }
            catch
            {
                App.Current.MainPage.DisplayAlert("Atenção", "ERRO", "ok");
            }
        }
    }
}
