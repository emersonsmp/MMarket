using System;
using System.Collections.Generic;
using System.Text;
using tcc.Model;
using Xamarin.Forms;
using tcc.View.Perfil;

namespace tcc.ViewModel.Cliente
{
    class RastreioPedido
    {
        public Command<object> AvaliarMercadoCommand { get; set; }
        public List<Rastreio> ListadePedidos { get; set; }
        //public RastreioModel Resp { get; set; }
        public RastreioPedido()
        {
            ListadePedidos = new List<Rastreio>();
            AvaliarMercadoCommand = new Command<object>(AvaliarMercado);
            PovoaListaDePedidos();
        }

        public bool isvisible { get; set; }

        private void PovoaListaDePedidos()
        {
            string cpf = App.Current.Properties["Cpf_user"].ToString();

            try
            {              
                RastreioModel Resp = Service.Service.Rastreio(cpf);

                if (Resp != null)
                {
                    List<Rastreio> Lista = new List<Rastreio>((IEnumerable<Rastreio>)Resp.Rastreio);

                    for (int i = 0; i < Lista.Count; i++)
                    {
                        if (Lista[i].status == "Entregue")
                        {
                            Lista[i].IsVisible = true;
                        }

                        ListadePedidos.Add(Lista[i]);
                    }
                }
                else
                {
                    App.Current.MainPage.DisplayAlert("Atenção", "Carrinho vazio", "ok");
                }
            }
            catch
            {
                App.Current.MainPage.DisplayAlert("Atenção", "ERRO", "ok");
            }

        }

        private void AvaliarMercado(object obj)
        {
            Rastreio mercado = obj as Rastreio;
            App.Current.MainPage.Navigation.PushAsync(new AvaliarMercadoView(mercado));
        }

    }
}
