using AppExample.Services.Interfaces;

namespace AppExample.Services;

public class MathService : IMathService
{
    public long Multiply(int num1, int num2) => num1 * num2;
}