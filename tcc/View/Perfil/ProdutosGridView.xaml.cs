using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using tcc.ViewModel;
using tcc.Model;
using System.ComponentModel;

namespace tcc.View.Perfil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProdutosGridView : ContentPage
    {

        public string _TituloPagina { get; set; }

        private const uint AnimationDurantion = 250;

        private TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
        public string _cnpj { get; set; }
        public string Titulo { get; set; }

        public List<Produto> collection;

        public ProdutosGridView(string Sessao, string cnpj)
        {
            BindingContext = this;
            Titulo = Sessao;


            collection = new List<Produto>();
            _cnpj = cnpj;
            InitializeComponent();
            PreencheProdutos(Sessao, cnpj);
        }

        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            tapGestureRecognizer.Tapped += BannerClicado;
            EcommerceProductGridBanner.GestureRecognizers.Add(tapGestureRecognizer);
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            tapGestureRecognizer.Tapped -= BannerClicado;
            EcommerceProductGridBanner.GestureRecognizers.Remove(tapGestureRecognizer);
        }
      

        List<Place2> ProdutosList = new List<Place2>();

        private void PreencheProdutos(string sessao, string cnpj)
        {
            var column = LeftColumn;
            var productTapGestureRecognizer = new TapGestureRecognizer();
            productTapGestureRecognizer.Tapped += GoItemView;

            try
            {
                //CHAMAR SERVIÇO PEGAR PRODUTOS
                Rootobject resp = Service.Service.GetProdutos(sessao, cnpj);

                if (resp != null)
                {
                    collection = new List<Produto>((IEnumerable<Produto>)resp.produto);

                    for (var i = 0; i < collection.Count; i++)
                    {
                        var item = new TemplateProduto();

                        if (i > 0)
                        {
                            if (i % 2 == 0)
                            {
                                column = LeftColumn;
                            }
                            else
                            {
                                column = RightColumn;
                            }
                        }

                        collection[i].ThumbnailHeight = "120";
                        item.BindingContext = collection[i];
                        item.GestureRecognizers.Add(productTapGestureRecognizer);
                        column.Children.Add(item);
                    }

                }
                else
                {
                    App.Current.MainPage.DisplayAlert("Atenção", "O Mercado não possui itens nesta sessão", "OK");
                }
            }
            catch
            {
                App.Current.MainPage.DisplayAlert("Atenção", "ERRO", "OK");
            }

        }

        //CHAMA O VIEW INDIVIDUAL DO PRODUTO
        private async void GoItemView(Object sender, EventArgs e)
        {
            Produto ItemSelecionado = (Produto)((TemplateProduto)sender).BindingContext;

            //ENVIA O ITEN E CNPJ PARA PAGINA DE ITEN
            var productView = new ProdutoItemView(ItemSelecionado, _cnpj)
            {
                BindingContext = ItemSelecionado
            };

            //EMPILHA PAGINA POVOADA COM ITEM SELECIONADO
            await App.Current.MainPage.Navigation.PushAsync(productView);
        }

        //TRATAMENTO DE CLIQUE DE BANNER
        private async void BannerClicado(Object sender, EventArgs e)
        {
            var visualElement = (VisualElement)sender;

            await Task.WhenAll(
                visualElement.FadeTo(0,  AnimationDurantion, Easing.CubicIn),
                visualElement.ScaleTo(0, AnimationDurantion, Easing.CubicInOut)
            );

            visualElement.HeightRequest = 0;
            EcommerceProductGridBanner.IsVisible = false;
        }

        private void GoSacola(Object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new SacolaView(_cnpj));
        }

        /*private void PesquisarBotao(object sender, EventArgs args)
        {
            var column = LeftColumn;
            var productTapGestureRecognizer = new TapGestureRecognizer();
            productTapGestureRecognizer.Tapped += GoItemView;

            var palavra = ((SearchBar)sender).Text;
            //App.Current.MainPage.DisplayAlert("Atenção",palavra,"OK");

            //var resultado = collection.Where(a => a.nome.Contains(((SearchBar)sender).Text)).ToList<String>();
            List<Produto> resultado = collection.Where(a => a.nome.IndexOf(palavra, StringComparison.OrdinalIgnoreCase) != -1).ToList();

            LeftColumn.Children.Clear();
            RightColumn.Children.Clear();

            for (var i = 0; i < resultado.Count; i++)
            {
                var item = new TemplateProduto();

                if (i > 0)
                {
                    if (i % 2 == 0)
                    {
                        column = LeftColumn;
                    }
                    else
                    {
                        column = RightColumn;
                    }
                }

                resultado[i].ThumbnailHeight = "120";
                item.BindingContext = resultado[i];
                item.GestureRecognizers.Add(productTapGestureRecognizer);
                column.Children.Add(item);
            }
        }*/

        private void Pesquisar(object sender, TextChangedEventArgs args)
        {
            List<Produto> resultado = collection.Where(a => a.nome.IndexOf(args.NewTextValue, StringComparison.OrdinalIgnoreCase) != -1).ToList();

            var column = LeftColumn;
            var productTapGestureRecognizer = new TapGestureRecognizer();
            productTapGestureRecognizer.Tapped += GoItemView;

            LeftColumn.Children.Clear();
            RightColumn.Children.Clear();

            for (var i = 0; i < resultado.Count; i++)
            {
                var item = new TemplateProduto();

                if (i > 0)
                {
                    if (i % 2 == 0)
                    {
                        column = LeftColumn;
                    }
                    else
                    {
                        column = RightColumn;
                    }
                }

                resultado[i].ThumbnailHeight = "120";
                item.BindingContext = resultado[i];
                item.GestureRecognizers.Add(productTapGestureRecognizer);
                column.Children.Add(item);
            }

        }
    }
}