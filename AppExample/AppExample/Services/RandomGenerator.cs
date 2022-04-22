using AppExample.Services.Interfaces;

namespace AppExample.Services;

public class RandomGenerator : IRandomGenerator
{
    private readonly Random _random;

    public RandomGenerator(Random random)
    {
        _random = random;
    }

    public int Generate() => _random.Next();
}