using System;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Data.SqlClient;
using src.Data.BusinessLogic;

namespace src.Data.Data;

public class VendedoresDAO
{
    private static VendedoresDAO vendedores = null;

    private VendedoresDAO()
    {
    }

    public static VendedoresDAO GetInstace()
    {
        if (vendedores == null)
        {
            vendedores = new VendedoresDAO();
        }
        return vendedores;
    }


    public Vendedor Get(int key)
    {
        const string connectionString = DAOConfig.URL;
        Vendedor v;

        using (var connection = new SqlConnection(connectionString))
        {
            v = connection.Get<Vendedor>(key);
        }

        return v;
    }

    public Vendedor Insert(Vendedor v)
    {
        const string connectionString = DAOConfig.URL;

        using (var connection = new SqlConnection(connectionString))
        {
            connection.Insert<Vendedor>(v);
        }

        return v;
    }

    public Vendedor Delete(int key)
    {
        Vendedor v = Get(key);

        const string connectionString = DAOConfig.URL;

        using (var connection = new SqlConnection(connectionString))
        {
            connection.Delete<Vendedor>(v);
        }

        return v;
    }

    public IEnumerable<Vendedor> GetAll()
    {
        const string connectionString = DAOConfig.URL;
        IEnumerable<Vendedor> vs;

        using (var connection = new SqlConnection(connectionString))
        {
            vs = connection.GetAll<Vendedor>();
        }
        return vs;
    }


}
