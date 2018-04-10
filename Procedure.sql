Create Procedure DaiOrdine
	@data date
	as 
	Insert into OrdiniSet(data) values (@data)
	Select IDENT_CURRENT ('OrdiniSet')
	go;

Create Procedure ConfermaOrdine
	@idOrdine int,
	@idProdotto int,
	@Quantita int
as
	declare @trovaordine int = (select top 1 id from OrdiniSet where id=@idOrdine);
	declare @trovaprodotto int;
	set @trovaprodotto = (select top 1 Id from ProdottiSet where Id=@idProdotto);
	if @trovaordine is null or @trovaprodotto is null
	throw 51111 , 'Prodotto od ordine non esistente nel Database',1 ;
	else 
	Insert into OrdiniProdotti (Ordini_Id,Prodotti_Id,quantita) values (@idOrdine,@idProdotto,@Quantita)
	go;