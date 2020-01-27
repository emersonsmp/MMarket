using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using tcc.Model;
using System.ComponentModel;

namespace tcc.ViewModel.Mercado
{
    class CadastrarCupomVM : INotifyPropertyChanged
    {
        public Command CadastrarCupomCommand { get; set; }
        public Command PopModalCommand {get; set;}
        public Cupon _cupon { get; set; }
        public Cupon cupon { get { return _cupon; } set { _cupon = value; OnPropertyChanged("cupon"); } }




        public CadastrarCupomVM()
        {
            cupon = new Cupon();
            CadastrarCupomCommand = new Command(CadastrarCupom);
            PopModalCommand = new Command(PopModal);
        }

        private void CadastrarCupom()
        {
            cupon.cnpj = App.Current.Properties["Cnpj_user"].ToString();

            try
            {
                StatusRequisicao resp = Service.Service.CadastraCupom(cupon);
            }
            catch
            {
                App.Current.MainPage.DisplayAlert("Aviso","Erro: Tente novamente","OK");
            }

            App.Current.MainPage.Navigation.PopModalAsync();
        }

        private void PopModal()
        {
            App.Current.MainPage.Navigation.PopModalAsync();
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
