﻿using System;
using System.Collections.Generic;
using System.Globalization;
using src.Data.Data;

namespace src.Data.BusinessLogic.SubFeiras;

public class SubFeirasFacade
{
    private FeirasDAO Feiras;
    private ProdutosDAO Produtos;

    public SubFeirasFacade()
    {
        this.Feiras = FeirasDAO.GetInstance();
        this.Produtos = ProdutosDAO.GetInstance();
    }

    public Task<IEnumerable<Feira>> GetFeiras()
    {
        return Task.FromResult(Feiras.GetAll());
    }

    public Task<Feira> GetFeira(string nome)
    {
        return Task.FromResult(Feiras.Get(nome));
    }

    public Task<Produto> GetProduto(int id) 
    {
        return Task.FromResult(Produtos.Get(id));
    }
       
    public Task<IEnumerable<Produto>> GetProdutos(string nomeFeira)
    {
        return Task.FromResult(Produtos.GetProdutosFeira(nomeFeira));
    }

}

