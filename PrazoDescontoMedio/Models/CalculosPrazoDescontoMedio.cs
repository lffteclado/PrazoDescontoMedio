using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PrazoDescontoMedio.Models
{
    public static class CalculosPrazoDescontoMedio
    {
               
        public static int PrazoMedio(DataSet ds, string casa)
        {

            int prazoMedio = 0;
            int somaPrazoMedio = 0;
            int registros = 0;

            //DataTable dt = ds.Tables[0];

            //IEnumerable<DataRow> query = from result in dt.AsEnumerable()
            //                             where result.Field<string>("CodigoEmpresa") == casa
            //                             select result;

            //foreach (DataRow row in query)
            //{
            //    if (row["Prazo"].ToString() != String.Empty)
            //    {
            //          somaPrazoMedio += Int32.Parse(row["Prazo"].ToString());
            //    }                   

            //        registros++;
            //}

            if (ds.Tables.Count > 0) {

                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    if (item["CodigoEmpresa"].ToString() == casa)
                    {
                        if (item["Prazo"].ToString() != String.Empty)
                        {
                            somaPrazoMedio += Int32.Parse(item["Prazo"].ToString());
                        }

                        registros++;
                    }

                }

            }
                      

            if (registros > 0)
            {
                prazoMedio = somaPrazoMedio / registros;
            }     

            return prazoMedio;
        }

        public static decimal DescontoMedio(DataSet ds, string casa)
        {
            decimal descontoMedio = 0;
            decimal somaDescontos = 0;
            int registros = 0;

            if(ds.Tables.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    if (item["CodigoEmpresa"].ToString() == casa)
                    {
                        somaDescontos += Decimal.Parse(item["Desconto"].ToString());

                        registros++;
                    }
                }
            }
                       

            if (registros > 0)
            {
                descontoMedio = (somaDescontos / registros);
                descontoMedio = Decimal.Round(descontoMedio, 2);
            }
                     
            return descontoMedio;
        }
    }
}