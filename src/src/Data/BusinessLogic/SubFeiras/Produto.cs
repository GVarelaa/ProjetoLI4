using Dapper.Contrib.Extensions;
using System;
namespace src.Data.BusinessLogic.SubFeiras;

[Table("Produto")]
public class Produto
{
    [Key]
    private int idProduto { get; set; }
    private string nome { get; set; }
    private float preço { get; set; }
    private int stock { get; set; }
    private string descricao { get; set; }
    private string categoria { get; set; }
    private float avaliacaoMedia { get; set; }
    private float fatorAceitacao { get; set; }
    private float fatorTolerancia { get; set; }
    private float fatorResposta { get; set; }


    public Produto(int id, string nomeProduto, float preco, int stockP, string descricaoP, string categoriaP, float avaliacao, float fatorAceitacaoP, float fatorToleranciaP, float fatorRespostaP)
    {
        idProduto = id;
        nome = nomeProduto;
        preço = preco;
        stock = stockP;
        descricao = descricaoP;
        categoria = categoriaP;
        avaliacaoMedia = avaliacao;
        fatorAceitacao = fatorAceitacaoP;
        fatorTolerancia = fatorToleranciaP;
        fatorResposta = fatorRespostaP;
    }

    public Produto() { }

    public override bool Equals(object? obj)
    {
        return obj is Produto produto &&
               idProduto == produto.idProduto &&
               nome.Equals(produto.nome) &&
               preço == produto.preço &&
               stock == produto.stock &&
               descricao.Equals(produto.descricao) &&
               categoria.Equals(produto.categoria) &&
               avaliacaoMedia == produto.avaliacaoMedia &&
               fatorAceitacao == produto.fatorAceitacao &&
               fatorTolerancia == produto.fatorTolerancia &&
               fatorResposta == produto.fatorResposta;
    }

    public override string ToString()
    {
        return this.idProduto + ", " + this.nome + ", " + this.preço + ", " +
               this.stock + ", " + this.descricao + ", " + this.categoria + ", " +
               this.avaliacaoMedia + ", " + this.fatorAceitacao + ", " + this.fatorTolerancia + ", " +
               this.fatorResposta;
    }

}

