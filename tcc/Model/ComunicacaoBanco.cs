using System;
using System.Collections.Generic;
using System.Text;

using SQLite;
using System.Linq;
using Xamarin.Forms;

namespace tcc.Model
{
    public class ComunicacaoBanco
    {

        private SQLiteConnection ConexaoCliente;
        private SQLiteConnection ConexaoMercado;
        private SQLiteConnection ConexaoLogin;
        private SQLiteConnection ConexaoPedido;

        public ComunicacaoBanco()
        {

            //CHAMA O DEPENDENCY SERVICE;
            var dep = DependencyService.Get<ICaminho>();
            //SOLICITA O QUE PRECISA SABER O CAMINHO;
            string caminho = dep.ObterCaminho("database.sqlite");


            ConexaoCliente = new SQLiteConnection(caminho);
            ConexaoCliente.CreateTable<UsuarioModel>();

            ConexaoMercado = new SQLiteConnection(caminho);
            ConexaoMercado.CreateTable<MercadoModel>();

            ConexaoLogin = new SQLiteConnection(caminho);
            ConexaoLogin.CreateTable<ControleLoginModel>();

            ConexaoPedido = new SQLiteConnection(caminho);
            ConexaoPedido.CreateTable<Id_pedido>();
        }

        // CLIENTE---------------------------------------------------
        public void InsereUsuario(UsuarioModel usuario)
        {
            ConexaoCliente.Insert(usuario);
        }

        public UsuarioModel ObterUsuario(string cpf_user)
        {
            return ConexaoCliente.Table<UsuarioModel>().Where(a => a.cpf == cpf_user).FirstOrDefault();
        }

        public void RemoveUsuario(string cpf_user)
        {
            UsuarioModel usuario = ConexaoCliente.Table<UsuarioModel>().Where(a => a.cpf == cpf_user).FirstOrDefault();
            ConexaoCliente.Delete(usuario);
        }

        public void UpdateUsuario(UsuarioModel usuario)
        {
            ConexaoCliente.Update(usuario);
        }

        // MERCADO----------------------------------------------------

        public void InsereUsuarioMercado(MercadoModel usuario)
        {
            ConexaoMercado.Insert(usuario);
        }

        public MercadoModel ObterUsuarioMercado(string cnpj_mercado)
        {
            return ConexaoMercado.Table<MercadoModel>().Where(a => a.cnpj == cnpj_mercado).FirstOrDefault();
        }

        public void RemoveUsuarioMercado(string cnpj_mercado)
        {
            MercadoModel mercado = ConexaoMercado.Table<MercadoModel>().Where(a => a.cnpj == cnpj_mercado).FirstOrDefault();
            ConexaoMercado.Delete(mercado);
        }

        public void UpdateUsuarioMercado(MercadoModel mercado)
        {
            ConexaoMercado.Update(mercado);
        }

        // CONTROLE LOGIN----------------------------------------------
        public void Login(ControleLoginModel logador)
        {
            ConexaoLogin.Insert(logador);
        }

        public void Logoff(string identificador)
        {
            ControleLoginModel  logador = ConexaoLogin.Table<ControleLoginModel>().Where(a => a.identificacao == identificador).FirstOrDefault();
            ConexaoLogin.Delete(logador);
        }

        //CONTROLE PEDIDO ----------------------------------------------\/

        public void SetID_Pedido(Id_pedido pedido)
        {
            ConexaoPedido.Insert(pedido);
        }

        public Id_pedido GetID_Pedido(string cpf)
        {
            Id_pedido pedido = new Id_pedido();

            try
            {
                pedido = ConexaoMercado.Table<Id_pedido>().Where(a => a.cpf == cpf).First();
            }
            catch
            {
                pedido.id_pedido = "0";
            }

            return pedido;
        }

        public void RemoveIdPedido(string cpf)
        {
            Id_pedido pedido = ConexaoMercado.Table<Id_pedido>().Where(a => a.cpf == cpf).FirstOrDefault();
            ConexaoPedido.Delete(pedido);
        }

    }
}
