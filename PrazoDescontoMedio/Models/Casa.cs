using System;
using System.Collections;

namespace PrazoDescontoMedio.Models
{
    public class Casa
    {
        public string CodigoEmpresa { get; set; }
        public string CodigoLocal { get; set; }
        public decimal DescontoMedio { get; set; }
        public int PrazoMedio  { get; set; }
        public string DataInicial { get; set; }
        public string DataFinal { get; set; }


        //public Casa(string codigoEmpresa, decimal descontoMedio, int prazoMedio)
        //{
        //    this.CodigoEmpresa = codigoEmpresa;
        //    this.DescontoMedio = descontoMedio;
        //    this.PrazoMedio = prazoMedio;
        //}



        public IList GetDadosGrafico()
        {
            return new ArrayList
            {
                 new { X = DateTime.Now.AddMonths(-5).ToString("MMMM"), Y = 90 },
                 new { X = DateTime.Now.AddMonths(-4).ToString("MMMM"), Y = 190 },
                 new { X = DateTime.Now.AddMonths(-3).ToString("MMMM"), Y = 250 },
                 new { X = DateTime.Now.AddMonths(-2).ToString("MMMM"), Y = 210 },
                 new { X = DateTime.Now.AddMonths(-1).ToString("MMMM"), Y = 300 },
                 new { X = DateTime.Now.ToString("MMMM"), Y = 450 }
            };
        }
    }
}