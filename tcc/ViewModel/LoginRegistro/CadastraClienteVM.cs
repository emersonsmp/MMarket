using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;
using tcc.Model;
using tcc.View.LoginRegistro;


namespace tcc.ViewModel.LoginRegistro
{
    class CadastraClienteVM
    {
        public Command GoCadastrarCommand { get; set; }
        public Command BackToLoginCommand { get; set; }
        public UsuarioModel Usuario { get; set; }

        public CadastraClienteVM()
        {
            Usuario = new UsuarioModel();
            GoCadastrarCommand = new Command(GoCadastro);
            BackToLoginCommand = new Command(BackToLogin);
        }

        private void GoCadastro()
        {
            if (Usuario.nome == null || Usuario.sobrenome == null || Usuario.cpf == null || Usuario.endereco == null || Usuario.numero == null || Usuario.email == null || Usuario.senha == null )
            {
                App.Current.MainPage.DisplayAlert("Aviso", "Preencha todos os campos", "OK");
            }
            else
            {
                StatusRequisicao Resp = new StatusRequisicao();
                Resp = Service.Service.CadastroClienteService(Usuario.nome, Usuario.sobrenome, Usuario.cpf, Usuario.endereco, Usuario.numero, Usuario.email, Usuario.senha);

                if (Resp != null)
                {
                    //App.Current.MainPage = new LoginView();
                    //Navigation.PushAsync(new LoginView());
                    App.Current.MainPage.Navigation.PushAsync(new LoginClienteView());
                }
            }

        }
        
        private void BackToLogin()
        {
            App.Current.MainPage = new CarroselLogin();

        }
    }
}
