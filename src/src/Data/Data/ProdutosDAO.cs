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

    public IEnumerable<Produto> GetProdutosVendedor(int nif)
    {
        const string connectionString = DAOConfig.URL;
        IEnumerable<Produto> ps = new List<Produto>();

        using (var connection = new SqlConnection(connectionString))
        {
            IEnumerable<int> ids = connection.Query<int>("SELECT idProduto FROM Produto WHERE nifVendedor=" + nif);

            foreach (int id in ids)
            {
                ps.Append(Get(id));
            }
        }
        return ps;
    }

    public IEnumerable<Produto> GetFavs(int id)
    {
        const string connectionString = DAOConfig.URL;
        IEnumerable<int> idsP;

        using (var connection = new SqlConnection(connectionString))
        {
            idsP = connection.Query<int>("SELECT idProduto FROM Favorito where nifCliente=" + id);
        }

        IEnumerable<Produto> favs = new List<Produto>();
        foreach (int idP in idsP)
        {
            favs.Append(Get(idP));
        }

        return favs;
    }

    public IEnumerable<Tuple<int, int>> GetAvaliacoes(int nifCliente)
    {
        const string connectionString = DAOConfig.URL;
        IEnumerable<Tuple<int, int>> idsP;

        using (var connection = new SqlConnection(connectionString))
        {
            idsP = connection.Query<Tuple<int, int>>("SELECT (idProduto,valorAval) FROM Avaliacao WHERE nifCliente=" + nifCliente);
        }

        return idsP;
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


    public int GetAvaliacaoMediaProduto(int idProduto)
    {
        const string connectionString = DAOConfig.URL;
        IEnumerable<int> avals;

        using (var connection = new SqlConnection(connectionString))
        {
            avals = connection.Query<int>("SELECT valorAval FROM Avaliacao WHERE idProduto=" + idProduto);
        }

        int soma = avals.Sum();
        return soma / (avals.Count());
    }

    public IEnumerable<Tuple<Produto, float>> GetProdutosCarrinho(int nifCliente)
    {
        const string connectionString = DAOConfig.URL;
        IEnumerable<Tuple<int,float>> idpds;

        using (var connection = new SqlConnection(connectionString))
        {
            idpds = connection.Query<Tuple<int,float>>("SELECT (idProduto,valorVenda) FROM Carrinho where nifCliente=" + nifCliente);
        }

        IEnumerable<Tuple<Produto, float>> pds = new List<Tuple<Produto,float>>();

        foreach (Tuple<int,float> t in idpds)
        {
            pds.Append(new Tuple<Produto, float>(Get(t.Item1), t.Item2));
        }

        return pds;
    }


}
