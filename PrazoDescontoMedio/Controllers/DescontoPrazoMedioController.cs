using PrazoDescontoMedio.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace PrazoDescontoMedio.Controllers
{
    [RoutePrefix("api/v1/public")]
    public class DescontoPrazoMedioController : ApiController
    {
        private readonly DBContexto _db = new DBContexto();         

        [HttpGet]
        [Route("geral")]
        public List<Casa> ObterTodas()
        {
            List<Casa> lstCasas = new List<Casa>();
            DataSet ds = new DataSet();

            string dataInicial;

            string dataAtual = (DateTime.Now.Date).ToString("yyyy-MM-dd");

            string ano = (DateTime.Now.Year).ToString();
            string mes = (DateTime.Now.Month).ToString();

            dataInicial = string.Concat(ano, "-0", mes, "-", "01");

            //ViewData["DataInicial"] = string.Concat("01", "-0", mes, "-", ano);
            //ViewData["DataFinal"] = (DateTime.Now.Date.ToString("dd-MM-yyyy"));

            ds = _db.ObterDadosProcedure(dataInicial, dataAtual);

            //Cardiesel
            Casa csCar = new Casa();

            csCar.CodigoEmpresa = "930";
            csCar.DataInicial = dataInicial;
            csCar.DataFinal = dataAtual;
            csCar.DescontoMedio = CalculosPrazoDescontoMedio.DescontoMedio(ds, csCar.CodigoEmpresa);
            csCar.PrazoMedio = CalculosPrazoDescontoMedio.PrazoMedio(ds, csCar.CodigoEmpresa);

            lstCasas.Add(csCar);

            //Auto Sete
            Casa csAut = new Casa();

            csAut.CodigoEmpresa = "1200";
            csAut.DescontoMedio = CalculosPrazoDescontoMedio.DescontoMedio(ds, csAut.CodigoEmpresa);
            csAut.PrazoMedio = CalculosPrazoDescontoMedio.PrazoMedio(ds, csAut.CodigoEmpresa);

            lstCasas.Add(csAut);


            //Calisto
            Casa csCal = new Casa();

            csCal.CodigoEmpresa = "262";
            csCal.DescontoMedio = CalculosPrazoDescontoMedio.DescontoMedio(ds, csCal.CodigoEmpresa);
            csCal.PrazoMedio = CalculosPrazoDescontoMedio.PrazoMedio(ds, csCal.CodigoEmpresa);

            lstCasas.Add(csCal);

            //Goias
            Casa csGo = new Casa();

            csGo.CodigoEmpresa = "2630";
            csGo.DescontoMedio = CalculosPrazoDescontoMedio.DescontoMedio(ds, csGo.CodigoEmpresa);
            csGo.PrazoMedio = CalculosPrazoDescontoMedio.PrazoMedio(ds, csGo.CodigoEmpresa);

            lstCasas.Add(csGo);

            //Posto Imperial
            Casa csPi = new Casa();

            csPi.CodigoEmpresa = "2890";
            csPi.DescontoMedio = CalculosPrazoDescontoMedio.DescontoMedio(ds, csPi.CodigoEmpresa);
            csPi.PrazoMedio = CalculosPrazoDescontoMedio.PrazoMedio(ds, csPi.CodigoEmpresa);

            lstCasas.Add(csPi);

            //Uberlandia
            Casa csUb = new Casa();

            csUb.CodigoEmpresa = "2620";
            csUb.DescontoMedio = CalculosPrazoDescontoMedio.DescontoMedio(ds, csUb.CodigoEmpresa);
            csUb.PrazoMedio = CalculosPrazoDescontoMedio.PrazoMedio(ds, csUb.CodigoEmpresa);

            lstCasas.Add(csUb);

            //Rede Mineira
            Casa csRm = new Casa();

            csRm.CodigoEmpresa = "3610";
            csRm.DescontoMedio = CalculosPrazoDescontoMedio.DescontoMedio(ds, csRm.CodigoEmpresa);
            csRm.PrazoMedio = CalculosPrazoDescontoMedio.PrazoMedio(ds, csRm.CodigoEmpresa);

            lstCasas.Add(csRm);

            //Valadares
            Casa csVl = new Casa();

            csVl.CodigoEmpresa = "260";
            csVl.DescontoMedio = CalculosPrazoDescontoMedio.DescontoMedio(ds, csVl.CodigoEmpresa);
            csVl.PrazoMedio = CalculosPrazoDescontoMedio.PrazoMedio(ds, csVl.CodigoEmpresa);

            lstCasas.Add(csVl);

            //Vadiesel
            Casa csVa = new Casa();

            csVa.CodigoEmpresa = "130";
            csVa.DescontoMedio = CalculosPrazoDescontoMedio.DescontoMedio(ds, csVa.CodigoEmpresa);
            csVa.PrazoMedio = CalculosPrazoDescontoMedio.PrazoMedio(ds, csVa.CodigoEmpresa);

            lstCasas.Add(csVa);

            //string lstCasasJson = JsonConvert.SerializeObject(lstCasas);

            return lstCasas;
        }
    }
}
