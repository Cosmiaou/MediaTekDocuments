# MediatekDocuments
Cette application permet de gérer les documents (livres, DVD, revues) d'une médiathèque, ainsi que les commandes de ces documents. Elle a été codée en C# sous Visual Studio 2022. C'est une application de bureau, prévue d'être installée sur plusieurs postes accédant à la même base de données.<br>
L'application exploite une API REST pour accéder à la BDD MySQL. Des explications sont données plus loin, ainsi que le lien de récupération.
## Présentation
<br>L'application ne comporte deux fenêtres, une fenêtre d'authentification, et une fenêtre principale, divisée en plusieurs onglets.
## Les différents onglets de la fenêtre principale de l'application
### Onglet 1 : Livres
Cet onglet présente la liste des livres, triée par défaut sur le titre.<br>
La liste comporte les informations suivantes : titre, auteur, collection, genre, public, rayon.
![img2](https://github.com/CNED-SLAM/MediaTekDocuments/assets/100127886/e3f31979-cf24-416d-afb1-a588356e8966)
#### Recherches
<strong>Par le titre :</strong> Il est possible de rechercher un ou plusieurs livres par le titre. La saisie dans la zone de recherche se fait en autocomplétions sans tenir compte de la casse. Seuls les livres concernés apparaissent dans la liste.<br>
<strong>Par le numéro :</strong> il est possible de saisir un numéro et, en cliquant sur "Rechercher", seul le livre concerné apparait dans la liste (ou un message d'erreur si le livre n'est pas trouvé, avec la liste remplie à nouveau).
#### Filtres
Il est possible d'appliquer un filtre (un seul à la fois) sur une de ces 3 catégories : genre, public, rayon.<br>
Un combo par catégorie permet de sélectionner un item. Seuls les livres correspondant à l'item sélectionné, apparaissent dans la liste (par exemple, en choisissant le genre "Policier", seuls les livres de genre "Policier" apparaissent).<br>
Le fait de sélectionner un autre filtre ou de faire une recherche, annule le filtre actuel.<br>
Il est possible aussi d'annuler le filtre en cliquant sur une des croix.
#### Tris
Le fait de cliquer sur le titre d'une des colonnes de la liste des livres, permet de trier la liste par rapport à la colonne choisie.
#### Affichage des informations détaillées
Si la liste des livres contient des éléments, par défaut il y en a toujours un de sélectionné. Il est aussi possible de sélectionner une ligne (donc un livre) en cliquant n'importe où sur la ligne.<br>
La partie basse de la fenêtre affiche les informations détaillées du livre sélectionné (numéro de document, code ISBN, titre, auteur(e), collection, genre, public, rayon, chemin de l'image) ainsi que l'image.
### Onglet 2 : DVD
Cet onglet présente la liste des DVD, triée par titre.<br>
La liste comporte les informations suivantes : titre, durée, réalisateur, genre, public, rayon.<br>
Le fonctionnement est identique à l'onglet des livres.<br>
La seule différence réside dans certaines informations détaillées, spécifiques aux DVD : durée (à la place de ISBN), réalisateur (à la place de l'auteur), synopsis (à la place de collection).
### Onglet 3 : Revues
Cet onglet présente la liste des revues, triées par titre.<br>
La liste comporte les informations suivantes : titre, périodicité, délai mise à dispo, genre, public, rayon.<br>
Le fonctionnement est identique à l'onglet des livres.<br>
La seule différence réside dans certaines informations détaillées, spécifiques aux revues : périodicité (à la place de l'auteur), délai mise à dispo (à la place de collection).
### Onglet 4 : Parutions des revues
Cet onglet permet d'enregistrer la réception de nouvelles parutions d'une revue.<br>
Il se décompose en 2 parties (groupbox).
#### Partie "Recherche revue"
Cette partie permet, à partir de la saisie d'un numéro de revue (puis en cliquant sur le bouton "Rechercher"), d'afficher toutes les informations de la revue (comme dans l'onglet précédent), ainsi que son image principale en petit, avec en plus la liste des parutions déjà reçues (numéro, date achat, chemin photo). Sur la sélection d'une ligne dans la liste des parutions, la photo de la parution correspondante s'affiche à droite.<br>
Dès qu'un numéro de revue est reconnu et ses informations affichées, la seconde partie ("Nouvelle parution réceptionnée pour cette revue") devient accessible.<br>
Si une modification est apportée au numéro de la revue, toutes les zones sont réinitialisées et la seconde partie est rendue inaccessible, tant que le bouton "Rechercher" n'est pas utilisé.
#### Partie "Nouvelle parution réceptionnée pour cette revue"
Cette partie n'est accessible que si une revue a bien été trouvée dans la première partie.<br>
Il est possible alors de réceptionner une nouvelle parution en saisissant son numéro, en sélectionnant une date (date du jour proposée par défaut) et en cherchant l'image correspondante (optionnel) qui doit alors s'afficher à droite.<br>
Le clic sur "Valider la réception" va permettre d'ajouter un tuple dans la table Exemplaire de la BDD. La parution correspondante apparaitra alors automatiquement dans la liste des parutions et les zones de la partie "Nouvelle parution réceptionnée pour cette revue" seront réinitialisées.<br>
Si le numéro de la parution existe déjà, il n’est pas ajouté et un message est affiché.
![img3](https://github.com/CNED-SLAM/MediaTekDocuments/assets/100127886/225e10f2-406a-4b5e-bfa9-368d45456056)
### Onglet 5 : Commandes des livres
Cet onglet permet de consulter les commandes des livres.<br>
Il se décompose en 3 parties (groupbox).<br>
#### Partie "Recherche commande"
Cette partie permet, à partir de la saisie d'un numéro de livre (puis en cliquant sur le bouton "Rechercher"), d'afficher les informations du livre, ainsi que la liste des commandes enregistrés pour ce livre.<br>
Si un élément est sélectionné, un clic sur "Supprimer" permet de supprimer la commande, à condition que celle-ci soit au statut de suivi "livré". Un clic sur "Modifier" petmet de modifier son statut de suivi.<br>
<img width="875" height="713" alt="image" src="https://github.com/user-attachments/assets/0dd5616a-a855-4b12-aa24-b3a68d80cc72" />
#### Partie "Modifier suivi"
Cette partie indique quel livre a été commandé et en quel nombre. L'utilisateur peut modifier l'état de la commande, choissisant "en cours", "relancée", "livrée" ou "réglée".<br>
Une commande ne peut passer au statut "rêglée" que si elle a été préalablement livrée. Une commande "livrée" ou "réglée" ne peut pas retourner à un niveau inférieur.<br>
Quand la commande passe à "livrée", les exemplaires sont automatiquement rajoutés dans la base de donnée.<br>
#### Partie "Ajouter commande"
Cette partie permet l'ajout d'une commande d'un livre. Le livre doit être sélectionné dans la liste, et l'utilisateur doit indiquer le nombre d'exemplaires commandés et le montant.<br>
L'utilisateur doit sélectionner un identifiant pour la commande. Cet identifiant doit être unique. Les identifiants sont partagés parmis les commandes de livre, de dvd, et de revues.<br>
### Onglet 6 : Commandes de dvd
Cet onglet est identique à celui des commandes de livre, mais concerne les dvd. Le fonctionnement et le principe est le même.
### Onglet 7 : Abonnement
Cet onglet permet de consulter les abonnements, qui sont en fait l'équivalent des commandes, mais pour les revues.<br>
Il se décompose en 2 parties (groupbox).<br>
<img width="877" height="713" alt="image" src="https://github.com/user-attachments/assets/d2c94e7c-e818-4e03-826a-427c097fe962" />
#### Partie "Rechercher les abonnements"
Elle fonctionne identiquement aux commandes des autres documents.<br>
Cette partie permet, à partir de la saisie d'un numéro d'une revue (puis en cliquant sur le bouton "Rechercher"), d'afficher les informations de la revue, ainsi que la liste des abonnements passés, présents et futur enregistrés pour ce livre.<br>
Le bouton "Supprimer" permet de supprimer un abonnement. La suppression n'est possible que si un abonnement est choisi, et uniquement si cet abonnement n'est reliée à aucun exemplaire enregistré d'une revue.<br>
#### Partie "Nouvel abonnement"
Cet partie permet d'ajouter un abonnement, qui peut être un abonnement à une nouvelle revue ou un simple renouvellement - l'application ne voit pas la différence.<br>
La revue doit être préalablement créée et sélectionné dans le menu. Il faut choisir un montant d'exemplaire attendu, une date de début, qui doit être antérieure à la date de fin. Il n'y a pas de limite maximale de temps pour l'abonnement.<br>
L'utilisateur doit sélectionner un identifiant pour la commande. Cet identifiant doit être unique. Les identifiants sont partagés parmis les commandes de livre, de dvd, et de revues.<br>
## Fenêtre d'authentification
La fenêtre d'authentification est rencontrée lors de chaque lancement de l'application. Il est nécessaire de s'authentifier pour l'utiliser.<br>
<img width="435" height="332" alt="image" src="https://github.com/user-attachments/assets/54c1a257-1572-4fc3-9e65-a5a1912ac474" />
Il faut indiquer un mot de passe et un nom d'utilisateur. Ces informations ne sont pas gêrées dans l'application, ils sont stockées dans la base de données et seront transmis par le responsable du service informatique.<br>
Une chaîne de connexion doit être indiquée. Lors de la première connexion a l'application, elle est fixée sur une valeur à remplacer. Une fois remplacée, elle sera mémorisée.<br>
La chaîne de connexion est selon le modèle "nom:motdepasse". Important : si la chaîne de connexion est mauvaise, l'application se fermera.<br>

## La base de données
La base de données 'mediatek86 ' est au format MySQL.<br>
Voici sa structure :<br>
![mcd_mediatekdocuments](https://github.com/user-attachments/assets/0f97b2ce-835f-4276-b61c-84d0baacdbf8)
<br>On distingue les documents "génériques" (ce sont les entités Document, Revue, Livres-DVD, Livre et DVD) des documents "physiques" qui sont les exemplaires de livres ou de DVD, ou bien les numéros d’une revue ou d’un journal.<br>
Chaque exemplaire est numéroté à l’intérieur du document correspondant, et a donc un identifiant relatif. Cet identifiant est réel : ce n'est pas un numéro automatique. <br>
Un exemplaire est caractérisé par :<br>
. un état d’usure, les différents états étant mémorisés dans la table Etat ;<br>
. sa date d’achat ou de parution dans le cas d’une revue ;<br>
. un lien vers le fichier contenant sa photo de couverture de l'exemplaire, renseigné uniquement pour les exemplaires des revues, donc les parutions (chemin complet) ;
<br>
Un document a un titre (titre de livre, titre de DVD ou titre de la revue), concerne une catégorie de public, possède un genre et est entreposé dans un rayon défini. Les genres, les catégories de public et les rayons sont gérés dans la base de données. Un document possède aussi une image dont le chemin complet est mémorisé. Même les revues peuvent avoir une image générique, en plus des photos liées à chaque exemplaire (parution).<br>
Une revue est un document, d’où le lien de spécialisation entre les 2 entités. Une revue est donc identifiée par son numéro de document. Elle a une périodicité (quotidien, hebdomadaire, etc.) et un délai de mise à disposition (temps pendant lequel chaque exemplaire est laissé en consultation). Chaque parution (exemplaire) d'une revue n'est disponible qu'en un seul "exemplaire".<br>
Un livre a aussi pour identifiant son numéro de document, possède un code ISBN, un auteur et peut faire partie d’une collection. Les auteurs et les collections ne sont pas gérés dans des tables séparées (ce sont de simples champs textes dans la table Livre).<br>
De même, un DVD est aussi identifié par son numéro de document, et possède un synopsis, un réalisateur et une durée. Les réalisateurs ne sont pas gérés dans une table séparée (c’est un simple champ texte dans la table DVD).
Enfin, 3 tables permettent de mémoriser les données concernant les commandes de livres ou DVD et les abonnements. Une commande est effectuée à une date pour un certain montant. Un abonnement est une commande qui a pour propriété complémentaire la date de fin de l’abonnement : il concerne une revue.  Une commande de livre ou DVD a comme caractéristique le nombre d’exemplaires commandé et concerne donc un livre ou un DVD.<br>
<br>
La base de données est remplie de quelques exemples pour pouvoir tester son application. Dans les champs image (de Document) et photo (de Exemplaire) doit normalement se trouver le chemin complet vers l'image correspondante. Pour les tests, vous devrez créer un dossier, le remplir de quelques images et mettre directement les chemins dans certains tuples de la base de données qui, pour le moment, ne contient aucune image.<br>
Lorsque l'application sera opérationnelle, c'est le personnel de la médiathèque qui sera en charge de saisir les informations des documents.
## L'API REST
L'accès à la BDD se fait à travers une API REST protégée par une authentification basique.<br>
Le code de l'API se trouve ici :<br>
https://github.com/Cosmiaou/rest_mediatekdocuments<br>
avec toutes les explications pour l'utiliser (dans le readme).

## Installation de l'application (pour l'utilisateur)
Téléchargez et exécuter le .exe disponible à cette adresse.<br>
https://github.com/Cosmiaou/MediaTekDocuments/releases/tag/release<br>
Suivez les instructions. Une fois le téléchargement terminé, rendez-vous dans le fichier du téléchargement (par défaut : C:\Program Files(x86)\MediaTekInstaller) et lancez MediaTekDocuments.exe.<br>
Indiquez les identifiants de connexion et utilisez l'application.<br>
## Installation de l'application (pour développeur)
Ce mode opératoire permet d'installer l'application pour pouvoir travailler dessus.<br>
- Installer Visual Studio 2022 entreprise et l'extension Serilog.<br>
- Télécharger le code et le dézipper puis renommer le dossier en "mediatekdocuments".<br>
- Récupérer et installer l'API REST nécessaire (https://github.com/Cosmiaou/rest_mediatekdocuments) ainsi que la base de données (les explications sont données dans le readme correspondant).
