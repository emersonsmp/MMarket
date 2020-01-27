using System;
using System.Collections.Generic;
using System.Text;
using tcc.Model;
using Xamarin.Forms;
using tcc.View.Perfil;
using System.ComponentModel;

namespace tcc.ViewModel.Cliente
{
    class PaginaDeCheckoutVM : INotifyPropertyChanged
    {
        public Command FinalizarpedidoCommand { get; set; }
        public string _cnpj { get; set; }
        public string Total { get; set; }
        public string _TipoPagamento { get; set; }
        public string TipoPagamento { get { return _TipoPagamento; } set { _TipoPagamento = value; OnPropertyChanged("TipoPagamento"); } }

        public string _Troco { get; set; }
        public string Troco { get { return _Troco; } set { _Troco = value; OnPropertyChanged("Troco"); } }

        public Command EditarEntregaCommand   { get; set; }
        public Command EditarPagamentoCommand { get; set; }

        public PaginaDeCheckoutVM(string cnpj, string total)
        {
            _cnpj = cnpj;
            Total = total;
            TipoPagamento = "Escolha a opção";
            FinalizarpedidoCommand = new Command(Finalizarpedido);
            EditarEntregaCommand = new Command(EditarEntrega);
            EditarPagamentoCommand = new Command(EditarPagamento);


            //RECEBER MENSAGEM DO MODAL
            MessagingCenter.Subscribe<ModalPagamentoVM, string>(this, "Metodo", async (sender, arg) =>
            {
                //await App.Current.MainPage.DisplayAlert("Atenção", arg, "ok");
                TipoPagamento = arg;
            });

            //RECEBER MENSAGEM DO MODAL
            MessagingCenter.Subscribe<ModalPagamentoVM, string>(this, "Troco", async (sender, arg) =>
            {
                //await App.Current.MainPage.DisplayAlert("Atenção", arg,"ok");
                Troco = arg;
            });
        }

        private void Finalizarpedido()
        {
            string cpf = App.Current.Properties["Cpf_user"].ToString();

            try
            {
                Service.Service.FinalizaSacola(cpf, _cnpj, TipoPagamento, Troco);
            }
            catch
            {
                App.Current.MainPage.DisplayAlert("Atenção", "Tente Novamente", "ok");
            }


            //APOS FINALIZAR PEDIDO APAGA CACHE DO ID DO PEDIDO
            ComunicacaoBanco database = new ComunicacaoBanco();
            database.RemoveIdPedido(cpf);

            //REDIRECIONAR PARA HOME
            App.Current.MainPage.Navigation.PopToRootAsync();
        }

        private void EditarEntrega()
        {
            App.Current.MainPage.DisplayAlert("Atenção","Entrega","ok");
        }

        private void EditarPagamento()
        {
            App.Current.MainPage.Navigation.PushModalAsync(new ModalPagamentoView());
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
