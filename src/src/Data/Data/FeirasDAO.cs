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

    public Feira Put(Feira f)
    {
        const string connectionString = "Server=" + DAOConfig.Address +
                                        ";Database=" + DAOConfig.NomeBD +
                                        ";User ID=" + DAOConfig.User +
                                        ";Password=" + DAOConfig.Password;

        using (var connection = new SqlConnection(connectionString))
        {
            connection.Execute("INSERT INTO Feira VALUES ("
                                                + f.nomeFeira + ", "
                                                + f.tema + ", "
                                                + f.descricao + ", "
                                                + f.localFeira + ") ON DUPLICATE KEY UPDATE "
                                                                                    + "tema='" + f.tema + "', "
                                                                                    + "descricao='" + f.descricao + "', "
                                                                                    + "localFeira='" + f.localFeira + "')");
        }
    }

    public Feira Remove(int key)
    {
        Feira f = Get(key);

        const string connectionString = "Server=" + DAOConfig.Address +
                                        ";Database" + DAOConfig.NomeBD +
                                        ";User ID" + DAOConfig.User +
                                        ";Password=" + DAOConfig.Password;

        using (var connection = new SqlConnection(connectionString))
        {
            connection.Execute("DELETE FROM Feira WHERE nomeFeira='" + key.ToString() + "')")
        }

        return f;
    }
}

