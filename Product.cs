namespace Shop;

public class Product
{
    public string Name;
    public int cost;

    public Product(string name, int cost)
    {
        Name = name;
        this.cost = cost;
    }
    
    public Product() {}
}