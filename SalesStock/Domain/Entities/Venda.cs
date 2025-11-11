namespace SalesStock.Domain.Entities;

public class Venda
{
    public int Id { get; set; }
    public string Cliente { get; set; } = string.Empty;
    public string Produto { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public decimal ValorTotal { get; set; }
    public DateTime DataVenda { get; set; } = DateTime.Now;
}
