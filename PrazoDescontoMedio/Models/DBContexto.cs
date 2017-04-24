using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Configuration;
using System.Xml;

namespace PrazoDescontoMedio.Models
{
    public class DBContexto
    {
        //IQueryable<Casa> lstPlanos;


        public DataSet ObterDadosProcedure(string dataInicial, string dataFinal)
        {
            ConnectionStringSettings getString = WebConfigurationManager.ConnectionStrings["ConnDB"] as ConnectionStringSettings;

            DataSet ds = new DataSet();

            if (getString != null)
            {               
                using (SqlConnection con = new SqlConnection(getString.ConnectionString))
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("testespDesconto", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DataInicial", dataInicial);
                        cmd.Parameters.AddWithValue("@DataFinal", dataFinal);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        con.Open();

                        da.Fill(ds);
                    }
                    catch (Exception e)
                    {
                        string msg = e.Message;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }

            return ds;
        }
        /*
        public List<Casa> ObterPlanos()
        {
            //Obtendo os Planos das Casas do Server 242
            ObterPlanoServer242();

            ConnectionStringSettings getString = WebConfigurationManager.ConnectionStrings["DBMOC"] as ConnectionStringSettings;

            if (getString != null)
            {
                string sSQL = "select * from vwCheckVDL";

                using (SqlConnection con = new SqlConnection(getString.ConnectionString))
                {

                    SqlDataReader r = null;
                    SqlCommand cmd = new SqlCommand(sSQL, con);

                    con.Open();

                    r = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    while (r.Read())
                    {
                        StatusPlanos plano = new StatusPlanos();

                        plano.CodEmpresa = r["CodEmpresa"].ToString();
                        plano.NomeEmpresa = r["NomeEmpresa"].ToString();
                        plano.Local = r["Local"].ToString();
                        plano.PlanoBloqueio = r["PlanoBloqueio"].ToString();
                        plano.VendaAbaixoCusto = r["VendaAbaixoCusto"].ToString();
                        plano.DescontoMinimo = r["DescontoMinimo"].ToString();
                        plano.ValorDescMinimo = string.Format("{0:C}", r["ValorDescMinimo"]);

                        lstPlanos.Add(plano);

                    }

                    return lstPlanos;
                }
            }

            return null;
        }

        public XML ObterXML(string nota, string casa)
        {
            ConnectionStringSettings getString = WebConfigurationManager.ConnectionStrings["ConnDB"] as ConnectionStringSettings;

            XML conteudoXML = new XML();
            string banco = string.Empty;
            switch (casa)
            {
                case "1200":
                    banco = "dbAutosete";
                    break;

                case "262":
                    banco = "dbCalisto";
                    break;

                case "930":
                    banco = "dbCardiesel_I";
                    break;

                case "2630":
                    banco = "dbGoias";
                    break;

                case "2890":
                    banco = "dbPostoImperialDP";
                    break;

                case "2620":
                    banco = "dbUberlandia";
                    break;

                case "3610":
                    banco = "dbRedeMineira";
                    break;

                case "130":
                    banco = "dbVadiesel";
                    break;

                case "260":
                    banco = "dbValadaresCNV";
                    break;

                case "3140":

                    getString = WebConfigurationManager.ConnectionStrings["DBMOC"] as ConnectionStringSettings;

                    banco = "dbMontesClaros";

                    break;


                default:
                    break;
            }

            if (getString != null)
            {
                //string sSQL = "select XmlNFE from tbDMSTransitoNFe where NumeroDocumento like '%"+nota+"%' for xml path";

                string sSQL = "select XmlNFE, NumeroDocumento from " + banco + ".dbo.tbDMSTransitoNFe where NumeroDocumento = '" + nota + "'";

                using (SqlConnection con = new SqlConnection(getString.ConnectionString))
                {

                    SqlDataReader r = null;

                    //XmlReader x = null;

                    SqlCommand cmd = new SqlCommand(sSQL, con);

                    con.Open();

                    r = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    while (r.Read())
                    {
                        conteudoXML.XmlNFE = r["XmlNFE"].ToString();
                        conteudoXML.NumeroDocumento = r["NumeroDocumento"].ToString();
                    }

                    return conteudoXML;
                }

            }
            return null;
        }*/
    }
}