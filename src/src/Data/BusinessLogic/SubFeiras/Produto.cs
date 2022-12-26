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

}

