using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using tcc.ViewModel.Mercado;

namespace tcc.View.PerfilMercado
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AvaliacoesView : ContentPage
    {
        public AvaliacoesView()
        {
            InitializeComponent();
            BindingContext = new AvaliacoesVM();
        }
    }
}