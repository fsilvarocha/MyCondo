﻿using MyCondo.Domain.Transfer.DataTransfer.Base;

namespace MyCondo.Domain.Transfer.DataTransfer.Bloco.Response;

public class BlocosResponse : BaseResponse
{
    public string Nome { get; set; }
    public int QuantidadeAndar { get; set; }
}
