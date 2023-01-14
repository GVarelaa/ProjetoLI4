using src.Data.BusinessLogic.SubFeiras;

namespace src.Data.BusinessLogic.SubCompras;

public interface ISubCompras
{
    public void AddCompra(int nifCliente, string nomeFaturacao, string morada, string telemovel);

    public Task<IEnumerable<Tuple<Produto, float>>> GetCarrinho(int nifCliente);
}