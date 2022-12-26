using System;
using System.Collections.Generic;
using src.Data.Data;

namespace src.Data.BusinessLogic.SubFeiras;

public class SubFeirasFacade
{
    private FeirasDAO Feiras;

    public SubFeirasFacade()
    {
        this.Feiras = new FeirasDAO();
    }

    public List<Produto> GetProdutosFeira(string nomeFeira) // Para mostrar catálogo
    {
        Feira feira = this.Feiras.Get(nomeFeira);

        return feira.produtos;
    }

    public List<string> GetDetalhesFeira(string nomeFeira) // Para mostrar catálogo
    {
        Feira feira = this.Feiras.Get(nomeFeira);

        List<string> detalhes = new List<string>();
        detalhes.Add(feira.Nome);
        detalhes.Add(feira.Tema);
        detalhes.Add(feira.Local);

        return detalhes;
    }
}

