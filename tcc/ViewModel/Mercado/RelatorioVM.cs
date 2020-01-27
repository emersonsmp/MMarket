using System;
using System.Collections.Generic;
using System.Text;
using tcc.Model;
using Xamarin.Forms;
using tcc.View.PerfilMercado;

namespace tcc.ViewModel.Mercado
{
    class RelatorioVM
    {
        public RelatorioModel Relatorio { get; set; }
        public Command GoPedidosCommand { get; set; }

        public RelatorioVM()
        {
            Relatorio = new RelatorioModel();

            GoPedidosCommand = new Command(GoPedidos);
            Obtemrelatorio();
        }

        private void Obtemrelatorio()
        {
            string cnpj = App.Current.Properties["Cnpj_user"].ToString();
            RelatorioModel resp = new RelatorioModel();

            try
            {
                Relatorio = Service.Service.GetRelatorio(cnpj);
            }
            catch
            {
                App.Current.MainPage.DisplayAlert("Aviso","Erro: Tente novamente","OK");
            }
        }

        private void GoPedidos()
        {
            App.Current.MainPage.Navigation.PushModalAsync(new RelatorioDePedidosViews(Relatorio));
        }
    }
}
