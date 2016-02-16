Use master
go

drop database FilRouge_essai_modif
go


create database FilRouge_essai_modif
go

use FilRouge_essai_modif
go
/*------------------------------------------------------------
*        Script SQLSERVER 
------------------------------------------------------------*/


/*------------------------------------------------------------
-- Table: Produit
------------------------------------------------------------*/
CREATE TABLE Produit(
	IdProduit      INT IDENTITY (1,1)  NOT NULL ,
	NomProdCourt   VARCHAR (30) NOT NULL , 
	NomProdLong    VARCHAR (150) NOT NULL ,
	ImageProd      VARCHAR (25) NOT NULL ,
	PrixHT_Prod    MONEY  NOT NULL ,
	ActifProduit bit not null,
	StockProduit   INT  NOT NULL ,
	IdSousRubrique INT not null  ,
	CONSTRAINT prk_constraint_Produit PRIMARY KEY NONCLUSTERED (IdProduit)
);


/*------------------------------------------------------------
-- Table: SousRubrique
------------------------------------------------------------*/
CREATE TABLE SousRubrique(
	IdSousRubrique  INT IDENTITY (1,1) NOT NULL ,
	NomSousRubrique VARCHAR (25) not null ,
	IdRubrique      INT not null  ,
	CONSTRAINT prk_constraint_SousRubrique PRIMARY KEY NONCLUSTERED (IdSousRubrique)
);


/*------------------------------------------------------------
-- Table: Rubrique
------------------------------------------------------------*/
CREATE TABLE Rubrique(
	IdRubrique  INT IDENTITY (1,1) NOT NULL ,
	NomRubrique VARCHAR (25) not null ,
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
	AdrLivraisonClient   VARCHAR (150) not null  ,
	AdrFacturationClient VARCHAR (150) not null  ,
	CoeffClient   int not null,
	Reduction int not null,
	IdCommercial int not null,
	CONSTRAINT prk_constraint_Client PRIMARY KEY NONCLUSTERED (IdClient)
);




/*------------------------------------------------------------
-- Table: Commercial
------------------------------------------------------------*/
CREATE TABLE Commercial(
	IdCommercial  INT IDENTITY (1,1) NOT NULL ,
	NomCommercial VARCHAR (35)  not null,
	CONSTRAINT prk_constraint_Commercial PRIMARY KEY NONCLUSTERED (IdCommercial)
);



/*------------------------------------------------------------
-- Table: Fournisseur
------------------------------------------------------------*/
CREATE TABLE Fournisseur(
	IdFournisseur   INT identity(1,1) NOT NULL ,
	NomFournisseur VARCHAR (35)  NOT NULL,
	CONSTRAINT prk_constraint_Fournisseur PRIMARY KEY NONCLUSTERED (IdFournisseur)
);



/*------------------------------------------------------------
-- Table: Facture
------------------------------------------------------------*/
CREATE TABLE Facture(
	IdFacture     INT  identity(1,1)not null primary key ,
	DateFacture Date not null,
);

/*------------------------------------------------------------
-- Table: Commande
------------------------------------------------------------*/
CREATE TABLE Commande(
	IdCommande      INT identity(1,1) NOT NULL ,
	EtatCommande    VARCHAR (50) NOT NULL ,
	DateCommande    DATE  NOT NULL,
	MontantCommande money  NOT NULL ,
	DatePaiement    DATE NULL ,
	IdClient        INT not null  ,
	IdFacture int null
	CONSTRAINT prk_constraint_Commande PRIMARY KEY NONCLUSTERED (IdCommande)
);




/*------------------------------------------------------------
-- Table: Livraison
------------------------------------------------------------*/
CREATE TABLE Livraison(
	IdLivraison   INT identity(1,1) NOT NULL ,
	DateLivraison DATE ,
	
	IdCommande    INT   ,
	CONSTRAINT prk_constraint_Livraison PRIMARY KEY NONCLUSTERED (IdLivraison)
);



/*------------------------------------------------------------
-- Table: Composer1
------------------------------------------------------------*/
CREATE TABLE Composer1(
	QuantiteProd INT  NOT NULL ,
	IdProduit   INT  NOT NULL ,
	IdCommande  INT  NOT NULL ,
	CONSTRAINT prk_constraint_Composer1 PRIMARY KEY NONCLUSTERED (IdProduit,IdCommande)
);
/*------------------------------------------------------------
-- Table: Composer2
------------------------------------------------------------*/
CREATE TABLE Composer2(
	IdLivraison INT  NOT NULL ,
	IdProduit   INT  NOT NULL ,
	QuantiteLivre INT  NOT NULL ,
	CONSTRAINT prk_constraint_Composer2 PRIMARY KEY NONCLUSTERED (IdLivraison,IdProduit)
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
ALTER TABLE Client ADD CONSTRAINT FK_Client_IdCommercial FOREIGN KEY (IdCommercial) REFERENCES Commercial(IdCommercial);
ALTER TABLE Commande ADD CONSTRAINT FK_Commande_IdClient FOREIGN KEY (IdClient) REFERENCES Client(IdClient);
ALTER TABLE Commande ADD CONSTRAINT FK_Commande_IdFacture FOREIGN KEY (IdFacture) REFERENCES Facture(IdFacture);
ALTER TABLE Livraison ADD CONSTRAINT FK_Livraison_IdCommande FOREIGN KEY (IdCommande) REFERENCES Commande(IdCommande);
ALTER TABLE Composer1 ADD CONSTRAINT FK_Composer1_IdProduit FOREIGN KEY (IdProduit) REFERENCES Produit(IdProduit);
ALTER TABLE Composer1 ADD CONSTRAINT FK_Composer1_IdCommande FOREIGN KEY (IdCommande) REFERENCES Commande(IdCommande);
ALTER TABLE Approvisionner ADD CONSTRAINT FK_Approvisionner_IdProduit FOREIGN KEY (IdProduit) REFERENCES Produit(IdProduit);
ALTER TABLE Approvisionner ADD CONSTRAINT FK_Approvisionner_IdFournisseur FOREIGN KEY (IdFournisseur) REFERENCES Fournisseur(IdFournisseur);
ALTER TABLE Composer2 ADD CONSTRAINT FK_Composer2_IdLivraison FOREIGN KEY (IdLivraison) REFERENCES Livraison(IdLivraison);
ALTER TABLE Composer2 ADD CONSTRAINT FK_Composer2_IdProduit FOREIGN KEY (IdProduit) REFERENCES Produit(IdProduit);

