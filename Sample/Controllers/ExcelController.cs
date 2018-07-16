using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sample.Controllers
{
    public class ExcelController : Controller
    {
        // GET: Excel
        
            public IList<CrawlerFlight> CrawlerFlights()
            {
            CrawlerFlightEntities db = new CrawlerFlightEntities();
                var ListFlight = db.CrawlerFlights.ToList();
                return ListFlight;
            }
        public ActionResult Index()
        {
            return View(this.CrawlerFlights());
        }
                public ActionResult ExportToExcel()
                {
                    var gv = new GridView();
                    gv.DataSource = this.CrawlerFlights();
                    gv.DataBind();
                    Response.ClearContent();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", "attachment; filename=DemoExcel.xls");
                    Response.ContentType = "application/ms-excel";
                    Response.Charset = "";
                    StringWriter objStringWriter = new StringWriter();
                    HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
                    gv.RenderControl(objHtmlTextWriter);
                    Response.Output.Write(objStringWriter.ToString());
                    Response.Flush();
                    Response.End();
                    return View("Index");
                    //return View();
                }
        }
    }