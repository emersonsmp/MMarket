using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using tcc.View.PerfilMercado;

namespace tcc.ViewModel.Mercado
{
    class RelatorioDeProdutosVM
    {
        public Command<object> GoSecaoCommand { get; set; }
        public RelatorioDeProdutosVM()
        {
            GoSecaoCommand = new Command<object>(GoSecao);
        }

        private void GoSecao(object obj)
        {
            string secao = obj as string;
            App.Current.MainPage.Navigation.PushAsync(new SecaoInfoView(secao));
        }
    }
}
