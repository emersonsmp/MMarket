using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using tcc.ViewModel.Mercado;
using tcc.Model;

namespace tcc.View.PerfilMercado
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntregasView : ContentPage
    {
        public EntregasView()
        {
            InitializeComponent();
            BindingContext = new EntregasVM();
        }


        //EXIBIR ALGUMA INFO PARA O VENDEDOR
        private async void MostrarModal(object s, SelectedItemChangedEventArgs e)
        {
            Pedido obj = (Pedido)e.SelectedItem;
        }

    }
}