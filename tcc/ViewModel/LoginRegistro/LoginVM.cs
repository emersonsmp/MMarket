using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;
using tcc.Model;
using tcc.View.LoginRegistro;
using tcc.View.Perfil;

namespace tcc.ViewModel.LoginRegistro
{
    class LoginVM
    {
        public Command GoLoginCommand         { get; set; }
        public Command GoCadastroCommand      { get; set; }
        public Command GoRecuperaSenhaCommand { get; set; }

        public LoginModel Login { get; set; }

        public LoginVM()
        {
            Login = new LoginModel();
            GoLoginCommand = new Command(GoLogin);
            GoCadastroCommand = new Command(GoCadastro);
            GoRecuperaSenhaCommand = new Command(GoRecuperaSenha);

        }

        private void GoLogin()
        {
            //VALIDAÇÃO: SE ALGUM CAMPO FOR NULL NOTIFICA USUARIO
            if (Login.email == null || Login.senha == null)
            {
                App.Current.MainPage.DisplayAlert("Atenção","Preencha todos os campos","OK");
            }
            //LOGIN
            else
            {            
                //TRATAMENTO DE ERROS
                try
                {
                    UsuarioModel UsuarioLogando = new UsuarioModel();
                    UsuarioLogando = Service.Service.LoginService(Login.email, Login.senha);

                    if (UsuarioLogando != null)
                    {
                        //VARIAVEIS PROPERTIES
                        App.Current.Properties["IsLoggedIn"] = Boolean.TrueString;
                        App.Current.Properties["UserType"] = "Cliente";
                        Application.Current.SavePropertiesAsync();
                        App.Current.Properties["Cpf_user"] = UsuarioLogando.cpf;
                        Application.Current.SavePropertiesAsync();

                        //SALVANDO USUARIO LOGADO NO SQLITE
                        ComunicacaoBanco database = new ComunicacaoBanco();
                        database.InsereUsuario(UsuarioLogando);

                        //GOTO PERFIL CLIENTE
                        //App.Current.MainPage = new PerfilCLienteMaster();
                        App.Current.MainPage = new NavigationPage(new PerfilCLienteMaster());
                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("Atenção", "Senha ou email incorretos", "OK");
                    }

                }
                catch (Exception e)
                {
                    App.Current.MainPage.DisplayAlert("Atenção", "Limite de Conexão excedido", "OK");
                }

            }
           
        }

        private void GoCadastro()
        {
            //App.Current.MainPage.Navigation.PushAsync(new CadastraClienteView());
            //App.Current.MainPage = new CadastraClienteView();

            //CHAMA NA FORMA DE MODAL
            App.Current.MainPage.Navigation.PushModalAsync(new CadastraClienteView());

        }

        private void GoRecuperaSenha()
        {
            //TODO - Funcao recuperar password
            App.Current.MainPage.Navigation.PushModalAsync(new RecuperarSenhaCliente());
        }


    }
}
