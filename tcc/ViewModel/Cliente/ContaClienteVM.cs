using System;
using System.Collections.Generic;
using System.Text;
using tcc.Model;
using tcc.Service;
using System.ComponentModel;
using Xamarin.Forms;

namespace tcc.ViewModel.Cliente
{
    class ContaClienteVM: INotifyPropertyChanged
    {
        
        public UsuarioModel _User { get; set; }
        public UsuarioModel User { get { return _User; } set { _User = value; OnPropertyChanged("User"); } }

        public Command AlterarCommand { get; set; }
        public Command ExcluirContaCommand { get; set; }


        public string _Senha { get; set; }
        public string Senha { get { return _Senha; } set { _Senha = value; OnPropertyChanged("Senha"); } }


        public string oldSenha { get; set; }
        ComunicacaoBanco conexao = new ComunicacaoBanco();

        public ContaClienteVM()
        {
            User = new UsuarioModel();
            
            //PARA PREENCHER PLACEHOLDER
            var cpf = Xamarin.Forms.Application.Current.Properties["Cpf_user"].ToString();
            User = conexao.ObterUsuario(cpf);
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
                    StatusRequisicao msg = Service.Service.UpdateClienteService(User);
                    conexao.UpdateUsuario(User);
                }
                catch
                {
                    App.Current.MainPage.DisplayAlert("Aviso","Erro","OK");
                }

            }
            else
            {
                App.Current.MainPage.DisplayAlert("Alerta", "Senha Incorreta", "OK");
            }
        }

        private void ExcluirConta()
        {
            //TODO - Excluir conta
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
