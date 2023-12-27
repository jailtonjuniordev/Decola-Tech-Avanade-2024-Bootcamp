using System.Text.RegularExpressions;

namespace Sistema_de_Estacionamento.Models;

public class CarroDetalhe
{
    public CarroDetalhe(string placaCarro)
    {
        this.placaCarro = placaCarro;
        this.horarioEntrada = DateTime.Now;
        this.horarioSaida = DateTime.Now;
        this.horasTotais = horarioSaida - horarioEntrada;
        this.status = Status.NO_ESTACIONAMENTO;
    }

    private string placaCarro;
    public string PlacaCarro
    {
        get => placaCarro;
        set
        {
            if (value == "")
            {
                Console.WriteLine("A placa do carro não pode ser vazia!!");
            } else if (!validarPlaca(value))
            {
                Console.WriteLine("A placa do carro não está em acordo com as normas vigentes!");
            } else
            {
                placaCarro = value;
            }
        }
    }
    public DateTime horarioEntrada { get; set; }
    public DateTime horarioSaida { get; set; }
    public Status status { get; set; }
    public TimeSpan horasTotais { get; set; }
    
    private bool validarPlaca(string placaCarro)
    {
        bool formatoAntigo = Regex.IsMatch(placaCarro, @"^[A-Z]{3}-\d{4}$");
        bool formatoNovo = Regex.IsMatch(placaCarro, @"^[A-Z]{3}\d[A-Z]\d{2}$");

        return formatoAntigo || formatoNovo;
    }
}