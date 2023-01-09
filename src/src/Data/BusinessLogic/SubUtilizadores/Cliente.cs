using Dapper.Contrib.Extensions;
using System;
namespace src.Data.BusinessLogic;

[Table("Cliente")]
public class Cliente
{
    [Key]
    private int nifClient { get; set; }
    private String nomeProprio { get; set; }
    private String apelido { get; set; }
    private String email { get; set; }
    private String passwordCliente { get; set; }

    public Cliente() { }

    public Cliente(int clientNif, string name, string surname, string email, string password)
    {
        this.nifClient = clientNif;
        this.nomeProprio = name;
        this.apelido = surname;
        this.email = email;
        this.passwordCliente = password;
    }

    public override bool Equals(object? obj)
    {
        return obj is Cliente client &&
               nifClient == client.nifClient &&
               nomeProprio.Equals(client.nomeProprio) &&
               apelido == client.apelido &&
               email.Equals(client.email) &&
               passwordCliente.Equals(client.passwordCliente);
    }

    public override string ToString()
    {
        return this.nifClient + ", " + this.nomeProprio + ", " + this.apelido + ", " + this.email + ", " + this.passwordCliente;
    }

}

