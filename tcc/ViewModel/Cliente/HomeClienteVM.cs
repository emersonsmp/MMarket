using System;
using System.Collections.Generic;
using System.Text;

//IMPORTACOES
using Xamarin.Forms;
using System.ComponentModel;
using Xamarin.Essentials;

//PROJETO 
using tcc.Model;
using tcc.View;
using tcc.View.Perfil;
using Android.Locations;
using Android.Content;

namespace tcc.ViewModel.Cliente
{
    class HomeClienteVM : INotifyPropertyChanged
    {

        public Command GoBuscaMercadosCommand  {get; set;}
        public Command GoBuscarEntregasCommand {get; set;}

        public bool _AvisoConexao;
        public bool  AvisoConexao { get { return _AvisoConexao; } set { _AvisoConexao = value; OnPropertyChanged("AvisoConexao"); } }

        public HomeClienteVM()
        {

            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                AvisoConexao = false;
            }
            else
            {
                AvisoConexao = true;
            }

            GoBuscaMercadosCommand  = new Command(GoBuscaMercados);
            GoBuscarEntregasCommand = new Command(GoBuscarEntregas);
        }

        private void GoBuscaMercados()
        {
           
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {

                int index = App.Current.MainPage.Navigation.NavigationStack.Count - 1;
                //IMPEDE DUPLO CLIQUE
                if (App.Current.MainPage.Navigation.NavigationStack[index].GetType() != typeof(ListaMercadosView))
                {
                    App.Current.MainPage.Navigation.PushAsync(new ListaMercadosView());
                }
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Aviso","Sem conexão, tente novamente mais tarde","OK");
            }

        }

        private void GoBuscarEntregas()
        {

            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                int index = App.Current.MainPage.Navigation.NavigationStack.Count - 1;
                //IMPEDE DUPLO CLIQUE
                if (App.Current.MainPage.Navigation.NavigationStack[index].GetType() != typeof(RastreioPedidoView))
                {
                    App.Current.MainPage.Navigation.PushAsync(new RastreioPedidoView());
                }
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Aviso", "Sem conexão, tente novamente mais tarde", "OK");
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
