﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitoRestobar.Interfaces
{
    public interface ICalculable
    {
        float CalcularTotalPedido();
        float CalcularSubTotalPedido();
        float CalcularDescuentoPedido();
    }
}
