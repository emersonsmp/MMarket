using System;
using System.Collections.Generic;
using System.Text;
using tcc.Model;
using tcc.View.PerfilMercado;
using Xamarin.Forms;

namespace tcc.ViewModel.Mercado
{
    class CuponsVM
    {
        public CupomModel CupomResp { get; set; }
        public List<Cupon> ListaCuponsView { get; set; }
        public Command NoVoCupomCommand { get; set; }

        public CuponsVM()
        {
            CupomResp = new CupomModel();
            ListaCuponsView = new List<Cupon>();
            //MostraPopUpCommand = new Command(MostraPopUp);
            NoVoCupomCommand = new Command(NoVoCupom);

            PovoarListaCupons();
        }

        private void PovoarListaCupons()
        {

            string cnpj = App.Current.Properties["Cnpj_user"].ToString();
            try
            {
                CupomResp = Service.Service.GetCupons(cnpj);
            }
            catch
            {
                App.Current.MainPage.DisplayAlert("Aviso","Erro: Tente novamente","OK");
            }

            List<Cupon> ListaCupons = new List<Cupon>((IEnumerable<Cupon>)CupomResp.cupons);

            for (int i = 0; i < ListaCupons.Count; i++)
            {
                ListaCuponsView.Add(ListaCupons[i]);
            }
        }

        private void NoVoCupom()
        {
            App.Current.MainPage.Navigation.PushModalAsync(new CadastrarCupomView());
        }
    }
}
