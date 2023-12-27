using System.Globalization;
using Sistema_de_Estacionamento.Models;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Bem-vindo ao Sistema de Estacionamento com C#!!");

        decimal valorInicial = ObterValor("Digite o valor inicial: ");
        decimal valorPorHora = ObterValor("Digite o valor por hora: ");

        Estacionamento e = new(valorInicial, valorPorHora);

        int escolha;
        string recebido;
        do
        {
            Console.WriteLine("-=-=-=-=MENU-=-=-=-=");
            Console.WriteLine("1 - Cadastrar Carro");
            Console.WriteLine("2 - Listar Carros");
            Console.WriteLine("3 - Editar Carros");
            Console.WriteLine("4 - Faturamento");
            Console.WriteLine("5 - Encerrar Programa");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.Write("Escolha: ");
            recebido = Console.ReadLine();
            Console.Clear();
            if (!Int32.TryParse(recebido, NumberStyles.None, CultureInfo.InvariantCulture, out escolha) ||
                escolha < 0 || escolha > 5)
            {
                Console.WriteLine("Por favor, insira um número válido, no intervalo de 1 e 5");
                Thread.Sleep(2000);
                Console.Clear();
            }
            else
            {
                switch (escolha)
                {
                    case 1:
                    {
                        Console.Write("Digite a placa do carro no padrão ABC-1234 ou ABC1D23: ");
                        e.adicionarNovoCarro(Console.ReadLine());
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                    }
                    case 2:
                    {
                        if (e.tamanhoListaCarros() == 0)
                        {
                            Console.WriteLine(
                                "Não existem carros cadastrados!!\nPressione qualquer botão para voltar ao menu principal.");
                            Console.ReadKey();
                            Thread.Sleep(1000);


                            Console.Clear();
                            break;
                        }

                        e.listarCarros();
                        Console.WriteLine("Aperte qualquer botão para voltar ao menu principal");
                        Console.ReadKey();
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                    }
                    case 3:
                    {
                        int escolha1;
                        string recebido1;

                        if (e.tamanhoListaCarros() > 0)
                        {
                            Console.Clear();
                            do
                            {
                                Console.WriteLine("Você deseja editar o que ?");
                                Console.WriteLine("1 - Placa");
                                Console.WriteLine("2 - Status");
                                Console.WriteLine("3 - Voltar ao menu principal");
                                Console.Write("Escolha: ");
                                recebido1 = Console.ReadLine();

                                if (!Int32.TryParse(recebido1, NumberStyles.None, CultureInfo.InvariantCulture,
                                        out escolha1) ||
                                    escolha1 < 0 || escolha1 > 3)
                                {
                                    Console.WriteLine("Por favor, insira um número válido, no intervalo de 1 e 3");
                                    Thread.Sleep(2000);
                                    Console.Clear();
                                }
                                else
                                {
                                    List<CarroDetalhe> carros = e.retornarListaCarros();
                                    switch (escolha1)
                                    {
                                        case 1:
                                        {
                                            Console.Clear();

                                            e.listarCarros();

                                            Console.Write("Escolha um carro pelo ID acima: ");
                                            int carroEscolhido = int.Parse(Console.ReadLine());
                                            
                                            CarroDetalhe carroSelecionado = carros[carroEscolhido - 1];

                                            Console.Write("Digite a nova Placa: ");
                                            carroSelecionado.PlacaCarro = Console.ReadLine();
                                            
                                            break;
                                        }
                                        case 2:
                                        {
                                            Console.Clear();

                                            e.listarCarros();

                                            string recebido2;
                                            int escolha2;
                                            
                                            Console.Write("Escolha um carro pelo ID acima: ");
                                            int carroEscolhido = int.Parse(Console.ReadLine());
                                            
                                            CarroDetalhe carroSelecionado = carros[carroEscolhido - 1];
                                            
                                            Console.WriteLine("Defina o Status do carro abaixo");
                                            Console.WriteLine("1 - BAIXADO");
                                            Console.WriteLine("2 - NO_ESTACIONAMENTO");
                                            Console.Write("Escolha: ");
                                            recebido2 = Console.ReadLine();

                                            if (!Int32.TryParse(recebido2, NumberStyles.None, CultureInfo.InvariantCulture,
                                                    out escolha2) ||
                                                escolha2 < 0 || escolha2 > 2)
                                            {
                                                Console.WriteLine("Por favor, insira um número válido, no intervalo de 1 e 2");
                                                Thread.Sleep(2000);
                                                Console.Clear();
                                            }

                                            switch (escolha2)  
                                            {
                                                case 1:
                                                {
                                                    
                                                    carroSelecionado.status = Status.BAIXADO;
                                                    carroSelecionado.horarioSaida = DateTime.Now;
                                                    carroSelecionado.horasTotais = carroSelecionado.horarioSaida -
                                                        carroSelecionado.horarioEntrada;
                                                    Console.Clear();
                                                    break;
                                                }
                                                case 2:
                                                {
                                                    carroSelecionado.status = Status.NO_ESTACIONAMENTO;
                                                    Console.Clear();
                                                    break;
                                                }
                                            }
                                            break;
                                        }
                                    }
                                    break;
                                }
                            } while (escolha1 != 3);

                            Console.Clear();
                            break;
                        }
                        else
                        {
                            Console.WriteLine(
                                "Não existem carros cadastrados!!\nPressione qualquer botão para voltar ao menu principal.");
                            Console.ReadKey();
                            Thread.Sleep(1000);
                            Console.Clear();
                            break;
                        }
                    }
                    case 4:
                    {
                        Console.WriteLine($"Valor total apurado até agora: {e.apurarFaturamento():C}");
                        Console.WriteLine("Aperte qualquer botão para voltar ao menu principal");
                        Console.ReadKey();
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                    }
                    case 5:
                    {
                        Console.WriteLine("Encerrando o programa...");
                        Thread.Sleep(1000);
                        break;
                    }
                }
            }
        } while (escolha != 5);
    }

    static decimal ObterValor(string mensagem)
    {
        decimal valor;
        bool entradaValida;

        do
        {
            Console.Write(mensagem);
            string input = Console.ReadLine();

            entradaValida = decimal.TryParse(input, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture,
                out valor);

            if (!entradaValida)
            {
                Console.WriteLine("Por favor, insira um número válido.");
            }
        } while (!entradaValida);

        return valor;
    }
}