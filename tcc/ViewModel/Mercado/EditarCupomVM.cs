using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using tcc.Model;
using System.ComponentModel;

namespace tcc.ViewModel.Mercado
{
    class EditarCupomVM: INotifyPropertyChanged
    {
        public Command UpdateCupomCommand  {get; set;}
        public Command ExcluirCupomCommand {get; set;}

        //GUARDA DADOS RECEBIDOS
        public Cupon _cupon { get; set; }
        public Cupon cupon { get { return _cupon; } set { _cupon = value; OnPropertyChanged("cupon"); } }


        public EditarCupomVM(Cupon _cupon)
        {
            cupon = _cupon;

            UpdateCupomCommand = new Command(UpdateCupom);
            ExcluirCupomCommand = new Command(ExcluirCupom);
        }

        private void UpdateCupom()
        {
            try
            {
                StatusRequisicao resp = Service.Service.EditaCupom(cupon);
            }
            catch
            {
                App.Current.MainPage.DisplayAlert("Aviso","Erro: Tente novamente","OK");
            }
            
        }

        private void ExcluirCupom()
        {
            
            try
            {
                StatusRequisicao resp = Service.Service.ExcluirCupom(cupon.cod);
            }
            catch
            {
                App.Current.MainPage.DisplayAlert("Aviso", "Erro: Tente novamente", "OK");
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
