using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using tcc.View.LoginRegistro;
using tcc.View;
using tcc.View.Perfil;
using tcc.View.PerfilMercado;

//PARA TESTES NA APLICAÇÃO-----------
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
//------------------------------------

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace tcc
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            bool ContainKey = Convert.ToBoolean(Current.Properties.ContainsKey("IsLoggedIn").ToString());

            if (ContainKey)
            {
                string usuario = App.Current.Properties["UserType"].ToString();
                bool isLoggedIn = Convert.ToBoolean(App.Current.Properties["IsLoggedIn"].ToString());

                if (isLoggedIn)
                {
                    if (usuario == "Cliente")
                    {
                        MainPage = new NavigationPage(new PerfilCLienteMaster());
                    }
                    else
                    {
                        MainPage = new NavigationPage(new PerfilMercadoView());
                    }
                }
                else
                {
                    MainPage = new CarroselLogin();
                }
            }
            else
            {
                //PRIMEIRA VEZ QUE APP ESTA RODANDO
                MainPage = new CarroselLogin();
            }

            //MainPage = new CarroselLogin();
            //MainPage = new NavigationPage(new CarroselLogin());
            //MainPage = new PerfilMercadoView();
            //MainPage = new NavigationPage(new PerfilCLienteMaster());
            //MainPage = new NavigationPage(new PerfilMercadoView());
            //MainPage = new NavigationPage(new ModalPagamentoView());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            AppCenter.Start("android=511c1cf4-2fa2-49e1-ae6a-a5c4f38bf7f5;",
            typeof(Analytics), typeof(Crashes));

            //AppCenter.Start("511c1cf4-2fa2-49e1-ae6a-a5c4f38bf7f5", typeof(Push));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
