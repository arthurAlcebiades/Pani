using System;
using System.Collections.Generic;

namespace AspCore_Scaffolding.Models;

public partial class TbCliente
{
    public int Id { get; set; }

    public string NomeCliente { get; set; } = null!;

    public string CpfCnpj { get; set; } = null!;

    public long ContatoCliente { get; set; }

    public string EnderecoCliente { get; set; } = null!;
}
