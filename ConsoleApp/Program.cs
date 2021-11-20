Console.WriteLine("Hello, World!");
/*1.написати код, що буде виводити у консоль число з протилежним знаком, наприклад для 
 * 5 результат будет -5, для -1 результат буде 1 */
int tInteger = -5;
Console.WriteLine(-tInteger);


/*2. написати код, що буде виводити у консоль число зі знаком мінус, наприклад для 5 результат будет -5, для -1 результат буде -1 */

if (tInteger > 0)
{ 
    Console.WriteLine(-tInteger);
} 
else Console.WriteLine(tInteger);

/*3. написати код, що буде виводити у консоль чи є число квадратом якогось цілого числа, наприклад 
25 -> true (5^2), 24-> false, 9-> true(3 ^ 2), 1-> true(1 ^ 2), 0-> true(0 ^ 2), -1-> false */

double variableDouble=11;

if Math.Equals(variableDouble, Math.Sqrt(variableDouble) * Math.Sqrt(variableDouble)));
{
    Console.WriteLine("true"); ;
}
Console.WriteLine("false"); ;