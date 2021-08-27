using System;
using System.Collections.Generic;
using System.Text;

namespace Week5.Test.Core.Models
{
    public enum Ruolo
    {
        Ristoratore,
        Cliente
    }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Ruolo Ruolo { get; set; }
    }
}
