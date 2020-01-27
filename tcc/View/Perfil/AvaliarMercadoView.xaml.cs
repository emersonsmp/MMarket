using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using tcc.ViewModel.Cliente;
using tcc.Model;
//using Rg.Plugins.Popup.Services;

namespace tcc.View.Perfil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AvaliarMercadoView : ContentPage
    { 

        public AvaliarMercadoView(Rastreio mercado)
        {
            InitializeComponent();
            BindingContext = new AvaliarMercadoVM(mercado);
        }

        void Estrela0_clicada(object sender, EventArgs e)
        {
            estrela1.Source = "EstrelaCheia.png";
            estrela2.Source = "EstrelaVazia.png";
            estrela3.Source = "EstrelaVazia.png";
            estrela4.Source = "EstrelaVazia.png";
            estrela5.Source = "EstrelaVazia.png";
        }

        void Estrela1_clicada(object sender, EventArgs e)
        {
            estrela1.Source = "EstrelaCheia.png";
            estrela2.Source = "EstrelaCheia.png";
            estrela3.Source = "EstrelaVazia.png";
            estrela4.Source = "EstrelaVazia.png";
            estrela5.Source = "EstrelaVazia.png";
        }

        void Estrela2_clicada(object sender, EventArgs e)
        {
            estrela1.Source = "EstrelaCheia.png";
            estrela2.Source = "EstrelaCheia.png";
            estrela3.Source = "EstrelaCheia.png";
            estrela4.Source = "EstrelaVazia.png";
            estrela5.Source = "EstrelaVazia.png";
        }

        void Estrela3_clicada(object sender, EventArgs e)
        {
            estrela1.Source = "EstrelaCheia.png";
            estrela2.Source = "EstrelaCheia.png";
            estrela3.Source = "EstrelaCheia.png";
            estrela4.Source = "EstrelaCheia.png";
            estrela5.Source = "EstrelaVazia.png";
        }

        void Estrela4_clicada(object sender, EventArgs e)
        {
            estrela1.Source = "EstrelaCheia.png";
            estrela2.Source = "EstrelaCheia.png";
            estrela3.Source = "EstrelaCheia.png";
            estrela4.Source = "EstrelaCheia.png";
            estrela5.Source = "EstrelaCheia.png";
        }

        void desaparecer(object sender, EventArgs e)
        {
            Container.IsVisible = false;
        }
    }
}