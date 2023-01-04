using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Shop;

public class Account
{
    public string Name;
    public string Surname;
    public string phone_number;
    public int id;
    public string password;
    public string card;
    public int money = 0;

    public Account(string Name, string Surname, string phone_number, int id, string password, string card)
    {
        this.Name = Name;
        this.Surname = Surname;
        this.phone_number = phone_number;
        this.id = id;
        this.password = password;
        this.card = card;
    }
    
    public Account() { }
}