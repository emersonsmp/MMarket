using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using tcc.View.Perfil;
using System.ComponentModel;

namespace tcc.ViewModel.Cliente
{
    class ModalPagamentoVM : INotifyPropertyChanged
    {
        public Command SendMensageCommand   { get; set; }
        public Command OpcaoDinheiroCommand { get; set; }
        public Command OpcaoCartaoCommand   { get; set; }



        public string troco { get; set; }

        public Color _CorFundoDinheiro { get; set; }
        public Color CorFundoDinheiro { get { return _CorFundoDinheiro; } set { _CorFundoDinheiro = value; OnPropertyChanged("CorFundoDinheiro"); } }

        public Color _CorFundoCartao { get; set; }
        public Color CorFundoCartao { get { return _CorFundoCartao; } set { _CorFundoCartao = value; OnPropertyChanged("CorFundoCartao"); } }

        public string _Metodo { get; set; }
        public string  Metodo { get { return _Metodo; } set { _Metodo = value; OnPropertyChanged("Metodo"); } }

        public ModalPagamentoVM()
        {
            SendMensageCommand = new Command(SendMensage);
            OpcaoDinheiroCommand = new Command(OpcaoDinheiro);
            OpcaoCartaoCommand = new Command(OpcaoCartao);
        }

        public void SendMensage()
        {
            MessagingCenter.Send<ModalPagamentoVM, string>(this, "Metodo", Metodo);
            MessagingCenter.Send<ModalPagamentoVM, string>(this, "Troco" , troco );
            App.Current.MainPage.Navigation.PopModalAsync();
        }

        public void OpcaoDinheiro()
        {
            Metodo = "Dinheiro";
            CorFundoCartao = Color.White;
            CorFundoDinheiro = Color.Green;
        }

        public void OpcaoCartao()
        {
            Metodo = "Cartao";
            CorFundoDinheiro = Color.White;
            CorFundoCartao = Color.Green;
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
