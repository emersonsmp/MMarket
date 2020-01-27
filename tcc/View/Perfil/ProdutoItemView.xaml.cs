using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using tcc.Model;
using tcc.ViewModel.Cliente;
using System.Globalization;

namespace tcc.View.Perfil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProdutoItemView : ContentPage
    {
        public Produto produto { get; set; }
        public Id_pedido pedido { get; set; }
        public string _cnpj {get; set;}

        public ProdutoItemView(Produto ProdutoSelecionado, string cnpj)
        {
            _cnpj = cnpj;
            InitializeComponent();
            produto = ProdutoSelecionado;
            //BindingContext = new ProdutoItemVM(ProdutoSelecionado);
        }

        private async void OnImageTapped(Object sender, EventArgs e)
        {
            var imagePreview = new ProdutoFullScreen((sender as Image).Source);

            await Navigation.PushModalAsync(new NavigationPage(imagePreview));
        }

        private async void AddNoCarrinho(Object sender, EventArgs e)
        {
            string cpf = App.Current.Properties["Cpf_user"].ToString();
            ComunicacaoBanco database = new ComunicacaoBanco();
            
            //RETORNA Nº DE PEDIDO  0 OU Nº
            pedido = database.GetID_Pedido(cpf);
            produto.quantidade = Quantidade.Text;


            //PRIMEIRO PRODUTO DO CARRINHO, AINDA NÃO POSSUI NUM DE PEDIDO;
            if (pedido.id_pedido == "0")
            {
                //RETORNA O N° DE PEDIDO;
                pedido = Service.Service.EnviaItemParacarrinho(cpf, "0", produto);
                await App.Current.MainPage.DisplayAlert("Aviso", "Produto Adicionado", "OK");
                //SALVA Nº DE PEDIDO NO BD; 
                database.SetID_Pedido(pedido);
            }
            //2° ATÉ O N° PRODUTO ENVIANDO AGORA N° DE PEDIDO;
            else
            {
                Service.Service.EnviaItemParacarrinho(cpf, pedido.id_pedido, produto);
                await App.Current.MainPage.DisplayAlert("Aviso","Produto Adicionado","OK");
            }

        }

        private void GoSacola(Object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new SacolaView(_cnpj));
        }

        private void ActionMudouValor(object sender, ValueChangedEventArgs args)
        {
            Quantidade.Text = args.NewValue.ToString();

            double preco = double.Parse(produto.preco, CultureInfo.InvariantCulture);
            int quant = Convert.ToInt32(Quantidade.Text);

            Total.Text = Convert.ToString(quant * preco);
        }
    }
}