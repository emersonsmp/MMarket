using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using tcc.Model;
using tcc.ViewModel.Mercado;

namespace tcc.View.PerfilMercado
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PedidosView : ContentPage
    {

        //public Command GoPedidoCommand { get; set; }
        public PedidosView(PedidoEntregaModel pedido)
        {
            InitializeComponent();
            UpdatePedidos(pedido);
        }


        private void UpdatePedidos(PedidoEntregaModel pedidos)
        {
            List<Pedido> ListaPedidos = new List<Pedido>((IEnumerable<Pedido>)pedidos.pedidos);
            var productTapGestureRecognizer = new TapGestureRecognizer();
            productTapGestureRecognizer.Tapped += GoPedido;


            for (int i = 0; i < ListaPedidos.Count; i++)
            {
                var item = new TemplatePedido();
                item.BindingContext = ListaPedidos[i];
                item.GestureRecognizers.Add(productTapGestureRecognizer);
                PedidosStackLayout.Children.Add(item);
            }

        }

        private void GoPedido(Object sender, EventArgs e)
        {
            TemplatePedido place = (TemplatePedido)sender;
            Pedido ItemSelecionado = (Pedido)((TemplatePedido)sender).BindingContext;

            //EMPILHA PAGINA POVOADA COM ITEM SELECIONADO
            App.Current.MainPage.Navigation.PushAsync(new PedidoView(ItemSelecionado));
        }


    }
}