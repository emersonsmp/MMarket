using System;
using System.Collections.Generic;
using System.Text;
using tcc.Model;
using Xamarin.Forms;

namespace tcc.ViewModel.Cliente
{
    class ProdutoItemVM
    {
        public Command TesteCommand { get; set; }
        public Produto prod { get; set; }
        public ProdutoItemVM(Produto ProdutoSelecionado)
        {
            prod = ProdutoSelecionado;
            TesteCommand = new Command(teste);
        }

        private void teste()
        {
            App.Current.MainPage.DisplayAlert("atencao", prod.nome, "ok");
        }
    }
}
