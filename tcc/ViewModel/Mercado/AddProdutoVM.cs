using System;
using System.Collections.Generic;
using System.Text;
using tcc.Model;
using Xamarin.Forms;
using tcc.View.PerfilMercado;
using System.ComponentModel;

namespace tcc.ViewModel.Mercado
{
    class AddProdutoVM : INotifyPropertyChanged
    {
        public Command GoAtualizaPrateleiraCommand { get; set; }
        public RespostaProdutoLeitorModel prod { get; set; }

        public string _preco { get; set; }
        public string preco { get { return _preco; } set { _preco = value; OnPropertyChanged("preco"); } }


        public string _quantidade { get; set; }
        public string quantidade { get { return _quantidade; } set { _quantidade = value; OnPropertyChanged("quantidade"); } }

        public string TituloPaginaAddProduto { get; set; }

        public AddProdutoVM(RespostaProdutoLeitorModel produto)
        {
            prod = new RespostaProdutoLeitorModel();
            prod = produto;

            GoAtualizaPrateleiraCommand = new Command(GoAtualizaPrateleira);
        }


        private void GoAtualizaPrateleira()
        {

            string cnpj = App.Current.Properties["Cnpj_user"].ToString();

            if (prod.InDB == true)
            {
                TituloPaginaAddProduto = "Atualizar Produto";
                //UPDATE
                StatusRequisicao resp = new StatusRequisicao();
                try
                {
                    resp = Service.Service.UpdateProdutoService(cnpj, prod.produto.cod_barra, quantidade, preco);
                }
                catch
                {
                    App.Current.MainPage.DisplayAlert("Aviso", "Erro", "OK");
                }

                //int TamPilha = App.Current.MainPage.Navigation.NavigationStack.Count;
                //App.Current.MainPage.Navigation.RemovePage(App.Current.MainPage.Navigation.NavigationStack[TamPilha-2]);
                App.Current.MainPage.Navigation.PopModalAsync();

            }
            else
            {
                TituloPaginaAddProduto = "Novo Produto";

                //INSERT
                StatusRequisicao resp = new StatusRequisicao();
                try
                {
                    resp = Service.Service.InsereProdutoService(cnpj, prod.produto.cod_barra, quantidade, preco);
                }
                catch
                {
                    App.Current.MainPage.DisplayAlert("Aviso", "Erro", "OK");
                }

                App.Current.MainPage.Navigation.PopAsync();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string NameProperty)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(NameProperty));
            }
        }
    }
}
