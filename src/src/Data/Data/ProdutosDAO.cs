/*
using System;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using src.Data.BusinessLogic.SubFeiras;

namespace src.Data.Data;

public class ProdutosDAO
{
    public ProdutosDAO()
    {
    }

    public Produto Get(string id)
    {
        const string connectionString = "Server=" + DAOConfig.Address +
                                        ";Database" + DAOConfig.NomeBD +
                                        ";User ID" + DAOConfig.User +
                                        ";Password=" + DAOConfig.Password;

        Produto produto = new Produto();
        using (var connection = new SqlConnection(connectionString))
        {
            produto = connection.Get<Produto>(id);
        }

        return produto;
    }

    public Produto Put(Produto p)
    {
        const string connectionString = "Server=" + DAOConfig.Address +
                                        ";Database=" + DAOConfig.NomeBD +
                                        ";User ID=" + DAOConfig.User +
                                        ";Password=" + DAOConfig.Password;

        using (var connection = new SqlConnection(connectionString))
        {
            connection.Execute("INSERT INTO Produto VALUES ("
                                                  + p.idProduto.ToString() + ", "
                                                  + p.nome + ", "
                                                  + p.preco.ToString() + ", "
                                                  + p.stock.ToString() + ", " 
                                                  + p.descricao + ", "
                                                  + p.categoria + ", "
                                                  + p.avaliacaoMedia.ToString() + ", "
                                                  + p.fatorAceitacao.ToString() + ", "
                                                  + p.fatorTolerancia.ToString() + ", "
                                                  + p.fatorResposta.ToString() + ", "
                                                  + p.nomeFeira. + ", "
                                                  + p.nifVendedor.ToString() + ") ON DUPLICATE KEY UPDATE "
                                                                                                 + "nome='" + p.nome + "', "
                                                                                                 + "preco='" + p.preco.ToString() + "', "
                                                                                                 + "stock='" + p.stock.ToString() + "', "
                                                                                                 + "descricao='" + p.descricao + "', "
                                                                                                 + "categoria='" + p.categoria + "', "
                                                                                                 + "avaliacoMedia='" + p.avaliacoMedia.ToString() + "', "
                                                                                                 + "fatorAceitacao='" + p.fatorAceitacao.ToString() + "', "
                                                                                                 + "fatorTolerancia='" + p.fatorTolerancia.ToString() + "', "
                                                                                                 + "fatorResposta='" + p.fatorResposta.ToString() + "', "
                                                                                                 + "nomeFeira='" + p.nomeFeira.ToString() + "', "
                                                                                                 + "nifVendedor='" + p.nifVendedor.ToString() + "')");
        }
    }

    public Produto Remove(int key)
    {
        Produto p = Get(key);

        const string connectionString = "Server=" + DAOConfig.Address +
                                        ";Database" + DAOConfig.NomeBD +
                                        ";User ID" + DAOConfig.User +
                                        ";Password=" + DAOConfig.Password;

        using (var connection = new SqlConnection(connectionString))
        {
            connection.Execute("DELETE FROM Produto WHERE idProduto='" + key.ToString() + "')");
        }

        return p;
    }
}
*/
