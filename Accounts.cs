using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Shop;

public class Accounts
{
    public List<Account> AccountsList = new List<Account>();

    public Accounts GetAccounts()
    {
        XmlSerializer xml = new XmlSerializer(typeof(Accounts));

        String fileName = "accounts.xml";
        using (Stream read = new FileStream(fileName, FileMode.Open))
        {
            return (Accounts)xml.Deserialize(read);
        }
    }
    
    public void Save()
    {
        XmlSerializer xml = new XmlSerializer(typeof(Accounts));

        String fileName = "accounts.xml";
        using (Stream writer = new FileStream(fileName, FileMode.Create))
        {
            xml.Serialize(writer, this);
        }
    }
}