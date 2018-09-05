using HtmlAgilityPack;
using System;
using System.Text;

namespace Entidades
{
    public class Ticker
    {
        string nombre;
        string codigo;
        string cotizacion;
        string porcentaje;

        private string Nombre
        {
            get
            {
                return this.nombre;
            }

        }

        private string Codigo
        {
            get
            {
                return this.codigo.ToUpper();
            }
        }

        private string Porcentaje
        {
            get
            {
                return this.porcentaje;
            }
        }

        public Ticker(string codigo)
        {
            try
            {
                var html = @"https://finance.yahoo.com/quote/" + codigo;
                HtmlWeb web = new HtmlWeb();
                var htmlDoc = web.Load(html);

                HtmlNode nombreActivo = htmlDoc.DocumentNode.SelectSingleNode("//h1[@class='D(ib) Fz(18px)']");
                HtmlNode cotizActivo = htmlDoc.DocumentNode.SelectSingleNode("//span[@class='Trsdu(0.3s) Fw(b) Fz(36px) Mb(-4px) D(ib)']");
                HtmlNode porcentajeActivo = htmlDoc.DocumentNode.SelectSingleNode("//span[@class='Trsdu(0.3s) Fw(500) Pstart(10px) Fz(24px) C($dataGreen)']");
                
                if(porcentajeActivo == null)
                {
                    porcentajeActivo = htmlDoc.DocumentNode.SelectSingleNode("//span[@class='Trsdu(0.3s) Fw(500) Pstart(10px) Fz(24px) C($dataRed)']");
                }

                if (nombreActivo != null || cotizActivo != null || porcentajeActivo != null)
                {
                    this.nombre = nombreActivo.InnerText;
                    this.cotizacion = cotizActivo.InnerText;
                    this.porcentaje = porcentajeActivo.InnerText;
                    this.codigo = codigo;
                }
                else
                {
                    throw new NullReferenceException("Ticker invalido.");
                }
            }
            catch (Exception)
            {
                throw new Exception("Ticker invalido.");
            }
        }

        public string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("{0}", Nombre));
            sb.AppendLine("====================================================");
            sb.AppendLine(string.Format("${0} || {1}", this.cotizacion, Porcentaje));

            return sb.ToString();
        }

        public static void TeclaEscape()
        {
            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
        }
    }
}
