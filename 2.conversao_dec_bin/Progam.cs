using System;

int[] arr = new int[] {235,45,12,78,30, 180, 15}; 
string[] arraux = new string[arr.Length];

arrNum(arr);

foreach (var x in arraux)
{
    Console.Write($"{x} ");
}

void arrNum(int[] arr)
{
    string bin = "";
    int i = 0, elemento, aux;
    int tam = arr.Length;

    for (i = 0; i < tam; i++)
    {
        elemento = arr[i];
        bin = string.Empty;
    
        while (elemento > 0)
        {
            aux = elemento % 2;
            elemento /= 2;
            bin = aux.ToString() + bin;
        }
        bin = bin.PadLeft(8,'0');

        string conv = bin.Substring(0, 4);
        arraux[i] = conv;
    }
}
