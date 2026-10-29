using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
namespace Gestion_Bibliotheque
{
    class Bibliotheque
    {
        public List<Livre> book = new List<Livre>();
        public void addBook(Livre livre)
        {
            book.Add(livre);
            Console.WriteLine($"le livre '{livre.title}' a été bien ajouté.\n");
        }
        public void displayBooks()
        {
            if (book.Count == 0) { 
                Console.WriteLine(" \n Aucun livre disponible. \n");
                return;
            }
            Console.WriteLine("La liste des livres disponibles : \n");
            foreach (Livre livre in book)
            {   Console.WriteLine("\n================================\n");
                Console.WriteLine($" -ISBN: {livre.isbn} \n -Titre: {livre.title} \n -Auteur: {livre.autor}\n -Année de publication: {livre.year_publication}\n -Disponible: {livre.is_available} \n");
                Console.WriteLine("\n================================\n");
            }
        }

        public void searchISBN(int isbn) {
            foreach (Livre livre in book)
            {
                if (livre.isbn == isbn)
                {
                    Console.WriteLine("Le livre avec ISBN " + isbn + " est trouvé :\n");
                    Console.WriteLine($" -Titre: {livre.title} \n -Auteur: {livre.autor}\n -Année de publication: {livre.year_publication}\n -Disponible: {livre.is_available} \n");
                    return;
                }
                else
                {
                    Console.WriteLine("Le livre avec ISBN n'est pas trouvé.\n");
                }
            }
            
        }
        public void searchTitle(string title)
        {
            foreach (Livre livre in book)
            {
                if (livre.title.ToLower() == title.ToLower())
                {
                    Console.WriteLine("Le livre avec le titre " + title + " est  trouvé :\n");
                    Console.WriteLine($" -ISBN: {livre.isbn} \n -Auteur: {livre.autor}\n -Année de publication: {livre.year_publication}\n -Disponible: {livre.is_available} \n");
                    return;
                }
                else
                {
                    Console.WriteLine("Le livre avec le titre " + title + " n'est pas trouvé.\n");
                }
            }
        }
        public void updateBook(int isbn, string titre, string auteur, string annee)
        {
            foreach(Livre livre in book)
            {
                if (livre.isbn == isbn)
                {
                    livre.title = titre;
                    livre.autor = auteur;
                    livre.year_publication = annee;
                    Console.WriteLine("\nLe livre a été bien modifié \n");
                    return;
                    
                }
                else
                {
                    Console.WriteLine("Le livre avec ISBN " + isbn + " n'est pas trouvé.\n");
                }
            }
        }
        public void deleteBook(int isbn)
        {
            foreach(Livre livre in book)
            {
                if (livre.isbn == isbn)
                {
                    book.Remove(livre);
                    Console.WriteLine("\nLe livre a été bien supprimé \n");
                    return;

                }
                else
                {
                    Console.WriteLine("Le livre avec ISBN " + isbn + " n'est pas trouvé.\n");
                }
            }
        }
        public void BorrowBook(int isbn)
        {
            foreach (Livre livre in book)
            {
                if (livre.isbn == isbn)
                {
                    if (livre.is_available == true)
                    {
                        Console.WriteLine("Vous pouvez Emprunter cette livre \n");
                        livre.is_available = false;
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Désolé mais quelqun à déja emprunter cette livre\n");
                        
                    }
                    return;

                }
                else
                {
                      Console.WriteLine("Le livre avec ISBN " + isbn + " n'est pas trouvé.\n");
                }
               
            }
        }
        public void returnBook(int isbn)
        {
            foreach (Livre livre in book)
            {
                if (livre.isbn == isbn)
                {
                    livre.is_available = true;
                    Console.WriteLine("Le livre a été bien retourné\n");
                    return;
                  
                }
                else
                {
                    Console.WriteLine("Le livre avec ISBN " + isbn + " n'est pas trouvé.\n");
                }
            }
        }
        public void bookAvailable()
        {
            if(book.Count == 0)
            {
                Console.WriteLine("Aucun livre n'est disponible dans la bibliothèque.");
                return;
            }
            Console.WriteLine("\nLes livres disponibles sont : \n");
            foreach (Livre livre in book)
            {
                if(livre.is_available == true)
                {
                    Console.WriteLine($"- Titre: '{livre.title}'\n  ");
                }
            }
        }

        public void searchMulti(string title, string author, string year)
        {
            foreach (Livre livre in book)
            {
                if (livre.title.ToLower() == title.ToLower() && livre.autor.ToLower() == author.ToLower() && livre.year_publication == year)
                {
                    Console.WriteLine("Le livre avec le titre " + title + ", l'auteur " + author + " et l'année de publication " + year + " est trouvé :\n");
                    Console.WriteLine($" -ISBN: {livre.isbn} \n -Disponible: {livre.is_available} \n");
                    return;
                }
            }
            Console.WriteLine("Aucun livre correspondant \n");
        }

        public List<Livre> sortbytitle() {

            return book.OrderBy(l => l.title).ToList();

        }
        public List<Livre> sortbyauthor()
        {
            return book.OrderBy(l => l.autor).ToList();
        }

        public List<Livre> sortbyyear()
        {
            return book.OrderBy(l => l.year_publication).ToList();
        }

        public void save()
        {
            string filePath = "bibliotheque.json";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Livre livre in book)
                {
                    writer.WriteLine($"{livre.isbn},{livre.title},{livre.autor},{livre.year_publication},{livre.is_available}");
                }
            }

            Console.WriteLine("Sauvegarde reussit dans bibliotheque.json");
        }
        public void load()
        {
            string filePath = "bibliotheque.json";
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        int isbn = int.Parse(parts[0]);
                        string title = parts[1];
                        string autor = parts[2];
                        string year_publication = parts[3];
                        bool is_available = bool.Parse(parts[4]);
                        Livre livre = new Livre(isbn, title, autor, year_publication);
                        livre.is_available = is_available;
                        book.Add(livre);
                    }
                }
                Console.WriteLine("Restoration reussit");
            }
            else
            {
                Console.WriteLine("Le fichier de sauvegarde n'existe pas. Aucune donnée n'a été chargée.");
            }
        }
    }
}