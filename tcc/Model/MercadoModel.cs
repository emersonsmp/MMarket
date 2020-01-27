using SQLite;
using System;
using System.Collections.Generic;
using System.Text;



//VERIFICAR SE ID NAO VAI CAUSAR PROBLEMAS 

namespace tcc.Model
{
    [Table("MercadoModel")]
    public class MercadoModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string cnpj      { get; set; }
        public string nome      { get; set; }
        public string endereco  { get; set; }
        public string numero_ed { get; set; }
        public string loc_lat   { get; set; }
        public string loc_lng   { get; set; }
        public string email     { get; set; }
        public string senha     { get; set; }

    }
}
