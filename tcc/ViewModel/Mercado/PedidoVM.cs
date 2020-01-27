using System;
using System.Collections.Generic;
using System.Text;
using tcc.Model;
using Xamarin.Forms;

namespace tcc.ViewModel.Mercado
{
    class PedidoVM
    {
        public string idpedido { get; set; }
        public string total { get; set; }
        public Model.Cliente cliente { get; set; }
        public List<Itens> ListViewProdutos { get; set; }

        public Command GoEntregaCommand { get; set; }


        //PEGANDO DADOS DO CLIENTE
        public PedidoVM(Pedido pedido)
        {
            idpedido = pedido.idpedido;
            GoEntregaCommand = new Command(GoEntrega);
            ListViewProdutos = new List<Itens>();
            PovoaProdutos();
        }

        //PEDO OS PRODUTOS POR ELE PEDIDO
        private void PovoaProdutos()
        {
            try
            {
                PedidoIndividualModel resp = Service.Service.GetPedido(idpedido);
                cliente = resp.cliente;
                total = resp.pagamento.total;

                List<Itens> ListaItens = new List<Itens>((IEnumerable<Itens>)resp.itens);

                for (int i = 0; i < ListaItens.Count; i++)
                {
                    ListViewProdutos.Add(ListaItens[i]);
                }
            }
            catch
            {
                App.Current.MainPage.DisplayAlert("Atenção","Erro: Tente novamente mais tarde","ok");
            }          
        }

        private void GoEntrega()
        {
            try
            {
                //TODO - SETAR STATUS PEDIDO
                Service.Service.MudaFlagEntrega(idpedido, "2");
                App.Current.MainPage.DisplayAlert("Atencao", "Pedido Atualizado, agurdando saída para entrega", "OK");

                //RETORNAR PAGINA RAIZ
                App.Current.MainPage.Navigation.PopToRootAsync();
            }
            catch
            {
                App.Current.MainPage.DisplayAlert("Atenção","Erro Tente Novamente","OK");
            }

            //VOLTAR TELA PEDIDOS E ATUALIZAR

        }
    }
}
