using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;
using src.Data.BusinessLogic.SubFeiras;
using src.Data.BusinessLogic.SubCompras;
using System;
using Microsoft.Data.SqlClient;


namespace src.Data.Data;

public class ComprasDAO
{
    private static ComprasDAO compras = null;

    private ComprasDAO() { }

    public static ComprasDAO getInstance()
    {
        if(compras == null)
        {
            compras = new ComprasDAO();
        }

        return compras;
    }

    public Compra Get(int id)
    {
        const string connectionString = DAOConfig.URL;

        Compra c;
        using (var connection = new SqlConnection(connectionString))
        {
            c = connection.Get<Compra>(id);
        }

        return c;
    }

    public Compra Insert(Compra compra)
    {
        const string connectionString = DAOConfig.URL;

        long id;
        using (var connection = new SqlConnection(connectionString))
        {
            id = connection.Insert<Compra>(compra);
        }

        return Get((int)id);
    }

    public IEnumerable<Compra> GetAll()
    {
        const string connectionString = DAOConfig.URL;

        IEnumerable<Compra> compras;
        using (var connection = new SqlConnection(connectionString))
        {
            compras = connection.GetAll<Compra>();
        }
        return compras;
    }

    public void InsertProdutoCompra(int idCompra, int idProduto, float valorVenda)
    {
        const string connectionString = DAOConfig.URL;

        using (var connection = new SqlConnection(connectionString))
        {
            connection.Execute("INSERT INTO ProdutoDaCompra (idCompra, valorVenda, idProduto) VALUES (" + idCompra + "," + valorVenda + "," + idProduto + ")");
        }
    }

    public void InsertProdutoCarrinho(int nifCliente, int idProduto, float valorVenda, int quantidade)
    {
        const string connectionString = DAOConfig.URL;

        using (var connection = new SqlConnection(connectionString))
        {
            IEnumerable<int> quantidades = connection.Query<int>("SELECT quantidade FROM Carrinho WHERE nifCliente=" + nifCliente + "and idProduto=" + idProduto);
            int quantidadeAnterior = quantidades.First();

            int affected = connection.Execute("UPDATE Carrinho SET valorVenda=" + valorVenda + ", quantidade=" + (quantidade+quantidadeAnterior) + " WHERE idProduto= " + idProduto);
            if (affected == 0) {
                connection.Execute("INSERT INTO Carrinho (nifCliente,idProduto,valorVenda) VALUES (" + nifCliente + "," + idProduto + "," + valorVenda + ")");
            }
        }

    }

    public Boolean DeleteProdutoCarrinho(int nifCliente, int idProduto)
    {
        const string connectionString = DAOConfig.URL;
        int nrows;

        using (var connection = new SqlConnection(connectionString))
        {
            nrows = connection.Execute("DELETE FROM Carrinho WHERE (nifCliente=" + nifCliente + "and idProduto=" + idProduto + ")");
        }

        return nrows > 0;
    }

    public IEnumerable<(Produto, float, int)> GetProdutosCarrinho(int nifCliente)
    {
        const string connectionString = DAOConfig.URL;
        IEnumerable<(int, float, int)> idpds;

        using (var connection = new SqlConnection(connectionString))
        {
            idpds = connection.Query<(int, float, int)>("SELECT idProduto,valorVenda,quantidade FROM Carrinho WHERE nifCliente=" + nifCliente);
        }

        IEnumerable<(Produto, float, int)> pds = new List<(Produto, float, int)>();

        foreach ((int, float, int) t in idpds)
        {
            Produto produto;
            using (var connection = new SqlConnection(connectionString))
            {
                produto = connection.Get<Produto>(t.Item1);
            }

            pds = pds.Append((produto, t.Item2, t.Item3));
        }

        return pds;
    }
}