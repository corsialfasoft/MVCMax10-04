using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC10_04.Models
{
	public interface IDomainModel
	{
		Prodotto SearchById(int id);
		List<Prodotto> SearchByDescription(string descrizione);
		void AddCarrello (Prodotto p,int quantità);
		void Ordina(List<Ordine> ordini);
	}
	public partial class DomainModel : IDomainModel
	{
		public void AddCarrello(Prodotto p,int quantità)
		{
			throw new NotImplementedException();
		}

		public void Ordina(List<Ordine> ordini)
		{
			throw new NotImplementedException();
		}

		public List<Prodotto> SearchByDescription(string descrizione)
		{
			List <Prodotto> prodotti = new List<Prodotto>();
			using (var db =new OrdiniEntities()) {
				var query = from product in db.ProdottiSet 
							where product.descrizione.Contains(descrizione)
							select product;
				foreach (var element in query) { 
					Prodotto x = new Prodotto();
					x.ID=element.Id;
					x.Descrizione=element.descrizione;
					prodotti.Add(x);
					}
				return prodotti;
 			}
		}

		public Prodotto SearchById(int id)
		{
			using ( OrdiniEntities db = new OrdiniEntities()) {
				var ricerca = db.ProdottiSet.Find(id);
				Prodotto trovato = new Prodotto();
				if (ricerca != null) {
					trovato.ID = ricerca.Id;
					trovato.Descrizione = ricerca.descrizione;
				}
				return trovato;
			}
		}
	}
	public class Prodotto
	{
		private int _id;
		public int ID {
			get { return _id;}
			set { _id=value;}
		}
		private string _descrizione;
		public string Descrizione {
			get {return _descrizione;}
			set {_descrizione= value;}
		}
		private int _giacenza;
		public int Giancenza {
			get { return _giacenza;}
			set { _giacenza = value;}
		}
		public Prodotto() { }
		public Prodotto(string descrizione)
		{
			this._descrizione=descrizione;
		}
	}
	public class Ordine
	{
		private int _idProdotto;
		private int _quantita;
		public int IdProdotto {
			get { return _idProdotto;}
			set { _idProdotto=value;}
		}
		public int Quantita {
			get { return _quantita;}
			set { _quantita= value;}
		}
	}
}