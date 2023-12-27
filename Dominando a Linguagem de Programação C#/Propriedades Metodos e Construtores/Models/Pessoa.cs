namespace Propriedades_Metodos_e_Construtores.Models;

public class Pessoa
{
    private string _nome;
    private int _idade;
    
    public void Apresentar()
    {
        Console.WriteLine($"Nome: {_nome}\nIdade: {_idade}");
    }

    public void DefinirNome(string nome)
    {
        if (nome == "")
        {
            throw new ArgumentException("O nome não pode ser vazio!!");
        }
        
        _nome = nome;
    }

    public void DefinirIdade(int idade)
    {
        _idade = idade;
    }
}