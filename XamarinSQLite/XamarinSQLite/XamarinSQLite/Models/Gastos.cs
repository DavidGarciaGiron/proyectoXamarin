using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace XamarinSQLite.Models
{
    class Gastos
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string FechaGasto { get; set; }
        public string Monto { get; set; }
        public string TipoGasto { get; set; }


        public override string ToString()
        {
            return "Se Gasto S/." + this.Monto +
                   " en " + this.TipoGasto;
        }

    }
}
