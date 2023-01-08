using System;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using src.Data.BusinessLogic.SubFeiras;

namespace src.Data.Data;

public class ProdutosDAO
{
    private static ProdutosDAO singleton = null;
    private ProdutosDAO()
    {
    }

    public static ProdutosDAO GetInstance()
    {
        if (singleton == null)
        {
            singleton = new ProdutosDAO();
        }

        return singleton;
    }
    public Produto Get(int id)
    {
        const string connectionString = DAOConfig.URL;
        Produto p;

        using (var connection = new SqlConnection(connectionString))
        {
            p = connection.Get<Produto>(id);
        }

        return p;
    }

    public IEnumerable<Produto> GetProdutosFeira(string nomeFeira)
    {
        const string connectionString = DAOConfig.URL;
        IEnumerable<Produto> ps = new List<Produto>();

        using (var connection = new SqlConnection(connectionString))
        {
            IEnumerable<int> ids = connection.Query<int>("SELECT idProduto FROM Produto WHERE nomeFeira=" + nomeFeira);

            foreach(int id in ids)
            {
                ps.Append(Get(id));
            }
        }
        return ps;
    }

    public Produto Insert(Produto p)
    {
        const string connectionString = DAOConfig.URL;

        using (var connection = new SqlConnection(connectionString))
        {
            connection.Insert<Produto>(p);
        }

        return p;
    }

    public Produto Delete(int key)
    {
        Produto p = Get(key);

        const string connectionString = DAOConfig.URL;

        using (var connection = new SqlConnection(connectionString))
        {
            connection.Delete<Produto>(p);
        }

        return p;
    }

   public IEnumerable<Produto> GetAll() 
   {
        const string connectionString = DAOConfig.URL;
        IEnumerable<Produto> produtos;

        using (var connection = new SqlConnection(connectionString))
        {
            produtos = connection.GetAll<Produto>();
        }

        return produtos;
    }


}
