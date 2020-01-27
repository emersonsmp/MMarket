using System;
using System.Collections.Generic;
using System.Text;
using tcc.Model;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace tcc.Service
{
    class Service
    {

        //LOGIN USUARIOS *
        public static UsuarioModel LoginService(string Email, string Senha)
        {

            FormUrlEncodedContent param = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string,string>("email", Email),
                new KeyValuePair<string,string>("senha", Senha),
            });


            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.PostAsync("https://ganhemais.site/api/LoginCliente.php", param).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                string conteudo = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if (conteudo.Length > 20)
                {

                    UsuarioModel respostaLogin = JsonConvert.DeserializeObject<UsuarioModel>(conteudo);
                    return respostaLogin;

                }
                else
                {
                    return null;
                }

            }
            else
            {
                return null;
            }

        }

        public static MercadoModel LoginMercadoService(string Email, string Senha)
        {
            FormUrlEncodedContent param = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string,string>("email", Email),
                new KeyValuePair<string,string>("senha", Senha),
            });


            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.PostAsync("https://ganhemais.site/api/LoginMercado.php", param).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                string conteudo = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if (conteudo.Length > 20)
                {

                    MercadoModel respostaLogin = JsonConvert.DeserializeObject<MercadoModel>(conteudo);
                    return respostaLogin;

                }

            }

            return null;
        }


        //CADASTRA USUARIOS *
        public static StatusRequisicao CadastroClienteService(string nome, string sobrenome, string cpf, string endereco, string numero, string email, string senha)
        {
            FormUrlEncodedContent param = new FormUrlEncodedContent(new[]{

                new KeyValuePair<string,string>("nome", nome),
                new KeyValuePair<string,string>("sobrenome", sobrenome),
                new KeyValuePair<string,string>("cpf", cpf),
                new KeyValuePair<string,string>("endereco", endereco),
                new KeyValuePair<string,string>("numero", numero),
                new KeyValuePair<string,string>("email", email),
                new KeyValuePair<string,string>("senha", senha),
            });


            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.PostAsync("https://ganhemais.site/api/CadastraCliente.php", param).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {

                string conteudo = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if (conteudo.Length > 20)
                {
                    StatusRequisicao respostaCadastro = JsonConvert.DeserializeObject<StatusRequisicao>(conteudo);
                    return respostaCadastro;
                }

            }

            return null;
        }

        public static StatusRequisicao CadastroMercadoService(string cnpj, string nome, string endereco, string numero, string email, string senha)
        {
            FormUrlEncodedContent param = new FormUrlEncodedContent(new[]{

                new KeyValuePair<string,string>("nome", nome),
                new KeyValuePair<string,string>("cnpj", cnpj),
                new KeyValuePair<string,string>("endereco", endereco),
                new KeyValuePair<string,string>("numero", numero),
                new KeyValuePair<string,string>("email", email),
                new KeyValuePair<string,string>("senha", senha),
            });


            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.PostAsync("https://ganhemais.site/api/CadastraMercado.php", param).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {

                string conteudo = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if (conteudo.Length > 20)
                {
                    StatusRequisicao respostaCadastro = JsonConvert.DeserializeObject<StatusRequisicao>(conteudo);
                    return respostaCadastro;
                }

            }

            return null;
        }

        
        //GET DE LUGARES *
        public static Places GetPlaces()
        {
            string Url2 = "https://ganhemais.site/api/RetornaMercados.php";

            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(Url2);


            Places lugares = new Places();
            //lugares = JsonConvert.DeserializeObject<Places>(Conteudo);
            lugares = Task.Run(() => { return JsonConvert.DeserializeObject<Places>(Conteudo); }).Result;

            return lugares;
        }

        //GET PRODUTOS *
        public static Rootobject GetProdutos(string sessao, string cnpj)
        {

            string NovoEnderecoURL = string.Format("https://ganhemais.site/api/RetornaSecao.php?cnpj={0}&sessao={1}", cnpj, sessao);
            WebClient wc = new WebClient();
            string Conteudo;
            Rootobject produtos = new Rootobject();
            try
            {
                Conteudo = wc.DownloadString(NovoEnderecoURL);
                produtos = JsonConvert.DeserializeObject<Rootobject>(Conteudo);
                return produtos;
            }
            catch
            {
                App.Current.MainPage.DisplayAlert("Atenção","ERRO","OK");
                return produtos;
            }


        }


        //ALTERAR DADOS DE CONTA *
        public static StatusRequisicao UpdateClienteService(UsuarioModel usuario)
        {
            FormUrlEncodedContent param = new FormUrlEncodedContent(new[]{

                new KeyValuePair<string,string>("nome", usuario.nome),
                new KeyValuePair<string,string>("sobrenome", usuario.sobrenome),
                new KeyValuePair<string,string>("cpf", usuario.cpf),
                new KeyValuePair<string,string>("endereco", usuario.endereco),
                new KeyValuePair<string,string>("numero", usuario.numero),
                new KeyValuePair<string,string>("email", usuario.email),
                new KeyValuePair<string,string>("senha", usuario.senha),
            });


            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.PostAsync("https://ganhemais.site/api/UpdateCliente.php", param).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {

                string conteudo = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if (conteudo.Length > 20)
                {
                    StatusRequisicao respostaCadastro = JsonConvert.DeserializeObject<StatusRequisicao>(conteudo);
                    return respostaCadastro;
                }

            }

            return null;
        }

        public static StatusRequisicao UpdateMercadoService(MercadoModel usuario)
        {
            FormUrlEncodedContent param = new FormUrlEncodedContent(new[]{

                new KeyValuePair<string,string>("nome", usuario.nome),
                new KeyValuePair<string,string>("cnpj", usuario.cnpj),
                new KeyValuePair<string,string>("endereco", usuario.endereco),
                new KeyValuePair<string,string>("numero_ed", usuario.numero_ed),
                new KeyValuePair<string,string>("loc_lat", usuario.loc_lat),
                new KeyValuePair<string,string>("loc_lng", usuario.loc_lng),
                new KeyValuePair<string,string>("email", usuario.email),
                new KeyValuePair<string,string>("senha", usuario.senha),
            });


            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.PostAsync("https://ganhemais.site/api/UpdateMercado.php", param).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {

                string conteudo = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if (conteudo.Length > 20)
                {
                    StatusRequisicao respostaCadastro = JsonConvert.DeserializeObject<StatusRequisicao>(conteudo);
                    return respostaCadastro;
                }

            }

            return null;
        }


        //PEDIDOS *
        public static void MudaFlagEntrega(string IdPedido, string status)
        {
            FormUrlEncodedContent param = new FormUrlEncodedContent(new[]{

                new KeyValuePair<string,string>("IdPedido", IdPedido),
                new KeyValuePair<string,string>("status", status)
            });


            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.PostAsync("https://ganhemais.site/api/Pedidos.php", param).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {              
                //
            }
        }

        public static PedidoEntregaModel GetPedidosParaEntrega(string cnpj, string FlagEntrega)
        {
            string urlPedidos = "https://ganhemais.site/api/Pedidos.php?flag={0}&cnpj={1}";
            string NovoEnderecoURL = string.Format(urlPedidos,FlagEntrega, cnpj);

            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NovoEnderecoURL);
            PedidoEntregaModel pedidos = new PedidoEntregaModel();

            try
            {
                pedidos = JsonConvert.DeserializeObject<PedidoEntregaModel>(Conteudo);
            }
            catch
            {
                //PEDIDO NULL - TODA REQUISIÇÃO DEVE RETORNAR ALGO DEVE SER TRATADO NO PHP
                pedidos = null;
                return pedidos;
            }

            return pedidos;
        }



        public static PedidoIndividualModel GetPedido(string IDpedido)
        {
            string urlPedidos = "https://ganhemais.site/api/RetornaPedido.php?id_pedido={0}";
            string NovoEnderecoURL = string.Format(urlPedidos, IDpedido);

            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NovoEnderecoURL);

            PedidoIndividualModel pedidos = JsonConvert.DeserializeObject<PedidoIndividualModel>(Conteudo);
            return pedidos;
        }

        



        // EM RELACAO AO LEITOR DE CODIGO DE BARRA
        // OBS: PADRONIZAR STATUSREQUISICAO DEIXAR BOOL *
        public static RespostaProdutoLeitorModel BuscaProduto(string cnpj, string codigo)
        {
            //COLOCA CODIGO NA URL
            string NovoEnderecoURL = string.Format("https://ganhemais.site/api/LeitorDeBarras.php?cnpj={0}&CodigoBarra={1}", cnpj, codigo);
            WebClient wc = new WebClient();
            //RECEBE JSON
            string Conteudo = wc.DownloadString(NovoEnderecoURL);

            //DESERIALIZA, CONVERTE P/ OBJ
            //Produto produto = JsonConvert.DeserializeObject<Produto>(Conteudo);

            //SEGUNDO DICAS FORUM ACELERA DESERIALIZACÃO
            RespostaProdutoLeitorModel produto = new RespostaProdutoLeitorModel();

            produto = Task.Run(() => {
                produto = JsonConvert.DeserializeObject<RespostaProdutoLeitorModel>(Conteudo);
                return produto;
            }).Result;

            return produto;
        }

        //UPDATE PRODUTO *
        public static StatusRequisicao UpdateProdutoService(string cnpj, string CodigoBarra, string quant, string preco)
        {

            FormUrlEncodedContent param = new FormUrlEncodedContent(new[]{

                new KeyValuePair<string,string>("cnpj", cnpj),
                new KeyValuePair<string,string>("CodigoBarra", CodigoBarra),
                new KeyValuePair<string,string>("quant", quant),
                new KeyValuePair<string,string>("preco", preco),
                new KeyValuePair<string,string>("id", "6")
            });


            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.PostAsync("https://ganhemais.site/api/Produto.php", param).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {

                string conteudo = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if (conteudo.Length > 20)
                {
                    StatusRequisicao respostaCadastro = JsonConvert.DeserializeObject<StatusRequisicao>(conteudo);
                    App.Current.MainPage.DisplayAlert("Atencao", "Item atualizado com sucesso", "OK");
                    return respostaCadastro;
                }

            }

            return null;
        }

        //INSERE PRODUTO *
        public static StatusRequisicao InsereProdutoService(string cnpj, string CodigoBarra, string quant, string preco)
        {
            FormUrlEncodedContent param = new FormUrlEncodedContent(new[]{

                new KeyValuePair<string,string>("cnpj", cnpj),
                new KeyValuePair<string,string>("CodigoBarra", CodigoBarra),
                new KeyValuePair<string,string>("quant", quant),
                new KeyValuePair<string,string>("preco", preco),
                new KeyValuePair<string,string>("id", "5")
            });


            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.PostAsync("https://ganhemais.site/api/Produto.php", param).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {

                string conteudo = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if (conteudo.Length > 20)
                {
                    StatusRequisicao respostaCadastro = JsonConvert.DeserializeObject<StatusRequisicao>(conteudo);
                    App.Current.MainPage.DisplayAlert("Atencao", "Item inserido com sucesso", "OK");
                    return respostaCadastro;
                }

            }

            return null;
        }



        //CUPONS *
        public static CupomModel GetCupons(string cnpj)
        {
            string URL = "https://ganhemais.site/api/Cupom.php?cnpj={0}";
            string NovoURL = string.Format(URL, cnpj);

            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NovoURL);


            CupomModel cupons = new CupomModel();
            cupons = Task.Run(() => { return JsonConvert.DeserializeObject<CupomModel>(Conteudo); }).Result;

            return cupons;
        }

        public static StatusRequisicao CadastraCupom(Cupon cupon)
        {
            FormUrlEncodedContent param = new FormUrlEncodedContent(new[]{

                new KeyValuePair<string,string>("nome", cupon.nome),
                new KeyValuePair<string,string>("validade", cupon.validade),
                new KeyValuePair<string,string>("percent", cupon.percent),
                new KeyValuePair<string,string>("cnpj", cupon.cnpj),
            });


            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.PostAsync("https://ganhemais.site/api/Cupom.php", param).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {

                string conteudo = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if (conteudo.Length > 20)
                {
                    StatusRequisicao respostaCadastro = JsonConvert.DeserializeObject<StatusRequisicao>(conteudo);
                    App.Current.MainPage.DisplayAlert("Atencao", "Cupom inserido com sucesso", "OK");
                    return respostaCadastro;
                }

            }

            return null;
        }

        public static StatusRequisicao EditaCupom(Cupon cupon)
        {
            FormUrlEncodedContent param = new FormUrlEncodedContent(new[]{

                new KeyValuePair<string,string>("IdCupom", cupon.cod),
                new KeyValuePair<string,string>("nome", cupon.nome),
                new KeyValuePair<string,string>("validade", cupon.validade),
                new KeyValuePair<string,string>("percent", cupon.percent),
                new KeyValuePair<string,string>("cnpj", cupon.cnpj),
            });


            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.PostAsync("https://ganhemais.site/api/EditarCupom.php", param).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {

                string conteudo = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if (conteudo.Length > 20)
                {
                    StatusRequisicao respostaCadastro = JsonConvert.DeserializeObject<StatusRequisicao>(conteudo);
                    App.Current.MainPage.DisplayAlert("Atencao", "Item inserido com sucesso", "OK");
                    return respostaCadastro;
                }

            }

            return null;
        }

        public static StatusRequisicao ExcluirCupom(string id)
        {
            FormUrlEncodedContent param = new FormUrlEncodedContent(new[]{

                new KeyValuePair<string,string>("IdCupom", id),
            });


            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.PostAsync("https://ganhemais.site/api/ExcluirCupom.php", param).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {

                string conteudo = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if (conteudo.Length > 20)
                {
                    StatusRequisicao respostaCadastro = JsonConvert.DeserializeObject<StatusRequisicao>(conteudo);
                    App.Current.MainPage.DisplayAlert("Atencao", "Item inserido com sucesso", "OK");
                    return respostaCadastro;
                }

            }

            return null;
        }


        //RELATORIOS *
        public static RelatorioModel GetRelatorio(string cnpj)
    {
        string urlRelatorio = "https://ganhemais.site/api/RelatorioMercado.php?cnpj={0}&status=3";
        string NovoEnderecoURL = string.Format(urlRelatorio, cnpj);

        WebClient wc = new WebClient();
        string Conteudo = wc.DownloadString(NovoEnderecoURL);
        RelatorioModel relatorio = JsonConvert.DeserializeObject<RelatorioModel>(Conteudo);
        return relatorio;
    }

        public static RelatorioClienteModel GetRelatorioCliente(string cpf)
        {
            string urlRelatorio = "https://ganhemais.site/api/RelatorioCliente.php?cpf={0}";
            string NovoEnderecoURL = string.Format(urlRelatorio, cpf);

            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NovoEnderecoURL);
            RelatorioClienteModel relatorio = JsonConvert.DeserializeObject<RelatorioClienteModel>(Conteudo);
            return relatorio;
        }


        //CARRINHO *
        public static Id_pedido EnviaItemParacarrinho(string cpf, string id_pedido, Produto produto)
        {
            FormUrlEncodedContent param = new FormUrlEncodedContent(new[]{

                new KeyValuePair<string,string>("id_pedido", id_pedido),
                new KeyValuePair<string,string>("cpf", cpf),
                new KeyValuePair<string,string>("cnpj", produto.cnpj),
                new KeyValuePair<string,string>("cod_barra", produto.cod_barra),
                new KeyValuePair<string,string>("quant", produto.quantidade),
            });


            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.PostAsync("https://ganhemais.site/api/Carrinho.php", param).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {

                string conteudo = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if (conteudo.Length > 20)
                {
                    Id_pedido resp = JsonConvert.DeserializeObject<Id_pedido>(conteudo);
                    return resp;
                }

            }

            return null;
        }

        public static void RemoveItemCarrinho(string itemid)
        {
            FormUrlEncodedContent param = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string,string>("itemid", itemid),
            });

            HttpClient requisicao = new HttpClient();

            try
            {
                HttpResponseMessage resposta = requisicao.PostAsync("https://ganhemais.site/api/RemoveItemCarrinho.php", param).GetAwaiter().GetResult();

                if (resposta.StatusCode == HttpStatusCode.OK)
                {
                    App.Current.MainPage.DisplayAlert("Atenção", "Service:Item removido", "ok");
                }
                else
                {
                    App.Current.MainPage.DisplayAlert("Atenção", "Service:Não Revovido", "ok");
                }
            }
            catch
            {
                App.Current.MainPage.DisplayAlert("Atenção","Service: ERRO","ok");
            }

        }

        public static SacolaModel GetSacola(string cpf, string cnpj)
        {
            string url = "https://ganhemais.site/api/Carrinho.php?cpf={0}&cnpj={1}";
            string NovoEnderecoURL = string.Format(url,cpf,cnpj);

            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NovoEnderecoURL);
            SacolaModel resp = JsonConvert.DeserializeObject<SacolaModel>(Conteudo);
            return resp;
        }

        public static void FinalizaSacola(string cpf, string cnpj, string metodo, string troco = null)
        {
            FormUrlEncodedContent param = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string,string>("cpf", cpf),
                new KeyValuePair<string,string>("metodo",  metodo),
                new KeyValuePair<string,string>("troco", troco),
                new KeyValuePair<string,string>("cnpj", cnpj),
            });


            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.PostAsync("https://ganhemais.site/api/FinalizaPedido.php", param).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
               App.Current.MainPage.DisplayAlert("Atencao", "Seu Pedido Foi Solicitado", "OK");
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Atencao", "ERRO", "OK");
            }

        }


        //RASTREIO DE PEDIDOS *
       public static RastreioModel Rastreio(string cpf)
        {
            string url = "https://ganhemais.site/api/RastrearPedidos.php?cpf={0}";
            string NovoEnderecoURL = string.Format(url, cpf);

            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NovoEnderecoURL);
            RastreioModel resp = JsonConvert.DeserializeObject<RastreioModel>(Conteudo);
            return resp;
        }


        //AVALIAÇÃO *
        public static AvaliacoesModel GetAvaliacoes(string cpf)
        {
            string url = "https://ganhemais.site/api/Avaliacao.php?cnpj={0}";
            string NovoEnderecoURL = string.Format(url, cpf);

            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NovoEnderecoURL);
            AvaliacoesModel resp = JsonConvert.DeserializeObject<AvaliacoesModel>(Conteudo);
            return resp;
        }

        public static void Postavaliacao(string cpf, string cnpj, string estrelas, string avaliacao)
        {
            FormUrlEncodedContent param = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string,string>("cpf", cpf),
                new KeyValuePair<string,string>("cnpj", cnpj),
                new KeyValuePair<string,string>("estrelas", estrelas),
                new KeyValuePair<string,string>("avaliacao", avaliacao),
            });


            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.PostAsync("https://ganhemais.site/api/Avaliacao.php ", param).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                App.Current.MainPage.DisplayAlert("Atencao", "Avaliação realizada com sucesso!", "OK");
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Atencao", "Tente novamente", "OK");
            }

        }
    }
}
