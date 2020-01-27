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
    public partial class EditarCupomView : ContentPage
    {
        public EditarCupomView(Cupon cupon)
        {
            InitializeComponent();
            BindingContext = new EditarCupomVM(cupon);
        }
    }
}