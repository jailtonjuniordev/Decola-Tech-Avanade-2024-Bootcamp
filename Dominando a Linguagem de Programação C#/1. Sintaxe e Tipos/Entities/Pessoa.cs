
public class Pessoa
{
    public sstring? nome { get; set; }
    public int? idade { get; set; }

    public Pessoa(string Nome, int Idade)
    {
        this.nome = Nome;
        this.idade = Idade;
    }

    public void Apresentar()
    {
        Console.WriteLine($"Olá! meu nome é {nome} e tenho {idade} anos");
        Console.WriteLine("Final!");

        Console.ReadLine();

    }

}