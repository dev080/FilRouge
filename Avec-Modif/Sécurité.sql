
	use FilRouge_essai_modif
go







	--------------------------------------------------------------------------------------


--volet sécurité
	--équipe 1 qui a tous les droits sur la table produit, rubrique / sous rubrique,fournisseur, approvisioner et uniquement sur ces tables
	
	create login equipe1 with password = 'equipe1', DEFAULT_DATABASE=[filrouge_essai_modif],CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF

	use filrouge_essai_modif

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
	
	create login equipe2 with password = 'equipe2', DEFAULT_DATABASE=[filrouge_essai_modif],CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF

	use filrouge_essai_modif

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
