﻿using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    public abstract class EntidadeBase
    {
        public int Id { get; set; }

        public abstract ArrayList Validar();
    }
}