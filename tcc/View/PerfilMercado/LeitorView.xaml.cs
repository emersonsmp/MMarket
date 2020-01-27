using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tcc.ViewModel.Mercado;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace tcc.View.PerfilMercado
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LeitorView : ContentPage
    {
        public LeitorView()
        {
            InitializeComponent();
            BindingContext = new LeitorVM();
        }
    }
}