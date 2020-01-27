using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;
using System.Reflection;
using System.IO;
using Newtonsoft.Json;
using Xamarin.Forms.Maps;
using tcc.Model;

namespace tcc
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapsView : ContentPage
    {
        public MapsView()
        {
            InitializeComponent();

            Task.Delay(2000);
            UpdateMap();
        }

        List<Place> placesList = new List<Place>();

        private async void UpdateMap()
        {
            try
            {
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MapsView)).Assembly;
                //Stream stream = assembly.GetManifestResourceStream("tcc.Places.json");
                Stream stream = assembly.GetManifestResourceStream("tcc.Barra.json");
                string text = string.Empty;
                using (var reader = new StreamReader(stream))
                {
                    text = reader.ReadToEnd();
                }

                var resultObject = JsonConvert.DeserializeObject<Places>(text);

                foreach (var place in resultObject.results)
                {
                    placesList.Add(new Place
                    {
                        PlaceName = place.name,
                        Address   = place.vicinity,
                        Location  = place.geometry.location,
                        Position  = new Position(place.geometry.location.lat, place.geometry.location.lng),
                        Icon = place.icon,
                    });
                }

                MyMap.ItemsSource = placesList;
                //PlacesListView.ItemsSource = placesList;
                //var loc = await Xamarin.Essentials.Geolocation.GetLocationAsync();

                //LOCALIZAÇÃO MANUAL
                //MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(-15.876713, -52.318660), Distance.FromKilometers(2)));

                //PEGA A LOCALIZACAO ATUAL
                //var myposition = await Plugin.Geolocator.CrossGeolocator.Current.GetPositionAsync();
                //MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(myposition.Latitude, myposition.Longitude), Distance.FromKilometers(5)));               

            }
            catch
            {
                _ = App.Current.MainPage.DisplayAlert("Atencao", "mensagem de erro", "OK");
            }


        }

    }
}