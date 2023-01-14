﻿using Dapper.Contrib.Extensions;
using src.Data.Data;
using System;
namespace src.Data.BusinessLogic;

[Table("Cliente")]
public class Cliente
{
    [ExplicitKey]
    private int nifCliente { get; set; }
    private String nomeProprio { get; set; }
    private String apelido { get; set; }
    private String email { get; set; }
    private String passwordCliente { get; set; }

    public Cliente() { }

    public Cliente(int clientNif, string name, string surname, string email, string password)
    {
        this.nifCliente = clientNif;
        this.nomeProprio = name;
        this.apelido = surname;
        this.email = email;
        this.passwordCliente = password;
    }

    public override bool Equals(object? obj)
    {
        return obj is Cliente client &&
               nifCliente == client.nifCliente &&
               nomeProprio.Equals(client.nomeProprio) &&
               apelido == client.apelido &&
               email.Equals(client.email) &&
               passwordCliente.Equals(client.passwordCliente);
    }

    public override string ToString()
    {
        return this.nifCliente + ", " + this.nomeProprio + ", " + this.apelido + ", " + this.email + ", " + this.passwordCliente;
    }

}

