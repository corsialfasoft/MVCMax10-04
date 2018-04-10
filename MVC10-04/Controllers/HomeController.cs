using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC10_04.Models;

namespace MVC10_04.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult RichiestaOrdine()
		{
			ViewBag.Message = "Inserire il codice dell'articolo o una sua descrizione";
			return View();
		}
		//[HttpPost]
		//public ActionResult AggiungiAlcarrello(Prodotto prodotto,int quantita)
		//{
		//	List <Ordine> ordine = Session["ordini"] as List<Ordine>;
		//}
		[HttpPost]
		public ActionResult RichiestaOrdine(string codice, string descrizione)
		{
			DomainModel db = new DomainModel();
			int cod;
			if(codice != null && int.TryParse(codice,out cod)) {
				Prodotto prodotto = db.SearchById(cod);
				if (prodotto == null) {
					ViewBag.Message=$"Non è stato trovato alcun prodotto avente codice {cod}";
					return View("Risultato");
				} 
				ViewBag.Prodotto = prodotto;
				}
			 return View("Risultato");
			}
		}

}