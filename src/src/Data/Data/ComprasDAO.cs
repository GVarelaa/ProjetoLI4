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

        using (var connection = new SqlConnection(connectionString))
        {
            connection.Insert<Compra>(compra);
        }

        return compra;
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

    public void InsertProdutoCompra(int idCompra, int idProduto, int nifCliente, float valorVenda)
    {
        const string connectionString = DAOConfig.URL;

        using (var connection = new SqlConnection(connectionString))
        {
            connection.Execute("INSERT INTO ProdutoDaCompra (idCompra, nifCliente, valorVenda, idProduto) VALUES (" + idCompra + "," + nifCliente + "," + valorVenda + "," + idProduto + ")");
        }
    }

    public void InsertProdutoCarrinho(int nifCliente, int idProduto, int valorVenda)
    {
        const string connectionString = DAOConfig.URL;

        using (var connection = new SqlConnection(connectionString))
        {
            connection.Execute("INSERT INTO Carrinho (nifCliente,idProduto,valorVenda) VALUES (" + nifCliente + "," + idProduto + "," + valorVenda + ")");
        }

    }

    public Boolean DeleteProdutoCarinho(int nifCliente, int idProduto)
    {
        const string connectionString = DAOConfig.URL;
        int nrows;

        using (var connection = new SqlConnection(connectionString))
        {
            nrows = connection.Execute("DELETE FROM Carrinho WHERE (nifCliente=" + nifCliente + "and idProduto=" + idProduto + ")");
        }

        return nrows > 0;
    }

    public IEnumerable<Tuple<Produto, float>> GetProdutosCarrinho(int nifCliente)
    {
        const string connectionString = DAOConfig.URL;
        IEnumerable<Tuple<int, float>> idpds;

        using (var connection = new SqlConnection(connectionString))
        {
            idpds = connection.Query<Tuple<int, float>>("SELECT (idProduto,valorVenda) FROM Carrinho where nifCliente=" + nifCliente);
        }

        IEnumerable<Tuple<Produto, float>> pds = new List<Tuple<Produto, float>>();

        foreach (Tuple<int, float> t in idpds)
        {
            Produto produto;
            using (var connection = new SqlConnection(connectionString))
            {
                produto = connection.Get<Produto>(t.Item1);
            }

            pds.Append(new Tuple<Produto, float>(produto, t.Item2));
        }

        return pds;
    }
}