using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;
using tcc.Model;
using tcc.View.PerfilMercado;
using tcc.View.LoginRegistro;

namespace tcc.ViewModel.LoginRegistro
{
    class LoginMercadoVM
    {
        public Command GoLoginCommand { get; set; }
        public Command GoCadastroCommand { get; set; }
        public Command GoRecuperaSenhaCommand { get; set; }

        public LoginModel Login { get; set; }

        public LoginMercadoVM()
        {
            Login = new LoginModel();
            GoLoginCommand = new Command(GoLogin);
            GoCadastroCommand = new Command(GoCadastro);
            GoRecuperaSenhaCommand = new Command(GoRecuperaSenha);

        }

        private void GoLogin()
        {
            MercadoModel UsuarioLogando = new MercadoModel();
            UsuarioLogando = Service.Service.LoginMercadoService(Login.email, Login.senha);

            if (UsuarioLogando.cnpj != null)
            {
                //VARIAVEIS PROPERTIES
                App.Current.Properties["IsLoggedIn"] = Boolean.TrueString;
                App.Current.Properties["UserType"] = "Mercado";
                App.Current.Properties["Cnpj_user"] = UsuarioLogando.cnpj;
                Application.Current.SavePropertiesAsync();

                //SALVANDO USUARIO LOGADO NO SQLITE
                ComunicacaoBanco database = new ComunicacaoBanco();
                database.InsereUsuarioMercado(UsuarioLogando);


                //App.Current.MainPage = new PerfilMercadoView();
                //App.Current.MainPage.Navigation.PushAsync(new PerfilMercadoView());
                App.Current.MainPage = new NavigationPage(new PerfilMercadoView());

            }
            else
            {
                App.Current.MainPage.DisplayAlert("ATENCAO","Falha Login","OK");
            }

        }

        private void GoCadastro()
        {
            //App.Current.MainPage.Navigation.PushAsync(new CadastraMercadoView());
            App.Current.MainPage = new CadastraMercadoView();

        }

        private void GoRecuperaSenha()
        {
            //TODO - Funcao recuperar password
            App.Current.MainPage.Navigation.PushModalAsync(new RecuperarSenhaMercado());
        }
    }
}
