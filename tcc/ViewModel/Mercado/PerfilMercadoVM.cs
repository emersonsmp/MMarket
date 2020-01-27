using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using tcc.View.PerfilMercado;
using tcc.Model;
using tcc.View.LoginRegistro;

namespace tcc.ViewModel.Mercado
{
    class PerfilMercadoVM
    {

        #region COMMANDS
        public Command GoContaCommand {get; set;}
        public Command GoLeitorCommand { get; set;}
        public Command GoAvaliacoesCommand { get; set;}
        public Command GoLogoutCommand { get; set; }
        public Command GoCuponsCommand { get; set; }
        public Command GoRelatorioCommand { get; set; }
        public Command GoRelatorioDeProdutosCommand { get; set; }

        #endregion
        public PerfilMercadoVM()
        {
            GoContaCommand = new Command(GoConta);
            GoLeitorCommand = new Command(GoLeitor);
            GoAvaliacoesCommand = new Command(GoAvaliacoes);
            GoLogoutCommand  = new Command(GoLogout);
            GoCuponsCommand = new Command(GoCupons);
            GoRelatorioCommand = new Command(GoRelatorio);
            GoRelatorioDeProdutosCommand = new Command(GoRelatoriosProdutos);

        }

        private void GoConta()
        {
            App.Current.MainPage.Navigation.PushAsync(new EditarContaView() );
        }
        private void GoLeitor()
        {
            App.Current.MainPage.Navigation.PushAsync(new LeitorView());
        }
        private void GoAvaliacoes()
        {
            App.Current.MainPage.Navigation.PushAsync(new AvaliacoesView());
        }
        private void GoLogout()
        {
            App.Current.Properties["IsLoggedIn"] = Boolean.FalseString;
            string cnpj = App.Current.Properties["Cnpj_user"].ToString();

            ComunicacaoBanco conexao = new ComunicacaoBanco();
            conexao.RemoveUsuarioMercado(cnpj);
            App.Current.MainPage = new CarroselLogin();
        }

        private void GoCupons()
        {
            App.Current.MainPage.Navigation.PushAsync(new CuponsView());
        }

        private void GoRelatorio()
        {
            App.Current.MainPage.Navigation.PushAsync(new RelatorioView());
        }

        private void GoRelatoriosProdutos()
        {
            App.Current.MainPage.Navigation.PushAsync(new RelatorioDeProdutosView());
        }

    }
}
