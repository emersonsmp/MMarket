using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;
using System.ComponentModel;
using tcc.Model;
using tcc.View.LoginRegistro;
using tcc.View.Perfil;

namespace tcc.ViewModel.Cliente
{
    class PerfilClienteMasterVM
    {
        ComunicacaoBanco conexao = new ComunicacaoBanco();
        public UsuarioModel usuario { get; set; }
        public Command GoHomeCommand  { get; set; }
        public Command GoContaCommand { get; set; }
        public Command GoLogoutCommand { get; set; }
        public Command GoRelatorioCommand { get; set; }


        public PerfilClienteMasterVM()
        {
            usuario = new UsuarioModel();

            //RECUPERA O USUARIO LOGADO
            var cpf = Xamarin.Forms.Application.Current.Properties["Cpf_user"].ToString();
            usuario = conexao.ObterUsuario(cpf);

            GoContaCommand =  new Command(GoConta);
            GoLogoutCommand = new Command(Logout);
            GoRelatorioCommand = new Command(GoRelatorio);
            
        }

 

        private void GoConta()
        {

            App.Current.MainPage.Navigation.PushAsync(new EditarContaView());

        }

        private void GoRelatorio()
        {
            try
            {
                App.Current.MainPage.Navigation.PushAsync(new RelatorioPedidosView());
            }
            catch
            {
                App.Current.MainPage.DisplayAlert("Atenção","ERRo","OK");
            }
        }

        private void Logout()
        {
            App.Current.Properties["IsLoggedIn"] = Boolean.FalseString;
            Application.Current.SavePropertiesAsync();

            string cpf = Xamarin.Forms.Application.Current.Properties["Cpf_user"].ToString();
            conexao.RemoveUsuario(cpf);
            App.Current.Properties["Cpf_user"] = "";
            App.Current.MainPage = new CarroselLogin();
        }

    }
}
