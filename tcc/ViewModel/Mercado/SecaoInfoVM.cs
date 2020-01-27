using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using tcc.Model;
using Xamarin.Forms;

namespace tcc.ViewModel.Mercado
{
    class SecaoInfoVM : INotifyPropertyChanged
    {
        public ObservableCollection<Produto> Lista { get; set; }
        public ObservableCollection<Produto> ListaDeItens { get; set; }


        public ObservableCollection<Produto> _ListaDaBusca {get; set;}
        public ObservableCollection<Produto>  ListaDaBusca { get { return _ListaDaBusca; } set { _ListaDaBusca = value; OnPropertyChanged("ListaDaBusca"); } }


        #region VARIAVEIS 
        public string Aviso { get; set; }
        public string NomeSecao { get; set;}
        #endregion

        //public Command<object> BuscaCommand { get; set; }

        #region FLAG DE VISIBILIDADE
        public bool _IsVisibleLista { get; set; }
        public bool IsVisibleLista { get { return _IsVisibleLista; } set { _IsVisibleLista = value; OnPropertyChanged("IsVisibleLista"); } }

        public bool _IsVisibleAviso { get; set; }
        public bool IsVisibleAviso { get { return _IsVisibleAviso; } set { _IsVisibleAviso = value; OnPropertyChanged("IsVisibleAviso"); } }

        public bool _IsVisibleListaBusca { get; set; }
        public bool IsVisibleListaBusca { get { return _IsVisibleListaBusca; } set { _IsVisibleListaBusca = value; OnPropertyChanged("IsVisibleListaBusca"); } }
        #endregion


        public SecaoInfoVM(string secao)
        {
            Lista =        new ObservableCollection<Produto>();
            ListaDeItens = new ObservableCollection<Produto>();
            ListaDaBusca = new ObservableCollection<Produto>();

            IsVisibleAviso = false;
            IsVisibleLista = false;
            IsVisibleListaBusca = false;

            PovoarLista(secao);
        }

        private void PovoarLista(string secao)
        {
            try
            {
                string cnpj = App.Current.Properties["Cnpj_user"].ToString();
                Rootobject Resp = Service.Service.GetProdutos(secao, cnpj);

                if (Resp != null)
                {
                    //Lista = new List<Produto>(Resp.produto);
                    Lista = new ObservableCollection<Produto>(Resp.produto);

                    NomeSecao = secao;

                    for (int i = 0; i < Lista.Count; i++)
                    {
                        ListaDeItens.Add(Lista[i]);
                    }

                    IsVisibleLista = true;

                }
                else
                {
                    Aviso = "Não há itens na sua sacola de compras";
                    IsVisibleAviso = true;
                }
            }
            catch
            {

            }

        }


        //ESTA FUNCIONANDO TUDO CERTO, TODOS OS TESTES POREM NÃO EXIBE, PROVAVELMENTE ERRO NOTIFYPROPERTY
        public Command BuscaCommand => new Command<string>((string query) =>
        {
            //PESQUISA NA LISTA, IGNORA CASE-SENSITIVE
            List<Produto> resultado = Lista.Where(a => a.nome.IndexOf(query, StringComparison.OrdinalIgnoreCase) != -1).ToList();

            for (int i=0; i < resultado.Count; i++)
            {
                ListaDaBusca.Add(resultado[i]);
                IsVisibleListaBusca = true;
                IsVisibleLista = false;
            }

        });

        public Command PesquisarCommand => new Command<string>((string query) =>
        {
            //PESQUISA NA LISTA, IGNORA CASE-SENSITIVE
            List<Produto> resultado = Lista.Where(a => a.nome.IndexOf(query, StringComparison.OrdinalIgnoreCase) != -1).ToList();

            for (int i = 0; i < resultado.Count; i++)
            {
                ListaDaBusca.Add(resultado[i]);
                IsVisibleListaBusca = true;
                IsVisibleLista = false;
            }

        });

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
