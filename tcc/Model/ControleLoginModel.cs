using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace tcc.Model
{
    [Table("ControleLoginModel")]
    public class ControleLoginModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public bool logado { get; set; }
        public string tipo_Login { get; set; }
        public string identificacao { get; set; }
    }
}
