using System;
using System.Collections.Generic;
using System.Text;

namespace Week5.Test.Core.Models
{
    public enum Tipologia
    {
        Primo,
        Secondo,
        Contorno,
        Dolce
    }

    public class Piatto
    {
        public int Id { get; set; } //aggiunto per le op CRUD ma non visibile nella pag di menu
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public Tipologia Tipologia { get; set; }
        public decimal Prezzo { get; set; }
    }
}
