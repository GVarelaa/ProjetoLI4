using src.Data.Data;

namespace src.Data.BusinessLogic.SubCompras;

[Table("Compra")]
public class Compra
{
    [Key]
    public int idCompra { get; set; }
    public string nomeFaturacao { get; set; }
    public string moradaEntrega { get; set; }
    public string telemovel { get; set; }
    public float valorTotal { get; set; }
    public DateTime timestamp { get; set; }
    public int nifCliente { get; set;}

    public Compra(int idCompra, string nomeFaturacao, string moradaEntrega, string telemovel, float valorTotal, DateTime timestamp, int nifCliente)
    {
        this.idCompra = idCompra;
        this.nomeFaturacao = nomeFaturacao;
        this.moradaEntrega = moradaEntrega;
        this.telemovel = telemovel;
        this.valorTotal = valorTotal;
        this.timestamp = timestamp;
        this.nifCliente = nifCliente;
    }

    public override bool Equals(object? obj)
    {
        return obj is Compra compra &&
               this.idCompra == compra.idCompra &&
               this.nomeFaturacao.Equals(compra.nomeFaturacao) &&
               this.moradaEntrega.Equals(compra.moradaEntrega) &&
               this.telemovel.Equals(compra.telemovel) &&
               this.valorTotal == compra.valorTotal &&
               this.timestamp.Equals(compra.timestamp) &&
               this.nifCliente == compra.nifCliente;
    }

    public override string ToString()
    {
        return this.idCompra + ", " + this.nomeFaturacao + ", " + this.moradaEntrega + ", " + this.telemovel + ", " + this.valorTotal + ", " + this.timestamp + ", " + this.nifCliente;
    }

}