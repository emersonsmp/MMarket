using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using tcc.Model;
using Xamarin.Forms;
using tcc.View.PerfilMercado;

//PARA TESTES NA APLICAÇÃO-----------
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
//------------------------------------

namespace tcc.ViewModel.Mercado
{
    class ListaDePedidosVM : INotifyPropertyChanged
    {
        public string _Aviso { get; set; }
        public string Aviso  { get { return _Aviso; } set { _Aviso = value; OnPropertyChanged("Aviso"); } }

        public bool _IsVisible { get; set; }
        public bool IsVisible { get { return _IsVisible; } set { _IsVisible = value; OnPropertyChanged("IsVisible"); } }


        public List<Pedido> ListaDePedidos { get; set; }
        public Command<object> GoVerPedidoCommand { get; set; }


        public ListaDePedidosVM(PedidoEntregaModel Pedidos)
        {
            IsVisible = false;
            ListaDePedidos = new List<Pedido>();
            PovoarLista(Pedidos);

            GoVerPedidoCommand = new Command<object>(GoVerPedido);
            Analytics.TrackEvent("Evento Vizualizar pedidos");
            //Crashes.GenerateTestCrash();
        }

        private void PovoarLista(PedidoEntregaModel Pedidos)
        {

           if (Pedidos.quant != 0)
           {      
               List<Pedido> Lista = new List<Pedido>((IEnumerable<Pedido>)Pedidos.pedidos);

               for (int i = 0; i < Lista.Count; i++)
               {
                    ListaDePedidos.Add(Lista[i]);
               }
           }
           else
           {
                Aviso = "Não há pedidos Para serem exibidos aqui";
                IsVisible = true;
           }
        }

        private void GoVerPedido(object obj)
        {
            //PedidosMercado pedido = obj as PedidosMercado;
            //App.Current.MainPage.Navigation.PushAsync(new PedidoView(pedido));

            Pedido pedido = obj as Pedido;
            App.Current.MainPage.Navigation.PushAsync(new PedidoView(pedido));
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
