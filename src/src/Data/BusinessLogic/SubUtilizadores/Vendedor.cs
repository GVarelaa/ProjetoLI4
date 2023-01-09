using System;
using src.Data.BusinessLogic.SubFeiras;
namespace src.Data.BusinessLogic;

public class Vendedor
{
    private int nifVendedor { get; set; }
    private String nomeProprio { get; set; }
    private String apelido { get; set; }
    private String email { get; set; }
    private String passwordVendedor { get; set; }

    //private Dictionary<int, Produto> products;

    public Vendedor(int sellerNif, string name, string surname, string email, string password)
    {
        this.nifVendedor = sellerNif;
        this.nomeProprio = name;
        this.apelido = surname;
        this.email = email;
        this.passwordVendedor = password;
        //this.products = new Dictionary<int, Produto>();
    }

    public Vendedor() { }

    public override bool Equals(object? obj)
    {
        return obj is Vendedor seller &&
               nifVendedor == seller.nifVendedor &&
               nomeProprio.Equals(seller.nomeProprio) &&
               apelido.Equals(seller.apelido) &&
               email.Equals(seller.email) &&
               passwordVendedor.Equals(seller.passwordVendedor);
    }

    public override string ToString()
    {
        return nifVendedor + ", " + nomeProprio + ", " + apelido + ", " + email + ", " + passwordVendedor;
    }

}

