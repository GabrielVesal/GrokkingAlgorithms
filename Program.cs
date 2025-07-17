// Menu principal para escolher qual algoritmo executar
Console.WriteLine("=== GROKKING ALGORITHMS ===");
Console.WriteLine("Escolha qual algoritmo você quer executar:");
Console.WriteLine("1. Binary Search (Busca Binária)");
Console.WriteLine("2. Selection Sort (Ordenação por Seleção)");
Console.WriteLine("3. Sair");
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
        Console.WriteLine("Até logo!");
        return;
    default:
        Console.WriteLine("Opção inválida!");
        break;
}

Console.WriteLine("\nPressione qualquer tecla para sair...");
Console.ReadKey(); 