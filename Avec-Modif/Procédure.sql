
use FilRouge_essai_modif
go

--Programmer des procédures stockées sur le SGBD
--Créez une procédure stockée qui sélectionne les commandes non soldées (en cours
--de livraison),

create proc Fil_rouge1
as
select * from commande 
join livraison on livraison.Idcommande=commande.idcommande
where commande.datepaiement is null and DateLivraison is null

EXEC Fil_rouge1


-- puis une autre qui renvoie le délai moyen entre la date de commande
--et la date de facturation. 

create proc Fil_rouge2
--@result int OUTPUT
AS
begin
--SET @result = 
select avg(datediff(dd,DateFacture,DateCommande)) from commande
join facture on commande.idfacture=facture.idfacture
end

--Exécutée avec les instructions suivantes :
DECLARE @res int

EXECUTE Fil_rouge2 --@Res OUTPUT
SELECT 'le délai moyen entre la date de commande et la date de facturation:', @Res

