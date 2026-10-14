//Caso 01 Condicionales: if
/*Console.WriteLine("Caso 01 Condicionales: if");
int x = 8;

if (x % 2 == 0)
{
   Console.WriteLine($"x es par: {x}");
}
else
{
    Console.WriteLine($"x es impar: {x}");
}
*/
//caso 02 Condicionales: switch
/*
Console.WriteLine("Caso 02 Condicionales: switch");
int opcion = 2;

switch (opcion)
{
    case 1:
        Console.WriteLine("Opción 1 seleccionada");
        break;
    case 2:
        Console.WriteLine("Opción 2 seleccionada");
        break;
    case 3:
        Console.WriteLine("Opción 3 seleccionada");
        break;
    default:
        Console.WriteLine("Opción no válida");
        break;
}
*/
//Caso 03 Condicionales: for, while , do while,foreach
/*
Console.WriteLine("Caso 03 Condicionales: for");

for (int i = 0; i <=10; i++)
{
    if(i % 2 == 0)
    {
        Console.WriteLine(i);
    }
  
}
*/
//Caso 04 Condicionales: while
/*
Console.WriteLine("Caso 04 Condicionales: while");
int j = 1;
while (j <= 10)
{
    if (j % 2 == 0)
            Console.WriteLine(j);    
    j++;
}
*/
//caso 05 Condicionales: do foreach 
/*
Console.WriteLine("Caso 05 Condicionales: do foreach");
int[] numeros = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
foreach (int n in numeros)
{
    if (n % 2 == 0)
           Console.WriteLine(n);
}
*/
//Caso 06 Condicionales: metodos ya parametros ref
/*
Console.WriteLine("Caso 06 Condicionales: metodos ya parametros ref");

int numero = 5;                                             //Inicializmaos antes
Incrementar(ref numero);                                    // Pasamos por REf
Console.WriteLine($"El valor incrementado es: {numero}");   // Sale 6


static void Incrementar(ref int n)
{
    n++;
    
 }
*/

//Caso 10 algoritmos de busqueda lineal

Console.WriteLine("Caso 10 algoritmos de busqueda lineal");
Console.WriteLine("**************************************:");
int[] arreglo = { 5,3,8,4,2 };
int valorBuscado = 7;
bool encontrado = false;

for (int i = 0; i < arreglo.Length; i++)
{
    if (arreglo[i] == valorBuscado)
    {
        encontrado = true;
        break;
    }
}

if (encontrado)
{
    Console.WriteLine($"El valor {valorBuscado} fue encontrado en el arreglo.");
}
else
{
    Console.WriteLine($"El valor {valorBuscado} no fue encontrado en el arreglo.");
}

Console.WriteLine("**************************************:");





