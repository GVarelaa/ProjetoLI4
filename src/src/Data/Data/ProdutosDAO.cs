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
            IEnumerable<int> ids = connection.Query<int>("SELECT idProduto FROM Produto WHERE nomeFeira='" + nomeFeira + "'");

            foreach(int id in ids)
            {
                ps = ps.Append(Get(id));
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
                ps = ps.Append(Get(id));
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
            favs = favs.Append(Get(idP));
        }

        return favs;
    }

    public IEnumerable<Tuple<int, int>> GetAvaliacoes(int nifCliente)
    {
        const string connectionString = DAOConfig.URL;
        IEnumerable<Tuple<int, int>> idsP;

        using (var connection = new SqlConnection(connectionString))
        {
            idsP = connection.Query<Tuple<int, int>>("SELECT idProduto,valorAval FROM Avaliacao WHERE nifCliente=" + nifCliente);
        }

        return idsP;
    }


    public Produto Insert(Produto p)
    {
        const string connectionString = DAOConfig.URL;
        long id;

        using (var connection = new SqlConnection(connectionString))
        {
            id = connection.Insert<Produto>(p);
        }

        return Get((int) id);
    }

    public void InsertAvaliacao(int nifCliente, int idProduto, int valorAval)
    {
        const string connectionString = DAOConfig.URL;

        using (var connection = new SqlConnection(connectionString))
        {
            int affected = connection.Execute("UPDATE Avaliacao SET valorAval=" + valorAval + " WHERE (nifCliente=" + nifCliente + ", idProduto= " + idProduto + ")");
            if (affected == 0)
            {
                connection.Execute("INSERT INTO Avaliacao (nifCliente, idProduto, valorAval) VALUES (" + nifCliente + "," + idProduto + "," + valorAval+ ")");
            }
        }
    }

    public void UpdateAvaliacaoProduto(int idProduto)
    {
        const string connectionString = DAOConfig.URL;

        using (var connection = new SqlConnection(connectionString))
        {
            IEnumerable<int> avaliacoes = connection.Query<int>("SELECT * FROM Avaliacao WHERE idProduto=" + idProduto);

            float soma = 0;
            int n = 0;
            foreach(var avaliacao in avaliacoes)
            {
                soma += avaliacao;
                n++;
            }

            float avaliacaoMedia = soma / (float)n;

            connection.Execute("UPDATE Produto SET avaliacaoMedia=" + avaliacaoMedia + "WHERE idProduto=" + idProduto);
        }
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

    public IEnumerable<(DateTime timestamp, float valorVenda, int quantidade, int nifCliente)>GetComprasProduto(int idProduto)
    {
        const string connectionString = DAOConfig.URL;

        IEnumerable<(DateTime, float, int, int)> compras = new List<(DateTime, float, int, int)>();

        using (var connection = new SqlConnection(connectionString))
        {
            IEnumerable<(int, float, int)> transacoes = connection.Query<(int, float, int)>("SELECT idCompra,valorVenda,quantidade FROM ProdutoDaCompra WHERE idProduto=" + idProduto);

            foreach(var transacao in transacoes)
            {
                IEnumerable<(int, DateTime)> compra = connection.Query<(int, DateTime)>("SELECT nifCliente, timestampCompra FROM Compra WHERE idCompra=" + idProduto);
                compras = compras.Append((compra.First().Item2, transacao.Item2, transacao.Item3, compra.First().Item1));
            }
        }


        return compras;
    }
}
