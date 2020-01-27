using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using tcc.Model;
using Xamarin.Forms;

namespace tcc.ViewModel.Mercado
{
    class EditarContaVM : INotifyPropertyChanged
    {
        public MercadoModel _User { get; set; }
        public MercadoModel User { get { return _User; } set { _User = value; OnPropertyChanged("User"); } }

        public Command AlterarCommand { get; set; }
        public Command ExcluirContaCommand {get; set;}


        
        public string _Senha { get; set; }
        public string Senha { get { return _Senha; } set { _Senha = value; OnPropertyChanged("Senha"); } }


        public string oldSenha { get; set; }
        ComunicacaoBanco conexao = new ComunicacaoBanco();


        public EditarContaVM()
        {
            User = new MercadoModel();
            

            //PARA PREENCHER PLACEHOLDER
            var cnpj = Xamarin.Forms.Application.Current.Properties["Cnpj_user"].ToString();
            User = conexao.ObterUsuarioMercado(cnpj);
            oldSenha = User.senha;

            AlterarCommand = new Command(UpdateConta);
            ExcluirContaCommand = new Command(ExcluirConta);
        }

        private void UpdateConta()
        {
            if (Senha == oldSenha)
            {
                try
                {
                    StatusRequisicao msg = Service.Service.UpdateMercadoService(User);
                    conexao.UpdateUsuarioMercado(User);
                }
                catch
                {
                    App.Current.MainPage.DisplayAlert("Aviso","Erro: Tente novamente","OK");
                }

            }
            else
            {
                App.Current.MainPage.DisplayAlert("Alerta", "Senha Incorreta", "OK");
            }
        }
        private void ExcluirConta()
        {
            //TODO - Excluir Conta
            try
            {

            }
            catch
            {

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
