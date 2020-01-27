using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace tcc.Model
{
    /*public class Produto
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Price { get; set; }
        public string ThumbnailHeight { get; set; }

    }*/


    public class Rootobject
    {
        public Produto[] produto { get; set; }
    }

    public class Produto
    {
        public string cod_barra { get; set; }
        public string nome { get; set; }
        public string peso { get; set; }
        public string descricao { get; set; }
        public string imagem { get; set; }
        public string marca { get; set; }
        public string Tipo { get; set; }
        public string cnpj { get; set; }
        public string quantidade { get; set; }
        public string preco { get; set; }
        public string ThumbnailHeight { get; set; }
    }


    public class RespostaProdutoLeitorModel
    {
        public bool InDB { get; set; }
        public Produto produto { get; set; }
    }

    [Table("Id_pedido")]
    public class Id_pedido
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string cpf { get; set; }
        public string id_pedido { get; set; }
    }



}
