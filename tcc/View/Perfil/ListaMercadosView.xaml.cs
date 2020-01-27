using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using tcc.Model;
using tcc.ViewModel.Cliente;

//PARA TESTES NA APLICAÇÃO-----------
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
//------------------------------------

namespace tcc.View.Perfil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaMercadosView : ContentPage
    {

        List<MercadoModel> Lista = new List<MercadoModel>();
        public Places resultObject { get; set; }
        private TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();


        public ListaMercadosView()
        {
            InitializeComponent();
            resultObject = new Places();

            UpdateMap();
            Task.Delay(2000);

            //PARA TESTES DA APLICAÇÃO
            Analytics.TrackEvent("Evento Mapa e Mercados");
        }


        List<Place2> placesList = new List<Place2>();

        private async void UpdateMap()
        {
            try
            {
                Places resultObject = new Places();
                resultObject = Service.Service.GetPlaces();


                //ADICIONEI '2' NA FRENTE PLACE E ADC CAMPO iD
                foreach (var place in resultObject.results)
                {
                    placesList.Add(new Place2
                    {
                        rating = place.rating,
                        PlaceName = place.name,
                        Address = place.vicinity,
                        Location = place.geometry.location,
                        Position = new Position(place.geometry.location.lat, place.geometry.location.lng),
                        cnpj = place.id,
                    }) ;
                }

                MyMap.ItemsSource = placesList;
                //ListaMercados.ItemsSource = placesList;

                var productTapGestureRecognizer = new TapGestureRecognizer();
                productTapGestureRecognizer.Tapped += GoMercado;
                for (int i = 0; i < placesList.Count(); i++)
                {
                    var item = new TemplateListaMercado();
                    item.BindingContext = placesList[i];
                    item.GestureRecognizers.Add(productTapGestureRecognizer);
                    Mercados.Children.Add(item);
                }

                //PEGA A LOCALIZACAO ATUAL E CRIA U RAIO DE OBSERVAÇÃO
                var myposition = await Plugin.Geolocator.CrossGeolocator.Current.GetPositionAsync();
                //MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(myposition.Latitude, myposition.Longitude), Distance.FromKilometers(10)));
                var dis = Xamarin.Forms.Maps.Distance.FromKilometers(0.5);
                MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(myposition.Latitude, myposition.Longitude), dis));

            }
            catch
            {
                _ = App.Current.MainPage.Navigation.PopToRootAsync();
                _ = App.Current.MainPage.DisplayAlert("Atencao", "Erro de rede", "OK");               
            }

        }


        private async void GoMercado(Object sender, EventArgs e)
        {
            TemplateListaMercado place = (TemplateListaMercado)sender;
            Place2 ItemSelecionado = (Place2)((TemplateListaMercado)sender).BindingContext;

            #region SEGUNDA OPCAO DE CODIGO
            /*
            var ItemSelecionado = (object)((TemplateListaMercado)sender).BindingContext;

            var Mercado = new MercadoView()
            {
                BindingContext = ItemSelecionado
            }; */
            #endregion

            //EMPILHA PAGINA POVOADA COM ITEM SELECIONADO
            await App.Current.MainPage.Navigation.PushAsync(new MercadoView( ItemSelecionado.cnpj ));
        }

        private void GoPage(object sender, EventArgs e)
        {
            App.Current.MainPage.DisplayAlert("Atençâo", "Pin Clicado", "OK");
        }
    }
}



     

