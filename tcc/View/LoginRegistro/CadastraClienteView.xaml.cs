using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using tcc.ViewModel.LoginRegistro;

namespace tcc.View.LoginRegistro
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CadastraClienteView : ContentPage
	{
		public CadastraClienteView ()
		{
			InitializeComponent ();
            BindingContext = new CadastraClienteVM();
		}
	}
}