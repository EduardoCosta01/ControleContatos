﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Contatos.Helper
{
    public interface IEmail
    {
        bool Enviar(string email, string assunto, string messagem);
    }
}
