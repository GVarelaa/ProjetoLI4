using System;
namespace src.Data.BusinessLogic.SubFeiras;

public interface ISubFeiras
{
    public Task<IEnumerable<Feira>> GetFeiras();

    public Task<Feira> GetFeira(string nome);

    public Task<Produto> GetProduto(int id);

    public Task<IEnumerable<Produto>> GetProdutos(string nomeFeira);

    public void AddProduto();

    public void AddFeira();


}

