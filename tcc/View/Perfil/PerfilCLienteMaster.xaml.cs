using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using tcc.ViewModel.Cliente;

namespace tcc.View.Perfil
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PerfilCLienteMaster : MasterDetailPage
    {
		public PerfilCLienteMaster ()
		{
			InitializeComponent ();
            BindingContext = new PerfilClienteMasterVM();
        }


        //O QUE OCORRE SE A TELA DESAPARECER
        protected override void OnDisappearing()
        {
            IsPresented = false;
        }

    }
}