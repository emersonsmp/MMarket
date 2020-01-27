using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using tcc.ViewModel.Mercado;
using tcc.Model;
using tcc.View.PerfilMercado;

namespace tcc.View.PerfilMercado
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CuponsView : ContentPage
    {
        public CuponsView()
        {
            InitializeComponent();
            BindingContext = new CuponsVM();
        }

        private async void MostraPopUp(object s, SelectedItemChangedEventArgs e)
        {
            Cupon obj = (Cupon)e.SelectedItem;
            var resp = await App.Current.MainPage.DisplayAlert("Deseja Editar o cupom", obj.nome, "Editar","Cancelar");

            if (resp == true)
            {
                //chamar pagina editar cupom
                App.Current.MainPage.Navigation.PushAsync(new EditarCupomView(obj));
            }

        }
    }
}