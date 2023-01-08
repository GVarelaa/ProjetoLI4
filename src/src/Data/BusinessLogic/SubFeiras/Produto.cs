using System;
namespace src.Data.BusinessLogic.SubFeiras;

public class Produto
{
   
    private int Id { get; set; }
    private string Nome { get; set; }
    private float Preco { get; set; }
    private int Stock { get; set; }
    private string Descricao { get; set; }
    private string Categoria { get; set; }
    private float Avaliacao { get; set; }
    private float FatorAceitacao { get; set; }
    private float FatorTolerancia { get; set; }
    private float FatorResposta { get; set; }

    public Produto(int id, string nome, float preco, int stock, string descricao, string categoria, float avaliacao, float fatorAceitacao, float fatorTolerancia, float fatorResposta)
    {
        Id = id;
        Nome = nome;
        Preco = preco;
        Stock = stock;
        Descricao = descricao;
        Categoria = categoria;
        Avaliacao = avaliacao;
        FatorAceitacao = fatorAceitacao;
        FatorTolerancia = fatorTolerancia;
        FatorResposta = fatorResposta;
    }

    public override bool Equals(object? obj)
    {
        return obj is Produto produto &&
               Id == produto.Id &&
               Nome.Equals(produto.Nome) &&
               Preco == produto.Preco &&
               Stock == produto.Stock &&
               Descricao.Equals(produto.Descricao) &&
               Categoria.Equals(produto.Categoria) &&
               Avaliacao == produto.Avaliacao &&
               FatorAceitacao == produto.FatorAceitacao &&
               FatorTolerancia == produto.FatorTolerancia &&
               FatorResposta == produto.FatorResposta;
    }
}

