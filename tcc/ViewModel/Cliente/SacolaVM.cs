using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using tcc.Model;
using Xamarin.Forms;
using Xamarin.Forms.Core;
using tcc.View.Perfil;
using System.Collections.ObjectModel;

namespace tcc.ViewModel.Cliente
{

    class SacolaVM: INotifyPropertyChanged
    {
        public Command<object> DeleteCommand { get; set; }
        public SacolaModel Resp { get; set; }

        public bool _IsVisibleSacola { get; set;}
        public bool IsVisibleSacola { get { return _IsVisibleSacola; } set { _IsVisibleSacola = value; OnPropertyChanged("IsVisibleSacola"); } }

        public bool _IsVisibleAviso { get; set;}
        public bool IsVisibleAviso { get { return _IsVisibleAviso; } set { _IsVisibleAviso = value; OnPropertyChanged("IsVisibleAviso"); } }

        public ObservableCollection<Itens> _ListaDeItens { get; set; }
        public ObservableCollection<Itens> ListaDeItens { get { return _ListaDeItens; } set { _ListaDeItens = value; OnPropertyChanged("ListaDeItens"); } }

        public string Total { get; set; }
        public string Aviso { get; set; }
        public string Pedido { get; set; }
        public string _cnpj { get; set; }


        public Command FinalizarPedidoCommand { get; set; }

        public SacolaVM(string cnpj)
        {
            _cnpj = cnpj;
            IsVisibleSacola = false;
            IsVisibleAviso  = false;

            Resp = new SacolaModel();
            ListaDeItens = new ObservableCollection<Itens>();

            FinalizarPedidoCommand = new Command(Finalizarpedido);
            PovoarListaItens();


            DeleteCommand = new Command<object>(RemoveDaSacola);
        }

        private void RemoveDaSacola(object obj)
        {
            var item = obj as Itens;
            ListaDeItens.Remove(item);

            try
            {
                Service.Service.RemoveItemCarrinho(item.itemid);
            }
            catch
            {
                App.Current.MainPage.DisplayAlert("Aviso", "Erro, tente novamente", "OK");
            }
        }



        private void PovoarListaItens()
        {

            string cpf = App.Current.Properties["Cpf_user"].ToString();

            try
            {
                Resp = Service.Service.GetSacola(cpf, _cnpj);

                if (Resp != null)
                {
                    //ELEMENTOS DA TELA ID E TOTAL DA COMPRA
                    Total = Resp.total; Pedido = Resp.id;

                    List<Itens> Lista = new List<Itens>((IEnumerable<Itens>)Resp.itens);

                    for (int i = 0; i < Lista.Count; i++)
                    {
                        ListaDeItens.Add(Lista[i]);
                    }

                    IsVisibleSacola = true;
                }
                else
                {
                    Aviso = "Não há itens na sua sacola de compras"; 
                    IsVisibleAviso = true;

                }
            }
            catch
            {
                App.Current.MainPage.DisplayAlert("Atenção", "ERRO", "ok");
            }
            
        }

        private void Finalizarpedido()
        {
            App.Current.MainPage.Navigation.PushAsync(new PaginaDeCheckoutView(_cnpj, Total));
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
