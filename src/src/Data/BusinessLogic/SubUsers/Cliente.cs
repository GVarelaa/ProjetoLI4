using System;
namespace src.Data.BusinessLogic;

public class Cliente
{
    private int clientNif { get; set; }
    private String name { get; set; }
    private String surname { get; set; }
    private String email { get; set; }
    private String password { get; set; }

    public Cliente(int clientNif, string name, string surname, string email, string password)
    {
        this.clientNif = clientNif;
        this.name = name;
        this.surname = surname;
        this.email = email;
        this.password = password;
    }

    public override bool Equals(object? obj)
    {
        return obj is Cliente client &&
               clientNif == client.clientNif &&
               name == client.name &&
               surname == client.surname &&
               email == client.email &&
               password == client.password;
    }
}

