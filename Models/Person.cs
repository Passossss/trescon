namespace PersoTrescon.Models;

public class Person
{

    public Person(String name, string sobrenome) 
    {
        Name = name;
        Sobrenome = sobrenome;
        Id = Guid.NewGuid();
    }
    public Guid Id { get; init; }
    public string Name { get; private set; } //= //string.Empty;
    public string Sobrenome { get; set; }

    public void MudarNome(string nome, string sobrenome)
    {
        Name = nome;
        Sobrenome = sobrenome;
    }

    public void Status()
    {
        Name = "desativado";

    }
}