1-Application de gestion d'une bibliothèque
Objectif :
Développer une application en C# permettant de gérer une bibliothèque de livres.

Fonctionnalités demandées :
Ajouter un livre.
Afficher la liste des livres.
Rechercher un livre par son ISBN ou son titre.
Modifier les informations d'un livre.
Supprimer un livre.
Emprunter un livre.
Retourner un livre.
Afficher uniquement les livres disponibles.

Structure de données
Créer une classe Livre avec les propriétés suivantes : 
ISBN
Titre
Auteur
Année de publication
Catégorie
Disponible (booléen)

Créer une classe Bibliotheque qui gère une collection de livres.

Contraintes techniques
Utiliser les concepts de la programmation orientée objet (classes, objets, encapsulation).
Utiliser une List<Livre> pour stocker les données.
Organiser le code en plusieurs classes.
Gérer les exceptions (ex. : ISBN inexistant).
Créer un menu interactif dans une application Console.

Bonus
Sauvegarder et charger les données au format JSON.
Trier les livres par titre, auteur ou année.
Ajouter une recherche multicritère.
