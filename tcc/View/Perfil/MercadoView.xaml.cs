using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using tcc.ViewModel.Cliente;
using tcc.Model;
using tcc.View;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace tcc.View.Perfil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MercadoView : ContentPage
    {
        public MercadoView(string cnpj)
        {
            InitializeComponent();
            BindingContext = new MercadoVM(cnpj);
        }
    }
}