namespace Shop;

public class Order
{
    public List<Product> products = new List<Product>();
    public string address;
    public Account buyer;

    public Order(string address, Account buyer)
    {
        this.address = address;
        this.buyer = buyer;
    }
    
    public Order() {}
}