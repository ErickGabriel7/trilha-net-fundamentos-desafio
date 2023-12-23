namespace DesafioFundamentos.Models;
public class Estacionamento
{
    private decimal precoInicial = 0;
    private decimal precoPorHora = 0;
    private List<string> veiculos = new List<string>();

    public Estacionamento(decimal precoInicial, decimal precoPorHora)
    {
        this.precoInicial = precoInicial;
        this.precoPorHora = precoPorHora;
    }

    public void AdicionarVeiculo()
    {
        Console.WriteLine("Digite a placa do veículo para estacionar:");
        veiculos.Add(Console.ReadLine());
    }

    public void RemoverVeiculo()
    {
        Console.WriteLine("Digite a placa do veículo para remover:");

        string placa = "";
        placa = Console.ReadLine();

        if (!veiculos.Exists(x => x.ToUpper() == placa.ToUpper()))
        {
            Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            return;
        }
        
        Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

        var horasInput = Console.ReadLine();
        var convertidoComSucesso = int.TryParse(horasInput, out int horas);
        
        if (!convertidoComSucesso || horas < 0)
        {
            Console.WriteLine("Valor inválido, tente novamente");
            return;
        }

        decimal valorTotal = precoInicial + (precoPorHora * horas);

        veiculos.Remove(placa);
        Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
    }

    public void ListarVeiculos()
    {
        if (!veiculos.Any())
        {
            Console.WriteLine("Não há veículos estacionados.");
            return;
        }

        Console.WriteLine("Os veículos estacionados são:");
        for (int i = 0; i < veiculos.Count; i++)
        {
            Console.WriteLine(veiculos[i]);
        }
    }
}
