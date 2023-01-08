using System;
namespace src.Data.Data;

public class DAOConfig
{
    public const string ADDRESS = "localhost";
    public const string DBNAME = "UMarket";
    public const string USER = "teste";
    public const string PASSWORD = "123";

    public const string URL = "Data Source=" + ADDRESS + ";Initial Catalog=" + DBNAME + ";User Id=" + USER + ";Password=" + PASSWORD + ";Trusted_Connection=true;Trust Server Certificate=true";
}

