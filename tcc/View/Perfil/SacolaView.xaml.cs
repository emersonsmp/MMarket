using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using tcc.ViewModel.Cliente;
using tcc.Model;

namespace tcc.View.Perfil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SacolaView : ContentPage
    {
        public SacolaView(string cnpj)
        {
            InitializeComponent();
            BindingContext = new SacolaVM(cnpj);
        }

    }
}