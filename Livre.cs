using System;
using System.Collections.Generic;
using System.Text;

namespace Gestion_Bibliotheque
{
    class Livre
    {
        public int isbn { get; set; }
        public string title { get; set; }
        public string autor { get; set; }
        public string year_publication { get; set; }
        public bool is_available { get; set; } = true;

        public Livre(int isbn, string title, string autor, string year_publication)
        {
            this.isbn = isbn;
            this.title = title;
            this.autor = autor;
            this.year_publication = year_publication;
        }
    }
}
