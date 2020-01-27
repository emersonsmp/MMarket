using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using tcc.Model;
using tcc.Service;
using tcc.View.PerfilMercado;

namespace tcc.ViewModel.Mercado
{
    class LeitorVM : INotifyPropertyChanged
    {
        public ICommand ScanNext { get; private set; }
        public RespostaProdutoLeitorModel produto { get; set; }

        public LeitorVM()
        {
            produto = new RespostaProdutoLeitorModel();
            ScanNext = new Command(() => scanNext());

            //FIZ PARA ACELERAR O JSONCONVERT, PQ NA PRIMEIRA VEZ E LENTO;
            //Task.Factory.StartNew(() => { var o = JsonConvert.DeserializeObject<Produto>("nome:pedro"); });
        }

        #region variaveis propertychaged's
        private ZXing.Result result;
        public ZXing.Result Result
        {
            get { return this.result; }
            set
            {
                if (!string.Equals(this.result, value))
                {
                    this.result = value;
                    this.OnPropertyChanged(nameof(Result));
                }
            }
        }

        public bool _isScanning = true;
        public bool IsScanning
        {
            get { return this._isScanning; }
            set
            {
                if (!bool.Equals(this._isScanning, value))
                {
                    this._isScanning = value;
                    this.OnPropertyChanged(nameof(IsScanning));
                }
            }
        }

        public bool _isAnalyzing = true;
        public bool IsAnalyzing
        {
            get { return this._isAnalyzing; }
            set
            {
                if (!bool.Equals(this._isAnalyzing, value))
                {
                    this._isAnalyzing = value;
                    this.OnPropertyChanged(nameof(IsAnalyzing));
                }
            }
        }
        #endregion


        public Command OnBarcodeScannedCommand
        {

            get
            {
                return new Command(() =>
                {
                    IsAnalyzing = false;

                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        string cnpj = App.Current.Properties["Cnpj_user"].ToString();

                        try
                        {
                            produto = Service.Service.BuscaProduto(cnpj, result.Text);
                            await App.Current.MainPage.Navigation.PushModalAsync(new AddProdutoView(produto));

                        }
                        catch
                        {
                          await  App.Current.MainPage.DisplayAlert("Aviso", "Erro: Tente novamente", "OK");
                        }

                        //scanNext();
                        await App.Current.MainPage.Navigation.PopAsync();
                    });
                });
            }
        }

        public void scanNext()
        {
            IsAnalyzing = true;
            IsScanning  = true;
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
