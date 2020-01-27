using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using tcc.View.Perfil;
using tcc.Model;
using tcc.View;

namespace tcc.ViewModel.Cliente
{
    class MercadoVM : INotifyPropertyChanged
    {
        #region DECLARACAO VARIAVEIS
        public string CNPJ { get; set; }
        public string PlaceName { get; set; }

        public string _BannerMercado { get; set; }
        public string  BannerMercado { get { return _BannerMercado; } set { _BannerMercado = value; OnPropertyChanged("BannerMercado"); } }
        #endregion

        #region DECLARACAO COMMANDS
        public Command GoCestaCommand { get; set; }
        public Command GopadariaCommand { get; set; }
        public Command GoAcougueCommand { get; set; }
        public Command GoHortFrut { get; set; }
        public Command GoLatCommand { get; set; }
        public Command GoBebCommand { get; set; }
        public Command GoHigCommand { get; set; }
        public Command GoLimpCommand { get; set; }
        public Command GoPetCommand { get; set; }
        public Command GoJardCommand { get; set; }
        public Command GoSacolaCommand { get; set; }
        #endregion


        public MercadoVM(string cnpj)
        {
            string url = "https://ganhemais.site/api/CapaMercado/{0}.jpg";
            BannerMercado = string.Format(url, cnpj);


            #region CHAMADAS METODOS COMMANDS
            GoCestaCommand    = new Command(GoCesta);
            GopadariaCommand  = new Command(Gopadaria);
            GoAcougueCommand = new Command(GoAcougue);
            GoHortFrut        = new Command(GoHortfrut);
            GoLatCommand      = new Command(GoLat);
            GoBebCommand      = new Command(GoBeb);
            GoHigCommand      = new Command(GoHig);
            GoLimpCommand     = new Command(GoLimp);
            GoPetCommand      = new Command(GoPet);
            GoJardCommand     = new Command(GoJard);
            GoSacolaCommand = new Command(SacolaClicada);
            #endregion           

            CNPJ = cnpj;
        }

        private void SacolaClicada()
        {
            //IR PARA SACOLA
            App.Current.MainPage.Navigation.PushAsync(new SacolaView(CNPJ));
        }

        #region METODOS GO

        void GoCesta()
        {
            App.Current.MainPage.Navigation.PushAsync(new ProdutosGridView("Cesta Básica", CNPJ));
        }

        void Gopadaria()
        {
            App.Current.MainPage.Navigation.PushAsync(new ProdutosGridView("Padaria", CNPJ));

        }

        void GoAcougue()
        {
            App.Current.MainPage.Navigation.PushAsync(new ProdutosGridView("Açougue", CNPJ));
        }

        void GoHortfrut()
        {
            App.Current.MainPage.Navigation.PushAsync(new ProdutosGridView("HortiFruti", CNPJ));
        }

        void GoLat()
        {
            App.Current.MainPage.Navigation.PushAsync(new ProdutosGridView("Laticínios", CNPJ));
        }

        void GoBeb()
        {
            App.Current.MainPage.Navigation.PushAsync(new ProdutosGridView("Bebidas", CNPJ));
        }

        void GoHig()
        {
            App.Current.MainPage.Navigation.PushAsync(new ProdutosGridView("Higiene", CNPJ));
        }

        void GoLimp()
        {
            App.Current.MainPage.Navigation.PushAsync(new ProdutosGridView("Limpeza", CNPJ));
        }

        void GoPet()
        {
            App.Current.MainPage.Navigation.PushAsync(new ProdutosGridView("PetShop", CNPJ));
        }

        void GoJard()
        {
            App.Current.MainPage.Navigation.PushAsync(new ProdutosGridView("Jardinagem", CNPJ));
        }
        #endregion

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
