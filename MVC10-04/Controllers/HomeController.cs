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
		public ActionResult AddToCarrello(int id,int quantita)
		{
			Ordine a = new Ordine(id,quantita);
			List<Ordine> ordini = Session["ordini"] as List<Ordine>;
			if (ordini == null) {
				ordini = new List<Ordine>();
				}
			ordini.Add(a);
			Session["ordini"] = ordini;
			ViewBag.Message="L'ordine è stato aggiunto al carrello";
			return View("RichiestaOrdine");
		}
		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}
		public ActionResult Carrello()
		{
			List <Ordine> ordini = Session["ordini"] as List<Ordine>;
			if (ordini == null) { return View("RichiestaOrdine");}
			ViewBag.Ordini = ordini;
			return View("Carrello");
		}
		public ActionResult RichiestaOrdine()
		{
			ViewBag.Message = "Inserire il codice dell'articolo o una sua descrizione";
			return View();
		}
		public ActionResult Svuota()
		{
			Session["Ordini"] = null;
			return View("Carrello");
		}
		//[HttpPost]
		//public ActionResult AggiungiAlcarrello(Prodotto prodotto,int quantita)
		//{
		//	List <Ordine> ordine = Session["ordini"] as List<Ordine>;
		//}
		public ActionResult GetDescrizione(int id)
		{
			DomainModel db = new DomainModel();
			ViewBag.Prodotto = db.SearchById(id);
			return View("Risultato");
		}
		[HttpPost]
		public ActionResult RichiestaOrdine(string codice, string descrizione)
		{
			DomainModel db = new DomainModel();
			int cod;
			if(codice != "" && int.TryParse(codice,out cod)) {
				Prodotto prodotto = db.SearchById(cod);
				if (prodotto == null) {
					ViewBag.Message=$"Non è stato trovato alcun prodotto avente codice {cod}";
					return View();
				} 
				ViewBag.Prodotto = prodotto;
				 return View("Risultato");
			} else {
				List<Prodotto> prodotti = db.SearchByDescription(descrizione);
				if (prodotti == null) {return View("Risultato");}
					ViewBag.Prodotti = prodotti;
					return View("RisultatoLista");
			}
		}
	}
}