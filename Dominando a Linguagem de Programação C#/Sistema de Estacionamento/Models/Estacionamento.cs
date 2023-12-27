using System.Globalization;
using System.Text.RegularExpressions;

namespace Sistema_de_Estacionamento.Models;

public class Estacionamento
{
    private decimal valorInicial = 0;
    private decimal valorPorHora = 0;
    private List<CarroDetalhe> carros = new();

    public Estacionamento(decimal valorInicial, decimal valorPorHora)
    {
        this.valorInicial = valorInicial;
        this.valorPorHora = valorPorHora;
    }

    public void adicionarNovoCarro(string placaCarro)
    {
        bool carroExiste = false;
        foreach (var carroDetalhe in carros)
        {
            if (carroDetalhe.PlacaCarro == placaCarro)
            {
                Console.WriteLine("Não foi possível adicionar o carro pois já possui um carro de mesma placa!");
                carroExiste = true;
            }
        }

        if (!carroExiste)
        {
            CarroDetalhe c = new(placaCarro);
            carros.Add(c);
            Console.WriteLine("Carro adicionado com sucesso");
        }
    }

    public int tamanhoListaCarros()
    {
        return carros.Count;
    }

    public List<CarroDetalhe> retornarListaCarros()
    {
        return carros;
    }

    public decimal apurarFaturamento()
    {
        decimal valorTotalApurado = 0M;

        foreach (var carroDetalhe in carros)
        {
            if (carroDetalhe.status == Status.BAIXADO)
            {
                valorTotalApurado += (((decimal)carroDetalhe.horasTotais.TotalHours * valorPorHora) + valorInicial);
            }
        }

        return valorTotalApurado;
    }

    public void listarCarros()
    {
        for (int i = 0; i < carros.Count; i++)
        {
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine($"ID: {i + 1}");
            Console.WriteLine($"Placa do Carro: {carros[i].PlacaCarro}");
            Console.WriteLine($"Horario de Entrada: {carros[i].horarioEntrada}");
            Console.WriteLine($"Horario de Saida: {carros[i].horarioSaida}");
            Console.WriteLine($"Permanencia Total: {carros[i].horasTotais}");
            Console.WriteLine(
                $"Valor total a pagar: {(((decimal)carros[i].horasTotais.TotalHours * valorPorHora) + valorInicial):C}");
            Console.WriteLine($"Status: {carros[i].status}");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
        }
    }
}