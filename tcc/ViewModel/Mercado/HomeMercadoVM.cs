using System;
using System.Collections.Generic;
using System.Text;
//using tcc.Service;
using tcc.Model;
using Xamarin.Forms;
using tcc.View.PerfilMercado;

namespace tcc.ViewModel.Mercado
{
    class HomeMercadoVM
    {
        public string QuantidadeDePedidos { get; set; }
        public Command GoPedidosCommand { get; set; }
        public Command GoEntregasCommand { get; set; }
        PedidoEntregaModel Pedidos = new PedidoEntregaModel();


        public HomeMercadoVM()
        {
            GetPedidos();
            GoPedidosCommand  = new Command(GoPedidos);
            GoEntregasCommand = new Command(GoEntregas);
        }

        void GetPedidos()
        {
            string cnpj = App.Current.Properties["Cnpj_user"].ToString();
            try
            {
                //Pedidos = Service.Service.GetPedidos(cnpj);
                Pedidos = Service.Service.GetPedidosParaEntrega(cnpj, "1");

                if (Pedidos == null)
                {
                    QuantidadeDePedidos = "0";
                }
                else
                {
                    QuantidadeDePedidos = Pedidos.quant.ToString();
                }
            }
            catch
            {
                QuantidadeDePedidos = "0";
            }
        }

        void GoPedidos()
        {
            
            if (QuantidadeDePedidos == "0")
            {
                App.Current.MainPage.DisplayAlert("Aviso", "Você não possui pedidos no momento, tente novamente mais tarde", "OK");
            }
            else
            {
                App.Current.MainPage.Navigation.PushAsync(new ListaDePedidosView(Pedidos));


                int index = App.Current.MainPage.Navigation.NavigationStack.Count - 1;

                //IMPEDE DUPLO CLIQUE
                if (App.Current.MainPage.Navigation.NavigationStack[index].GetType() != typeof(ListaDePedidosView))
                {
                    App.Current.MainPage.Navigation.PushAsync(new ListaDePedidosView(Pedidos));
                }

            }
        }

        void GoEntregas()
        {
            App.Current.MainPage.Navigation.PushAsync(new EntregasView());
        }

    }
}
