using System;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using src.Data.BusinessLogic.SubFeiras;

namespace src.Data.Data;

public class FeirasDAO
{
    public FeirasDAO()
    {
    }

    public Feira Get(string Nome)
    {
        const string connectionString = "Server=" + DAOConfig.Address +
                                        ";Database" + DAOConfig.NomeBD +
                                        ";User ID" + DAOConfig.User +
                                        ";Password=" + DAOConfig.Password;

        Feira feira;
        using (var connection = new SqlConnection(connectionString))
        {
            feira = connection.Get<Feira>(Nome);
        }

        return feira;
    }
}

