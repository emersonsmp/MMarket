using System;
using System.Collections.Generic;
using System.Text;
using tcc.Model;

namespace tcc.ViewModel.Mercado
{
    class AvaliacoesVM
    {
        public List<Avaliacoes> ListaDeAvaliacoes { get; set; }
        public string aviso { get; set; }
        public string rating { get; set; }
        public AvaliacoesVM()
        {
            ListaDeAvaliacoes = new List<Avaliacoes>();
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
                    rating = Resp.rating;
                    List<Avaliacoes> Lista = new List<Avaliacoes>((IEnumerable<Avaliacoes>)Resp.avaliacoes);

                    for (int i = 0; i < Lista.Count; i++)
                    {
                        ListaDeAvaliacoes.Add(Lista[i]);
                    }
                }
                else
                {

                    aviso = "Você Não possui avaliações";
                }
            }
            catch
            {
                aviso = "Você Não possui avaliações";
                //App.Current.MainPage.DisplayAlert("ERRO", "Tente novamente mais tarde", "ok");
            }
        }
    }

       
}
