using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;
using System.ComponentModel;

using tcc.Model;
using tcc.View.LoginRegistro;

namespace tcc.ViewModel.LoginRegistro
{
    class CadastraMercadoVM
    {
        public Command GoCadastroMercadoCommand { get; set; }
        public Command BackLoginCommand { get; set; }
        public MercadoModel Mercado { get; set; }

        public CadastraMercadoVM()
        {
            GoCadastroMercadoCommand = new Command(GoCadastroMercado);
            BackLoginCommand = new Command(BackLogin);
            Mercado = new MercadoModel();
        }

        private void GoCadastroMercado()
        {
            if (Mercado.cnpj == null || Mercado.nome == null || Mercado.endereco == null || Mercado.numero_ed == null || Mercado.email == null || Mercado.senha == null)
            {
                App.Current.MainPage.DisplayAlert("Aviso", "Preencha todos os campos", "OK");

            }else
            {
                StatusRequisicao resp = new StatusRequisicao();
                resp = Service.Service.CadastroMercadoService(Mercado.cnpj, Mercado.nome, Mercado.endereco, Mercado.numero_ed, Mercado.email, Mercado.senha);

                if (resp != null)
                {
                    App.Current.MainPage = new LoginMercadoView();

                }
            }
        }

        private void BackLogin()
        {
            //App.Current.MainPage = new CarroselLogin();
            App.Current.MainPage.Navigation.PopModalAsync();

        }
    }
}
