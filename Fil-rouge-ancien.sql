Use master
go

drop database FilRouge
go


create database FilRouge
go

use filrouge
go



/*------------------------------------------------------------
*        Script SQLSERVER 
------------------------------------------------------------*/


/*------------------------------------------------------------
-- Table: Produit
------------------------------------------------------------*/
CREATE TABLE Produit(
	IdProduit      INT IDENTITY (1,1)  NOT NULL ,
	NomProdCourt   VARCHAR (30)  ,
	NomProdLong    VARCHAR (150)  ,
	ImageProd      VARCHAR (25)  ,
	PrixHT_Prod    MONEY   ,
	ActifProduit bit not null,
	StockProduit   INT   ,
	IdSousRubrique INT not null  ,
	CONSTRAINT prk_constraint_Produit PRIMARY KEY NONCLUSTERED (IdProduit)
);


/*------------------------------------------------------------
-- Table: SousRubrique
------------------------------------------------------------*/
CREATE TABLE SousRubrique(
	IdSousRubrique  INT IDENTITY (1,1) NOT NULL ,
	NomSousRubrique VARCHAR (25)  ,
	IdRubrique      INT not null  ,
	CONSTRAINT prk_constraint_SousRubrique PRIMARY KEY NONCLUSTERED (IdSousRubrique)
);


/*------------------------------------------------------------
-- Table: Rubrique
------------------------------------------------------------*/
CREATE TABLE Rubrique(
	IdRubrique  INT IDENTITY (1,1) NOT NULL ,
	NomRubrique VARCHAR (25)  ,
	CONSTRAINT prk_constraint_Rubrique PRIMARY KEY NONCLUSTERED (IdRubrique)
);


/*------------------------------------------------------------
-- Table: Client
------------------------------------------------------------*/
CREATE TABLE Client(
	IdClient INT identity(1,1)  NOT NULL ,
	CiviliteClient varchar(5) not null,
	NomClient varchar (50) not null,
	PrenomClient varchar(20) not null,
	CategorieClient      VARCHAR (30) not null ,
	AdrLivraisonClient   VARCHAR (150)  ,
	AdrFacturationClient VARCHAR (150)  ,
	NomDuCommercial      VARCHAR (150)  ,
	CONSTRAINT prk_constraint_Client PRIMARY KEY NONCLUSTERED (IdClient)
);


/*------------------------------------------------------------
-- Table: Fournisseur
------------------------------------------------------------*/
CREATE TABLE Fournisseur(
	IdFournisseur   INT identity(1,1) NOT NULL ,
	NomFournisseur VARCHAR (35)  ,
	CONSTRAINT prk_constraint_Fournisseur PRIMARY KEY NONCLUSTERED (IdFournisseur)
);

/*------------------------------------------------------------
-- Table: Facture
------------------------------------------------------------*/

Create table facture(
	IdFacture int identity(1,1) not null primary key,
	DateFacture date,
	)



/*------------------------------------------------------------
-- Table: Commande
------------------------------------------------------------*/
CREATE TABLE Commande(
	IdCommande      INT identity(1,1) NOT NULL ,
	EtatCommande    VARCHAR (50)  ,
	DateCommande    DATE  ,
	MontantCommande money   ,
	DatePaiement    DATE  ,
	IdClient        INT not null  ,
	IdFacture		int null references facture(idfacture),
	CONSTRAINT prk_constraint_Commande PRIMARY KEY NONCLUSTERED (IdCommande)
);


/*------------------------------------------------------------
-- Table: Livraison
------------------------------------------------------------*/
CREATE TABLE Livraison(
	IdLivraison   INT identity(1,1) NOT NULL ,
	DateLivraison DATE ,
	CONSTRAINT prk_constraint_Livraison PRIMARY KEY NONCLUSTERED (IdLivraison)
);


/*------------------------------------------------------------
-- Table: Composer
------------------------------------------------------------*/
CREATE TABLE Composer(
	QuantiteProd        INT   ,
	PrixDeVente_ancien MONEY   ,
	QuantiteLivraison  INT   ,
	IdProduit          INT  NOT NULL ,
	IdCommande         INT  NOT NULL ,
	IdLivraison        INT  NOT NULL ,
	CONSTRAINT prk_constraint_Composer PRIMARY KEY NONCLUSTERED (IdProduit,IdCommande,IdLivraison)
);


/*------------------------------------------------------------
-- Table: Approvisionner
------------------------------------------------------------*/
CREATE TABLE Approvisionner(
	IdProduit     INT  NOT NULL ,
	IdFournisseur INT  NOT NULL ,
	CONSTRAINT prk_constraint_Approvisionner PRIMARY KEY NONCLUSTERED (IdProduit,IdFournisseur)
);



ALTER TABLE Produit ADD CONSTRAINT FK_Produit_IdSousRubrique FOREIGN KEY (IdSousRubrique) REFERENCES SousRubrique(IdSousRubrique);
ALTER TABLE SousRubrique ADD CONSTRAINT FK_SousRubrique_IdRubrique FOREIGN KEY (IdRubrique) REFERENCES Rubrique(IdRubrique);
ALTER TABLE Commande ADD CONSTRAINT FK_Commande_IdClient FOREIGN KEY (IdClient) REFERENCES Client(IdClient);
ALTER TABLE Composer ADD CONSTRAINT FK_Composer_IdProduit FOREIGN KEY (IdProduit) REFERENCES Produit(IdProduit);
ALTER TABLE Composer ADD CONSTRAINT FK_Composer_IdCommande FOREIGN KEY (IdCommande) REFERENCES Commande(IdCommande);
ALTER TABLE Composer ADD CONSTRAINT FK_Composer_IdLivraison FOREIGN KEY (IdLivraison) REFERENCES Livraison(IdLivraison);
ALTER TABLE Approvisionner ADD CONSTRAINT FK_Approvisionner_IdProduit FOREIGN KEY (IdProduit) REFERENCES Produit(IdProduit);
ALTER TABLE Approvisionner ADD CONSTRAINT FK_Approvisionner_IdFournisseur FOREIGN KEY (IdFournisseur) REFERENCES Fournisseur(IdFournisseur);
 


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


	--client
	
	insert into client (CiviliteClient,Nomclient,PrenomClient,CategorieClient,AdrLivraisonClient,AdrFacturationClient,NomDuCommercial) values ('M.','Brown','Jackie','particulier','1 rue des alouettes Perpignan',null,'Pascal')
	insert into client (CiviliteClient,Nomclient,PrenomClient,CategorieClient,AdrLivraisonClient,AdrFacturationClient,NomDuCommercial) values ('Mme','Delaplace','Rebecca','particulier','60 bis rue du chateau Compiègne','entreprise','Pascal')
	insert into client (CiviliteClient,Nomclient,PrenomClient,CategorieClient,AdrLivraisonClient,AdrFacturationClient,NomDuCommercial) values ('Melle','Guerin','Alice','professionel','12 rue des chandeliers St-Louis',null,'Gérard')
	
	--facture
	insert into facture (Datefacture) values ('02-01-2011')
	insert into facture (Datefacture) values ('05-05-2013')
	insert into facture (Datefacture) values ('09-08-2012')


	--commande
	insert into Commande (EtatCommande,DateCommande,MontantCommande,DatePaiement,IdFacture,IdClient) values ('saisie','11-02-2011',250.00,null,null,1)
	insert into Commande (EtatCommande,DateCommande,MontantCommande,DatePaiement,IdFacture,IdClient) values ('annulée','01-03-2011',1250.00,null,null,1)
	insert into Commande (EtatCommande,DateCommande,MontantCommande,DatePaiement,IdFacture,IdClient) values ('en préparation','01-03-2015',150.00,'02-03-2015',2,2)
	--insert into Commande (EtatCommande,DateCommande,MontantCommande,DatePaiement,IdFacture,IdClient) values ('expédiée','10-05-2015',20150.00,'02-06-2015',3)
	--insert into Commande (EtatCommande,DateCommande,MontantCommande,DatePaiement,IdFacture,IdClient) values ('facturée','11-06-2015',2050.00,'13-06-2015',3)
	--insert into Commande (EtatCommande,DateCommande,MontantCommande,DatePaiement,IdFacture,IdClient) values ('retard de paiement','11-11-2015',50.90,null,3)
	--insert into Commande (EtatCommande,DateCommande,MontantCommande,DatePaiement,IdFacture,IdClient) values ('soldée','02-12-2015',650.80,'05-12-2015',3)
	
	
	
	--livraison
	insert into Livraison (DateLivraison) values ('02-01-2011')
	insert into Livraison (DateLivraison) values ('11-01-2011')
	insert into Livraison (DateLivraison) values ('15-02-2011')
	insert into Livraison (DateLivraison) values ('15-02-2015')
	insert into Livraison (DateLivraison) values ('05-12-2014')
	insert into Livraison (DateLivraison) values ('11-04-2013')


	--composer
	insert into composer (IdProduit,IdCommande,IdLivraison,QuantiteProd,PrixDeVente_ancien,QuantiteLivraison)values(1,1,1,10,200.21,20)
	insert into composer (IdProduit,IdCommande,IdLivraison,QuantiteProd,PrixDeVente_ancien,QuantiteLivraison)values(2,2,5,10,10.21,5)
	--insert into composer (IdProduit,IdCommande,IdLivraison,QuantiteProd,PrixDeVente_ancien,QuantiteLivraison)values(13,4,2,20,160,30)
	--insert into composer (IdProduit,IdCommande,IdLivraison,QuantiteProd,PrixDeVente_ancien,QuantiteLivraison)values(1,1,2,5,1600,30)






	--volet sécurité
	--équipe 1 qui a tous les droits sur la table produit, rubrique / sous rubrique,fournisseur, approvisioner et uniquement sur ces tables
	/*
	create login equipe1 with password = 'equipe1', DEFAULT_DATABASE=[filrouge],CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF

	use filrouge

	create user equipe1 for login equipe1   --donne cette fois l'accés à papyrus à equipe1

	grant select on rubrique to equipe1
	grant select on sousrubrique to equipe1
	grant select on produit to equipe1
	grant select on fournisseur to equipe1
	grant select on approvisionner to equipe1

	grant update on rubrique to equipe1
	grant update on sousrubrique to equipe1
	grant update on produit to equipe1
	grant update on fournisseur to equipe1
	grant update on approvisionner to equipe1

	grant insert on rubrique to equipe1
	grant insert on sousrubrique to equipe1
	grant insert on produit to equipe1
	grant insert on fournisseur to equipe1
	grant insert on approvisionner to equipe1


	--équipe 1 qui a tous les droits sur la table produit, rubrique / sous rubrique,fournisseur, approvisioner et uniquement sur ces tables
	/*
	create login equipe2 with password = 'equipe2', DEFAULT_DATABASE=[filrouge],CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF

	use filrouge

	create user equipe2 for login equipe2   --donne cette fois l'accés à papyrus à equipe2

	grant select on client to equipe2
	grant select on commande to equipe2
	grant select on produit to equipe2
	grant select on facture to equipe2
	grant select on composer to equipe2
	grant select on livraison to equipe2

	grant update on client to equipe2
	grant update on commande to equipe2
	grant update on facture to equipe2
	grant update on composer to equipe2
	grant update on livraison to equipe2

	grant insert on client to equipe2
	grant insert on commande to equipe2
	grant insert on facture to equipe2
	grant insert on composer to equipe2
	grant insert on livraison to equipe2

	--volet sauvegarde; gérer avec l'unité de sauvegarde sauvefil et le plan de maintenance MaintenanceFILROUGE.
	
*/

	