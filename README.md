# ProjetLibre

TESTER LE PROJET

supprimer le dossier Migrations dans le projet
creer votre base de donnée sql express 
connecter cette base de donnee à visual studio dans explorateur de serveurs
Copier la chaine de connexion dans les propriétés de la base de donnée qui vient d'etre connecté dans startup.cs (projet API) et appsettings.json (projet APP) à la place de ma chaine de connection
dans le dossier du projet ouvrir cmd et faire comme ligne de commande dotnet ef migrations add init
puis dotnet ef database update

       
Pour tester il faut demarrer les deux projets

click droit sur le nom de la solution >> propriétés >> select plusieurs projets de demarrage >> select colonne action Demarrer sur les deux projets >> appliquer >> OK >> F5

>>Ne pas oublier d'ajouter les procédures stockées dans la bdd. Les fichiers sont dans le dossier SQL.
>> creer un table Tasks avec un id en Primary key , Tache varchar et Description varchar) avec compteur index automatique :) ! 05-12-2018

