namespace PersoTrescon.Models;

public class Person
{

    public Person(String name)
    {
        Name = name;
        Id = Guid.NewGuid();
    }
    public Guid Id { get; init; }
    public string Name { get; private set; } //= //string.Empty;
    public string Sobrenome { get; set; }

}