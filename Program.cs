using System;
using System.Linq;
using System.Numerics;
namespace Gestion_Bibliotheque
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = true;
            Bibliotheque bibliotheque = new Bibliotheque();

            while (exit)
            {
                Console.WriteLine("***************************************** GESTION DE BIBLIOTHEQUE **************************************** \n");
                Console.WriteLine("1. Ajouter un livre");
                Console.WriteLine("2. Afficher les livres");
                Console.WriteLine("3. Rechercher un livre par ISBN");
                Console.WriteLine("4. Rechercher un livre par titre");
                Console.WriteLine("5. Modifier un livre");
                Console.WriteLine("6. Supprimer un livre");
                Console.WriteLine("7. Emprunter un livre ");
                Console.WriteLine("8. Retourner un livre ");
                Console.WriteLine("9. Afficher les livres disponibles ");
                Console.WriteLine("10. Recherche multi-critères ");
                Console.WriteLine("11. Trier les livres par titre");
                Console.WriteLine("12. Trier les livres par auteur");
                Console.WriteLine("13. Trier les livres par année de publication");
                Console.WriteLine("14. Sauvegarder");
                Console.WriteLine("15. Charger ");
                Console.WriteLine("16. Afficher les livres d'un auteur spécifique ");
                Console.WriteLine("17. Quitter ");
                Console.WriteLine("Veuillez choisir une option : ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        try
                        {
                            Console.WriteLine("Entrez le titre du livre : ");
                            string titre = Console.ReadLine();
                            Console.WriteLine("Entrez l'auteur du livre : ");
                            string auteur = Console.ReadLine();
                            Console.WriteLine("Entrez l'année de publication : ");
                            string annee = Console.ReadLine();
                            Console.WriteLine("Entrez l'ISBN du livre : ");
                            int isbn = int.Parse(Console.ReadLine());
                            if(bibliotheque.book.Any(b => b.isbn == isbn))
                            {
                                Console.WriteLine("Un livre avec cet ISBN existe déjà. Veuillez entrer un ISBN unique.");
                                break;
                            }
                            Livre livres = new Livre(isbn, titre, auteur, annee);
                            bibliotheque.addBook(livres);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Veuillez entrer un ISBN valide (un nombre entier).");
                        }
                        break;
                    case "2":
                        bibliotheque.displayBooks();
                        break;
                    case "3":
                        if(bibliotheque.book.Count == 0)
                        {
                            Console.WriteLine("Aucun livre n'est disponible dans la bibliothèque.");
                            break;
                        }
                        Console.WriteLine("Entrez l'ISBN du livre à rechercher : ");
                        try
                        {
                            int isbnRecherche = int.Parse(Console.ReadLine());
                            bibliotheque.searchISBN(isbnRecherche);
                            
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Veuillez entrer un ISBN valide (un nombre entier).");
                        }
                        break;
                    case "4":
                        if(bibliotheque.book.Count == 0)
                        {
                            Console.WriteLine("Aucun livre n'est disponible dans la bibliothèque.");
                            break;
                        }
                        Console.WriteLine("Enter le titre du livre à rechercher : ");
                        string titreRecherche = Console.ReadLine();
                        bibliotheque.searchTitle(titreRecherche );
                        break;
                    case "5":
                        if(bibliotheque.book.Count == 0)
                        {
                            Console.WriteLine("Aucun livre n'est disponible dans la bibliothèque.");
                            break;
                        }
                        try
                        {
                            Console.WriteLine("Entrez l'ISBN du livre à modifier : ");
                            int isbnModif = int.Parse(Console.ReadLine());
                            Console.WriteLine("Entrez le nouveau titre du livre : ");
                            string nouveauTitre = Console.ReadLine();
                            Console.WriteLine("Entrez le nouvel auteur du livre : ");
                            string nouvelAuteur = Console.ReadLine();
                            Console.WriteLine("Entrez la nouvelle année de publication : ");
                            string nouvelleAnnee = Console.ReadLine();
                            bibliotheque.updateBook(isbnModif, nouveauTitre, nouvelAuteur, nouvelleAnnee);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Veuillez entrer un ISBN valide (un nombre entier).");
                        }
                        break;
                    case "6":
                        if (bibliotheque.book.Count == 0)
                        {
                            Console.WriteLine("Aucun livre n'est disponible dans la bibliothèque.");
                            break;
                        }
                        try
                        {
                            Console.WriteLine("\nEntrez l'ISBN du livre à supprimer : ");
                            int isbnSuppression = int.Parse(Console.ReadLine());
                            bibliotheque.deleteBook(isbnSuppression);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Veuillez entrer un ISBN valide (un nombre entier).");
                        }
                        break;
                    case "7":
                        if(bibliotheque.book.Count == 0)
                        {
                            Console.WriteLine("Aucun livre n'est disponible dans la bibliothèque.");
                            break;
                        }
                        Console.WriteLine("\nEntrez l'ISBN du livre à emprunter : ");
                        try
                        {
                            int isbnEmprunt = int.Parse(Console.ReadLine());
                            bibliotheque.BorrowBook(isbnEmprunt);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Veuillez entrer un ISBN valide (un nombre entier).");
                        }
                        break;
                    case "8":
                        if (bibliotheque.book.Count == 0)
                        {
                            Console.WriteLine("Aucun livre n'est disponible dans la bibliothèque.");
                            break;
                        }
                        Console.WriteLine("\nEntrez l'ISBN du livre à retourner : ");
                        try
                        {
                            int isbnRetour = int.Parse(Console.ReadLine());
                            bibliotheque.returnBook(isbnRetour);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Veuillez entrer un ISBN valide (un nombre entier).");
                        }
                        break;
                        case "9":
                              bibliotheque.bookAvailable();
                        break;
                    case "10":
                        if (bibliotheque.book.Count == 0)
                        {
                            Console.WriteLine("Aucun livre n'est disponible dans la bibliothèque.");
                            break;
                        }
                        Console.WriteLine("\nEntrez le titre du livre à rechercher  : ");
                        string titreRechercheMulti = Console.ReadLine();
                        Console.WriteLine("Entrez l'auteur du livre à rechercher: ");
                        string auteurRechercheMulti = Console.ReadLine();
                        Console.WriteLine("Entrez l'année de publication du livre à rechercher : ");
                        string anneeRechercheMulti = Console.ReadLine();
                        bibliotheque.searchMulti(titreRechercheMulti, auteurRechercheMulti, anneeRechercheMulti);
                        break;
                    case "11":
                        if (bibliotheque.book.Count == 0)
                        {
                            Console.WriteLine("Aucun livre n'est disponible dans la bibliothèque.");
                            break;
                        }
                        var t = bibliotheque.sortbytitle();
                        Console.WriteLine("\nLivres triés par titre : \n");
                        foreach (Livre livre in t)
                        {
                            Console.WriteLine($"- Titre: '{livre.title}'\n  Auteur: {livre.autor}\n  Année de publication: {livre.year_publication}\n");
                        }
                        break;
                    case "12":
                        if (bibliotheque.book.Count == 0)
                        {
                            Console.WriteLine("Aucun livre n'est disponible dans la bibliothèque.");
                            break;
                        }
                        var a = bibliotheque.sortbyauthor();
                        Console.WriteLine("\nLivres triés par auteur : \n");
                        foreach (Livre livre in a)
                        {
                            Console.WriteLine($"- Auteur: '{livre.autor}'\n  Titre: {livre.title}\n  Année de publication: {livre.year_publication}\n");
                        }   
                        break;
                    case "13":
                        if (bibliotheque.book.Count == 0)
                        {
                            Console.WriteLine("Aucun livre n'est disponible dans la bibliothèque.");
                            break;
                        }
                        var y = bibliotheque.sortbyyear();
                        Console.WriteLine("\nLivres triés par année de publication : \n");
                        foreach (Livre livre in y)
                        {
                            Console.WriteLine($"- Année de publication: '{livre.year_publication}'\n  Titre: {livre.title}\n  Auteur: {livre.autor}\n");
                        }
                        break;
                    case "14":
                        bibliotheque.save();
                        break;
                    case "15":
                        bibliotheque.load();
                        break;
                        case "16":
                        if (bibliotheque.book.Count == 0)
                        {
                            Console.WriteLine("Aucun livre n'est disponible dans la bibliothèque.");
                            break;
                        }
                        Console.WriteLine("\nEntrez le nom de l'auteur dont vous souhaitez afficher les livres : ");
                        string authorName = Console.ReadLine();
                        bibliotheque.getBooksByAuthor(authorName);
                        break;
                    case "17":
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Option invalide. Veuillez choisir un nombre entre 1 et 8.");
                        break;
                }             
            }
        }
    }
}