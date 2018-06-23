﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agenda.Models
{
    public class RepositorioDePessoas
    {
        public List<Pessoa> listaPessoas = new List<Pessoa>();

        public RepositorioDePessoas()
        {
            listaPessoas.Add(new Pessoa
            {
                Nome = "Leo",
                Sobrenome = "Messi",
                DataDeAniversario = Convert.ToDateTime("05/09/1975")
            });
        }
    }
}