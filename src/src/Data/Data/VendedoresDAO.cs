/*
using System;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using src.Data.BusinessLogic.SubUtilizadores;

namespace src.Data.Data;

public class VendedoresDAO
{
    public VendedoresDAO()
    {
    }

    public Vendedor Get(int key)
    {
        const string connectionString = "Server=" + DAOConfig.Address +
                                        ";Database=" + DAOConfig.NomeBD +
                                        ";User ID=" + DAOConfig.User +
                                        ";Password=" + DAOConfig.Password;

        Vendedor vendedor = new Vendedor();
        using (var connection = new SqlConnection(connectionString))
        {
            vendedor = connection.Get<Vendedor>(key);
        }

        return vendedor;
    }

    public Vendedor Put(Vendedor v)
    {
        const string connectionString = "Server=" + DAOConfig.Address +
                                        ";Database" + DAOConfig.NomeBD +
                                        ";User ID" + DAOConfig.User +
                                        ";Password=" + DAOConfig.Password;

        using (var connection = new SqlConnection(connectionString))
        {
            connection.Execute("INSERT INTO Vendedor VALUES ("
                                                   + v.nifVendedor.ToString() + ", "
                                                   + v.nomeProprio + ", "
                                                   + v.apelido + ", "
                                                   + v.email + ", " 
                                                   + v.passwordVendedor.ToString() + ") ON DUPLICATE KEY UPDATE "
                                                                                                       + "nomeProprio='" + v.nomeProprio + "', "
                                                                                                       + "apelido='" + v.apelido + "', "
                                                                                                       + "email='" + v.email + "', "
                                                                                                       + "passwordVendedor='" + v.passwordVendedor + "')");
        }
    }

    public Vendedor Remove(int key)
    {
        Vendedor v = Get(key);

        const string connectionString = "Server=" + DAOConfig.Address +
                                        ";Database" + DAOConfig.NomeBD +
                                        ";User ID" + DAOConfig.User +
                                        ";Password=" + DAOConfig.Password;

        using (var connection = new SqlConnection(connectionString))
        {
            connection.Execute("DELETE FROM Vendedor WHERE nifVendedor='" + key.ToString() + "')");
        }

        return v;
    }
}
*/
