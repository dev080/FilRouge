use FilRouge_essai_modif
go


 --insert de données dans rubrique
 insert into rubrique (NomRubrique) values ('A corde')
 insert into rubrique (NomRubrique) values ('A percussion')
 insert into rubrique (NomRubrique) values ('A de combinaison')
 insert into rubrique (NomRubrique) values ('A Vent')
  insert into rubrique (NomRubrique) values ('electronique au virtuel')

  --insert de données dans sous rubrique
  insert into SousRubrique (NomsousRubrique,IdRubrique) values ('frottées',1)
 insert into SousRubrique (NomsousRubrique,IdRubrique) values ('frappées',1)
 insert into sousrubrique (NomsousRubrique,IdRubrique) values ('pincées',1)
 
 insert into sousrubrique (NomsousRubrique,IdRubrique) values ('clavier',2)
  insert into sousrubrique (NomsousRubrique,IdRubrique) values ('peaux',2)
  insert into sousrubrique (NomsousRubrique,IdRubrique) values ('accesoires',2)

  insert into sousrubrique (NomsousRubrique,IdRubrique) values ('mécanique',3)
  insert into sousrubrique (NomsousRubrique,IdRubrique) values ('claviorganum',3)

   insert into sousrubrique (NomsousRubrique,IdRubrique) values ('biseau',4)
  insert into sousrubrique (NomsousRubrique,IdRubrique) values ('à anche libre',4)

     insert into sousrubrique (NomsousRubrique,IdRubrique) values ('électromécanique',5)
  insert into sousrubrique (NomsousRubrique,IdRubrique) values ('électroanalogiques',5)
  
  --insertion dans produit

   insert into produit (NomProdCourt,NomProdLong,ImageProd,PrixHT_Prod,StockProduit,actifproduit,IdSousRubrique) values ('violon','violon à pavillon','url image',250,100,1,1)
   insert into produit (NomProdCourt,NomProdLong,ImageProd,PrixHT_Prod,StockProduit,actifproduit,IdSousRubrique) values ('trompette marine','instrument de musique de taille humaine','url image',1250,20,1,1)
   insert into produit (NomProdCourt,NomProdLong,ImageProd,PrixHT_Prod,StockProduit,actifproduit,IdSousRubrique) values ('piano',' instrument de musique polyphonique','url image',2250,10,1,2)
   insert into produit (NomProdCourt,NomProdLong,ImageProd,PrixHT_Prod,StockProduit,actifproduit,IdSousRubrique) values ('guitare','Une guitare classique','url image',1250,15,1,3)
   insert into produit (NomProdCourt,NomProdLong,ImageProd,PrixHT_Prod,StockProduit,actifproduit,IdSousRubrique) values ('xylophone','xylo','url image',5000,5,1,4)
    insert into produit (NomProdCourt,NomProdLong,ImageProd,PrixHT_Prod,StockProduit,actifproduit,IdSousRubrique) values ('djembé','africain','url image',100,25,1,5)
	insert into produit (NomProdCourt,NomProdLong,ImageProd,PrixHT_Prod,StockProduit,actifproduit,IdSousRubrique) values ('triangle','idiophone','url image',10,55,1,6)
	insert into produit (NomProdCourt,NomProdLong,ImageProd,PrixHT_Prod,StockProduit,actifproduit,IdSousRubrique) values ('sérinette','primitif assimilable à un orgue','url image',100,5,1,7)
	insert into produit (NomProdCourt,NomProdLong,ImageProd,PrixHT_Prod,StockProduit,actifproduit,IdSousRubrique) values ('orgue et clavecin',' ','url image',1100,2,1,8)
	insert into produit (NomProdCourt,NomProdLong,ImageProd,PrixHT_Prod,StockProduit,actifproduit,IdSousRubrique) values ('flûte','flûte à bec','url image',600,12,0,9)
	insert into produit (NomProdCourt,NomProdLong,ImageProd,PrixHT_Prod,StockProduit,actifproduit,IdSousRubrique) values ('harmonicas','principe de l''accordéon','url image',1600,1,0,10)
	insert into produit (NomProdCourt,NomProdLong,ImageProd,PrixHT_Prod,StockProduit,actifproduit,IdSousRubrique) values ('yamaha CP80','proche piano acoustique','url image',2100,10,0,11)
	insert into produit (NomProdCourt,NomProdLong,ImageProd,PrixHT_Prod,StockProduit,actifproduit,IdSousRubrique) values ('yamaha DX7','synthétiseur','url image',1800,3,1,12)

	--insertion de fournisseurs

	insert into fournisseur (Nomfournisseur) values ('Music store')
	insert into fournisseur (nomfournisseur) values ('Musique import')
	insert into fournisseur (nomfournisseur) values ('Instru & co')
	insert into fournisseur (nomfournisseur) values ('Royez')

	--insertion approvisionner
	insert into Approvisionner (Idproduit, IdFournisseur) values (1,1)
	insert into Approvisionner (Idproduit, IdFournisseur) values (5,1)
	insert into Approvisionner (Idproduit, IdFournisseur) values (8,2)
	insert into Approvisionner (Idproduit, IdFournisseur) values (4,2)
	insert into Approvisionner (Idproduit, IdFournisseur) values (6,4)
	insert into Approvisionner (Idproduit, IdFournisseur) values (13,1)


	
	--Commercial
	insert into Commercial(NomCommercial) values ('Commercial1')
	insert into Commercial (NomCommercial) values ('Commercial2')
	insert into Commercial (NomCommercial) values ('Commercial3')
	insert into Commercial (NomCommercial) values ('Commercial4')



	
	--client
	
	insert into client (CiviliteClient,Nomclient,PrenomClient,CategorieClient,AdrLivraisonClient,AdrFacturationClient,coeffClient,Reduction,IdCommercial) values ('M.','Brown','Jackie','particulier','1 rue des alouettes Perpignan','1 rue des alouettes Perpignan',1,2,1)
	insert into client (CiviliteClient,Nomclient,PrenomClient,CategorieClient,AdrLivraisonClient,AdrFacturationClient,coeffClient,Reduction,IdCommercial) values ('Mme','Delaplace','Rebecca','particulier','60 bis rue du chateau Compiègne','entreprise',1,2,2)
	insert into client (CiviliteClient,Nomclient,PrenomClient,CategorieClient,AdrLivraisonClient,AdrFacturationClient,coeffClient,Reduction,IdCommercial) values ('Melle','Guerin','Alice','professionel','12 rue des chandeliers St-Louis','12 rue des chandeliers St-Louis',1,2,3)
	
	
	
	--Facture
	insert into facture (DateFacture) values ('13/05/2010')



		

	
	--commande
	insert into Commande (EtatCommande,DateCommande,MontantCommande,DatePaiement,IdClient,IdFacture) values ('saisie','11-02-2011',250.00,null,1,null)
	insert into Commande (EtatCommande,DateCommande,MontantCommande,DatePaiement,IdClient,IdFacture) values ('annulée','01-03-2011',1250.00,null,1,null)
	insert into Commande (EtatCommande,DateCommande,MontantCommande,DatePaiement,IdClient,IdFacture) values ('en préparation','01-03-2015',150.00,'02-03-2015',2,null)
	insert into Commande (EtatCommande,DateCommande,MontantCommande,DatePaiement,IdClient,IdFacture) values ('expédiée','10-05-2015',20150.00,'02-06-2015',3,null)
	insert into Commande (EtatCommande,DateCommande,MontantCommande,DatePaiement,IdClient,IdFacture) values ('facturée','11-06-2015',2050.00,'13-06-2015',3,null)
	insert into Commande (EtatCommande,DateCommande,MontantCommande,DatePaiement,IdClient,IdFacture) values ('retard de paiement','11-11-2015',50.90,'20/01/2016',3,null)
	insert into Commande (EtatCommande,DateCommande,MontantCommande,DatePaiement,IdClient,IdFacture) values ('soldée','02-12-2015',650.80,'05-12-2015',3,null)
	
	
	
	--livraison
	insert into Livraison (DateLivraison,IdCommande) values ('02-01-2011',1)
	insert into Livraison (DateLivraison,IdCommande) values ('11-01-2011',2)
	insert into Livraison (DateLivraison,IdCommande) values ('15-02-2011',3)
	insert into Livraison (DateLivraison,IdCommande) values ('15-02-2015',4)
	insert into Livraison (DateLivraison,IdCommande) values ('05-12-2014',5)
	insert into Livraison (DateLivraison,IdCommande) values ('11-04-2013',6)
	insert into Livraison (DateLivraison,IdCommande) values (null,7)



	--composer1
	insert into composer1 (QuantiteProd,IdProduit,IdCommande)values(10,1,1)
	insert into composer1 (QuantiteProd,IdProduit,IdCommande)values(20,2,2)
	insert into composer1 (QuantiteProd,IdProduit,IdCommande)values(05,13,3)
	insert into composer1 (QuantiteProd,IdProduit,IdCommande)values(100,4,4)
	insert into composer1 (QuantiteProd,IdProduit,IdCommande)values(210,8,5)
	insert into composer1 (QuantiteProd,IdProduit,IdCommande)values(110,2,6)
	

	--composer2

	insert into composer2 (IdLivraison,IdProduit,QuantiteLivre)values(1,1,10)
	insert into composer2 (IdLivraison,IdProduit,QuantiteLivre)values(2,13,12)
	insert into composer2 (IdLivraison,IdProduit,QuantiteLivre)values(3,4,1)
	insert into composer2 (IdLivraison,IdProduit,QuantiteLivre)values(7,5,5)
	insert into composer2 (IdLivraison,IdProduit,QuantiteLivre)values(4,6,7)
