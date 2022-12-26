using System;
namespace src.Data.BusinessLogic;

public class Vendedor
{
    private int sellerNif { get; set; }
    private String name { get; set; }
    private String surname { get; set; }
    private String email { get; set; }
    private String password { get; set; }

    private Dictionary<int, Produto> products;

    public Vendedor(int sellerNif, string name, string surname, string email, string password)
    {
        this.sellerNif = sellerNif;
        this.name = name;
        this.surname = surname;
        this.email = email;
        this.password = password;

        this.products = new Dictionary<int, Produto>();
    }

    public override bool Equals(object? obj)
    {
        return obj is Vendedor seller &&
               sellerNif == seller.sellerNif &&
               name == seller.name &&
               surname == seller.surname &&
               email == seller.email &&
               password == seller.password;
    }
}

