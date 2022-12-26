using System;
namespace src.Data.BusinessLogic;

public class Produto
{
    private int id { get; set; }
    private String name { get; set; }
    private float price { get; set; }
    private int stock { get; set; }
    private String description { get; set; }
    private String category { get; set; }
    private float rating { get; set; }

    private float acceptanceF { get; set; }
    private float toleranceF { get; set; }
    private float responseF { get; set; }

    public Produto(int id, string name, float price, int stock, string description, string category, float rating, float acceptanceF, float toleranceF, float responseF)
    {
        this.id = id;
        this.name = name;
        this.price = price;
        this.stock = stock;
        this.description = description;
        this.category = category;
        this.rating = rating;
        this.acceptanceF = acceptanceF;
        this.toleranceF = toleranceF;
        this.responseF = responseF;
    }

    public override bool Equals(object? obj)
    {
        return obj is Produto produto &&
               id == produto.id &&
               name == produto.name &&
               price == produto.price &&
               stock == produto.stock &&
               description == produto.description &&
               category == produto.category &&
               rating == produto.rating &&
               acceptanceF == produto.acceptanceF &&
               toleranceF == produto.toleranceF &&
               responseF == produto.responseF;
    }
}


