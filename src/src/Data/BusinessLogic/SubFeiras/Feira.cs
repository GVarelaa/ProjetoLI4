﻿using System;
using src.Data.Data;

namespace src.Data.BusinessLogic.SubFeiras;

public class Feira
{
    public string Nome { get; set; }
    public string Tema { get; set; }
    public string Descricao { get; set; }
    public string Local { get; set; }

    public Feira(string nome, string tema, string descricao, string local)
    {
        this.Nome = nome;
        this.Tema = tema;
        this.Descricao = descricao;
        this.Local = local;
    }

    public override bool Equals(object? obj)
    {
        return obj is Feira feira &&
               Nome.Equals(feira.Nome) &&
               Tema.Equals(feira.Tema) &&
               Descricao.Equals(feira.Descricao) &&
               Local.Equals(feira.Local);
    }
}


