using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Shop;

public class Orders
{
    public List<Order> OrdersList = new List<Order>();

    public Orders GetOrders()
    {
        XmlSerializer xml = new XmlSerializer(typeof(Orders));

        String fileName = "orders.xml";
        using (Stream read = new FileStream(fileName, FileMode.Open))
        {
            return (Orders)xml.Deserialize(read);
        }
    }
    public void Save()
    {
        XmlSerializer xml = new XmlSerializer(typeof(Orders));

        String fileName = "orders.xml";
        using (Stream writer = new FileStream(fileName, FileMode.Create))
        {
            xml.Serialize(writer, this);
        }
    }
}