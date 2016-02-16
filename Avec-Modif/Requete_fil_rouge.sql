use FilRouge_essai_modif
go



--requete sur fil rouge
	--1) chiffre d'affaire généré pour l'ensemble et par fournisseur

--ensemble

create view rq1_1
as
	select sum (PrixHT_Prod * QuantiteProd) as CA from produit
	join composer1 on composer1.idproduit=produit.idproduit
	join commande on commande.idcommande=composer1.idcommande
	
--par fournisseur



create view rq1_2
as
	select sum (PrixHT_Prod * QuantiteProd) as CA, fournisseur.idfournisseur from produit
	join composer1 on composer1.idproduit=produit.idproduit
	join commande on commande.idcommande=composer1.idcommande
	join approvisionner on approvisionner.idproduit=produit.idproduit
	join fournisseur on fournisseur.idfournisseur=approvisionner.idfournisseur 
	group by fournisseur.idfournisseur
	


	--2)liste des produits commandés (réf produit, qté commandé)

	create view rq2
as
	select produit.Idproduit, composer1.quantiteprod from produit
	join composer1 on composer1.idproduit=produit.idproduit
	join commande on composer1.idcommande=commande.idcommande



	--3)liste des commandes pour un client (date, ref client, montant)

	create view rq3
as
	select client.idclient, commande.datecommande, commande.montantcommande from commande
	join client on client.idclient =commande.idclient
	

	--4)répartition du chiffre d'affaire par type de client

	create view rq4
as
	select CategorieClient,  sum (PrixHT_Prod * QuantiteProd) as CA from client 
	join commande on commande.idclient=client.idclient
	join composer1 on composer1.idcommande=commande.idcommande
	join produit on composer1.idproduit=produit.idproduit
	group by categorieclient



	--5)lister les commandes en cours de livraison
	create view rq5
as
	select livraison.IdCommande, EtatCommande, DateCommande, MontantCommande, DatePaiement, Idclient, idlivraison, dateLivraison from commande
	join livraison on livraison.idcommande=commande.idcommande
	where livraison.datelivraison is null



--Gérer les vues
--Créez une vue correspondant à la jointure Produits - Fournisseurs :





	create view vue1
as
select produit.*, fournisseur.* from produit
join approvisionner on produit.idproduit=approvisionner.idproduit
join fournisseur on fournisseur.idfournisseur=approvisionner.idfournisseur


select * from vue1