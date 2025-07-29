// Menu principal para escolher qual algoritmo executar
Console.WriteLine("=== GROKKING ALGORITHMS ===");
Console.WriteLine("Escolha qual algoritmo você quer executar:");
Console.WriteLine("1. Binary Search (Busca Binária)");
Console.WriteLine("2. Selection Sort (Ordenação por Seleção)");
Console.WriteLine("3. Recursion (Funções que se chamam sozinhas!)");
Console.WriteLine("4. Quicksort (Ordenação rápida)");
Console.WriteLine("5. HashTables (Dictionary)");
Console.WriteLine("6. Sair");
Console.Write("\nDigite sua escolha (1-3): ");

var option = Console.ReadLine();

switch (option)
{
    case "1":
        BinarySearch.Execute();
        break;
    case "2":
        SelectionSort.Execute();
        break;
    case "3":
        Recursion.Execute();
        break;
    case "4":
        Quicksort.Execute();
        break;
    case "5":
        HashTables.Execute();
        break;
    case "6":
        Console.WriteLine("Até logo!");
        return;
    default:
        Console.WriteLine("Opção inválida!");
        break;
}

Console.WriteLine("\nPressione qualquer tecla para sair...");
Console.ReadKey(); 