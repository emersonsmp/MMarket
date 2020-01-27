using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using tcc.Model;
using System.ComponentModel;
using tcc.View.Perfil;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace tcc.ViewModel.Cliente
{
    class AvaliarMercadoVM : INotifyPropertyChanged
    {
        public ObservableCollection<Avaliacoes> _ListaDeAvaliacoes;
        public ObservableCollection<Avaliacoes>  ListaDeAvaliacoes { get { return _ListaDeAvaliacoes; } set { _ListaDeAvaliacoes = value; OnPropertyChanged("ListaDeAvaliacoes"); } }


        public string _aviso { get; set; }
        public string aviso { get { return _aviso; } set { _aviso = value; OnPropertyChanged("aviso"); } }



        public Command RatingCommand { get; set; }
        public Command AvaliarMercadoCommand { get; set; }

        public string Star { get; set; }
        public string avaliacao { get; set; }


        public bool _isRefreshing = false;
        public bool  IsRefreshing{ get { return _isRefreshing; } set { _isRefreshing = value; OnPropertyChanged(nameof(IsRefreshing));}}

        public string CNPJ { get; set; }
        public string NomeMercado { get; set; }

        public AvaliarMercadoVM(Rastreio mercado)
        {
            CNPJ = mercado.cnpj;
            NomeMercado = mercado.mercado;
            RatingCommand = new Command<object>(OnTapped);
            AvaliarMercadoCommand = new Command(AvaliarMercado);

            ListaDeAvaliacoes = new ObservableCollection<Avaliacoes>();
            PovoaListadeAvaliacoes();
        }

        /*public Command RefreshCommand
        {
            get
            {
                return new Command( () =>
                {
                    IsRefreshing = true;

                    PovoaListadeAvaliacoes();

                    IsRefreshing = false;
                });
            }
        } */

        private void OnTapped(object obj)
        {
            Star = obj as string;
        }

        private async void AvaliarMercado()
        {
            try
            {
                string cpf = App.Current.Properties["Cpf_user"].ToString();
                Service.Service.Postavaliacao(cpf, CNPJ, Star, avaliacao);
                
                //Avaliacoes card = new Avaliacoes();
                //card.descricao = avaliacao;
                //card.estrela = Star;
                //card.nome = "Emerson";
                //ListaDeAvaliacoes.Add(card);
            }
            catch
            {
                await App.Current.MainPage.DisplayAlert("Erro","tente novamente mais tarde","ok");
            }

             PovoaListadeAvaliacoes();
        }

        private void PovoaListadeAvaliacoes()
        {
            AvaliacoesModel Resp = new AvaliacoesModel();

            try
            {
                Resp = Service.Service.GetAvaliacoes("111");

                if (Resp != null)
                {
                    List<Avaliacoes> Lista = new List<Avaliacoes>((IEnumerable<Avaliacoes>)Resp.avaliacoes);

                    for (int i = 0; i < Lista.Count; i++)
                    {
                        ListaDeAvaliacoes.Add(Lista[i]);
                    }
                }
                else
                {

                    aviso = "O Mercado Não possui avaliações";
                }
            }
            catch
            {
                aviso = "O Mercado Não possui avaliações";
                //App.Current.MainPage.DisplayAlert("ERRO", "Tente novamente mais tarde", "ok");
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
