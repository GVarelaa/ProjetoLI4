using Dapper.Contrib.Extensions;
using System;
namespace src.Data.BusinessLogic.SubFeiras;

[Table("Produto")]
public class Produto
{
    [Key]
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

    public Produto() { }

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

    public override string ToString()
    {
        return this.Id + ", " + this.Nome + ", " + this.Preco + ", " + 
               this.Stock + ", " + this.Descricao + ", " + this.Categoria + ", " +
               this.Avaliacao + ", " + this.FatorAceitacao + ", " + this.FatorTolerancia + ", " + 
               this.FatorResposta;
    }

}

