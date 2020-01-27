using System;
using System.Collections.Generic;
using System.Text;
using tcc.Model;
using Xamarin.Forms;

namespace tcc.ViewModel.Cliente
{
    class BuscarEntregasVM
    {
        public List<Rastreio> ListaDePedidos { get; set; }
        public BuscarEntregasVM()
        {
            ListaDePedidos = new List<Rastreio>();
            PovoarListaItens();
        }

        private void PovoarListaItens()
        {

            string cpf = App.Current.Properties["Cpf_user"].ToString();
            RastreioModel Resp = new RastreioModel();

            try
            {
                Resp = Service.Service.Rastreio(cpf);

                if (Resp != null)
                {
                    List<Rastreio> Lista = new List<Rastreio>((IEnumerable<Rastreio>)Resp.Rastreio);

                    for (int i = 0; i < Lista.Count; i++)
                    {
                        ListaDePedidos.Add(Lista[i]);
                    }
                }
                else
                {
                    App.Current.MainPage.DisplayAlert("Atenção", "Você não possui pedidos em aberto", "ok");
                }
            }
            catch
            {
                App.Current.MainPage.DisplayAlert("Atenção", "ERRO", "ok");
            }

        }
    }
}
