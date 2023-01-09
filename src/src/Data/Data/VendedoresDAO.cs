using System;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;
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

    public Vendedor Put(Vendedor v)
    {
        
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
