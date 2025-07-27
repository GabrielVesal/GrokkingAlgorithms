using System;
using System.Collections.Generic;
using System.Linq;

public static class Quicksort
{
    public static void Execute()
    {
        Console.WriteLine("=== Soma Iterativa ===");
        Console.WriteLine("Calculando soma com laço de repetição:");
        Console.WriteLine(SumIterative(new[] { 1, 2, 3, 4 })); // Saída: 10

        Console.WriteLine("\n=== Soma Recursiva ===");
        Console.WriteLine("Calculando soma quebrando a lista em pedaços:");
        Console.WriteLine(SumRecursive(new[] { 1, 2, 3, 4 })); // Saída: 10

        Console.WriteLine("\n=== Contar elementos (recursivo) ===");
        Console.WriteLine("Contando elementos de forma recursiva:");
        Console.WriteLine(Count(new[] { 1, 2, 3, 4 })); // Saída: 4

        Console.WriteLine("\n=== Encontrar o maior número (recursivo) ===");
        Console.WriteLine("Comparando o primeiro com o maior do restante:");
        Console.WriteLine(Max(new[] { 1, 3, 2, 5, 9, 8 })); // Saída: 9

        Console.WriteLine("\n=== Quicksort recursivo ===");
        var arr = new[] { 10, 5, 2, 3 };
        Console.WriteLine("Ordenando com Quicksort:");
        Console.WriteLine(string.Join(", ", QuickSort(arr))); // Saída: 2, 3, 5, 10

        Console.WriteLine("\n=== Máximo Divisor Comum (GCD) entre dois números ===");
        Console.WriteLine("Usando o algoritmo de Euclides:");
        Console.WriteLine(GetGCD(640, 1680)); // Saída: 80

        Console.WriteLine("\n=== Máximo Divisor Comum (GCD) de uma lista ===");
        Console.WriteLine("Aplicando GCD em todos os elementos:");
        var lst = new List<int> { 32, 696, 40, 50 };
        Console.WriteLine(GetGCDList(lst)); // Saída: 2
    }

    // Exemplo 1: Soma usando laço (iterativa)
    // Totaliza os valores da lista somando um por um com foreach
    private static int SumIterative(IEnumerable<int> arr)
    {
        var total = 0;
        foreach (var x in arr)
        {
            total += x;
        }
        return total;
    }

    // Exemplo 2: Soma recursiva
    // Pega o primeiro valor da lista e soma com o restante.
    // Caso base: quando a lista estiver vazia, retorna 0.
    private static int SumRecursive(IEnumerable<int> list)
    {
        if (!list.Any()) return 0; // Caso base

        // Chamada recursiva: soma o primeiro com o resto da lista
        return list.First() + SumRecursive(list.Skip(1));
    }

    // Exemplo 3: Contar elementos de forma recursiva
    // Caso base: se a lista estiver vazia, retorna 0.
    // Caso recursivo: conta 1 + o número de elementos restantes
    private static int Count(IEnumerable<int> list)
    {
        if (!list.Any()) return 0;

        return 1 + Count(list.Skip(1));
    }

    // Exemplo 4: Encontrar o maior valor de forma recursiva
    // Caso base: lista com 1 ou 2 elementos — compara diretamente.
    // Caso recursivo: compara o primeiro com o maior do restante.
    private static int Max(IEnumerable<int> list)
    {
        if (!list.Any()) throw new ArgumentException(nameof(list));

        if (list.Count() == 1) return list.First();

        if (list.Count() == 2)
        {
            var a = list.First();
            var b = list.Skip(1).First();
            return a > b ? a : b;
        }

        // Divide a lista e compara o primeiro com o máximo do resto
        var subMax = Max(list.Skip(1));
        return list.First() > subMax ? list.First() : subMax;
    }

    // Exemplo 5: Quicksort recursivo
    // Algoritmo de ordenação eficiente baseado em "dividir e conquistar".
    // 1. Escolhe um pivô (primeiro elemento)
    // 2. Separa em duas listas: menores e maiores que o pivô
    // 3. Chama Quicksort em cada uma dessas listas e junta tudo
    private static IEnumerable<int> QuickSort(IEnumerable<int> list)
    {
        if (list.Count() <= 1) return list; // Caso base: lista já ordenada

        var pivot = list.First(); // Primeiro elemento como pivô

        // Lista com elementos menores ou iguais ao pivô
        var less = list.Skip(1).Where(i => i <= pivot);

        // Lista com elementos maiores que o pivô
        var greater = list.Skip(1).Where(i => i > pivot);

        // Combina: Quicksort(menores) + pivô + Quicksort(maiores)
        return QuickSort(less)
            .Union(new List<int> { pivot })
            .Union(QuickSort(greater));
    }

    // Exemplo 6: Máximo Divisor Comum (GCD) entre dois números
    // Usa o algoritmo de Euclides:
    // Se b == 0, retorna a; senão, calcula GCD(b, a % b)
    public static int GetGCD(int a, int b)
        => b == 0 ? a : GetGCD(b, a % b);

    // Exemplo 7: GCD de uma lista de números
    // Aplica GCD em cadeia: GCD(a, GCD(b, GCD(c, ...)))
    public static int GetGCDList(IEnumerable<int> lst)
    {
        var result = lst.FirstOrDefault();

        if (lst.Count() > 2)
        {
            // Aplica GCD recursivo com o restante
            result = GetGCD(result, GetGCDList(lst.Skip(1)));
        }
        else
        {
            // Quando restam dois, aplica direto
            result = GetGCD(result, lst.Skip(1).FirstOrDefault());
        }

        return result;
    }
}
