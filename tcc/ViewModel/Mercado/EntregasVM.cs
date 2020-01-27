using System;
using System.Collections.Generic;
using System.Text;
using tcc.Model;
using Xamarin.Forms;
using System.ComponentModel;

namespace tcc.ViewModel.Mercado
{
    class EntregasVM: INotifyPropertyChanged
    { 

        public List<Pedido> ListaDeEntregas { get; set; }
        public Command<object> FinalizaEntregaCommand { get; set; }
        public string Aviso {get; set;}
        public bool _IsVisible { get; set; }
        public bool IsVisible { get { return _IsVisible; } set { _IsVisible = value; OnPropertyChanged("IsVisible"); } }

        public EntregasVM()
        {
            IsVisible = false;
            ListaDeEntregas = new List<Pedido>();
            FinalizaEntregaCommand = new Command<object>(FinalizaEntrega);
            PovoarListaItens();
        }

        private void PovoarListaItens()
        {

            string cnpj = App.Current.Properties["Cnpj_user"].ToString();
            PedidoEntregaModel Resp = new PedidoEntregaModel();

            try
            {
                Resp = Service.Service.GetPedidosParaEntrega(cnpj, "2");

                if (Resp == null)
                {
                    IsVisible = true;
                    Aviso = "Sem pedidos em processo de entregas";
                }
                else
                {
                    List<Pedido> Lista = new List<Pedido>((IEnumerable<Pedido>)Resp.pedidos);

                    for (int i = 0; i < Lista.Count; i++)
                    {
                        ListaDeEntregas.Add(Lista[i]);
                    }
                }
            }
            catch
            {
                App.Current.MainPage.DisplayAlert("Atenção", "Erro", "ok");
            }
        }

        private async void FinalizaEntrega(object obj)
        {
            var pedido = obj as Pedido;

            //VERIFICACAO DE SEGURANCA 
            var resp = await App.Current.MainPage.DisplayAlert("Deseja Finalizar o pedido", pedido.idpedido, "SIM", "Cancelar");

            if (resp == true)
            {
                try
                {
                    Service.Service.MudaFlagEntrega(pedido.idpedido, "3");
                    await App.Current.MainPage.DisplayAlert("Atencao", "Pedido Finalizado", "OK");

                    //DESEMPILHA PAGINA ATUAL
                    int TamPilha = App.Current.MainPage.Navigation.NavigationStack.Count;
                    App.Current.MainPage.Navigation.RemovePage(App.Current.MainPage.Navigation.NavigationStack[TamPilha - 1]);
                }
                catch
                {
                    App.Current.MainPage.DisplayAlert("Atenção","ERRO","OK");
                }
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
