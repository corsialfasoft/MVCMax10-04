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
	public partial class DomainModel
	{
	}
	public class Prodotto
	{
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