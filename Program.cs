Console.WriteLine("=== GROKKING ALGORITHMS ===");
Console.WriteLine("Escolha qual algoritmo você quer executar:");
Console.WriteLine("1. Binary Search (Busca Binária)");
Console.WriteLine("2. Selection Sort (Ordenação por Seleção)");
Console.WriteLine("3. Recursion (Funções que se chamam sozinhas!)");
Console.WriteLine("4. Quicksort (Ordenação rápida)");
Console.WriteLine("5. HashTables (Dictionary)");
Console.WriteLine("6. BreadthFirstSearch (Busca em largura)");
Console.WriteLine("7. Sair");
Console.Write("\nDigite sua escolha (1-7): ");

var option = Console.ReadLine();

var actions = new Dictionary<string, Action>
{
    { "1", BinarySearch.Execute },
    { "2", SelectionSort.Execute },
    { "3", Recursion.Execute },
    { "4", Quicksort.Execute },
    { "5", HashTables.Execute },
    { "6", BreadthFirstSearch.Execute },
    { "7", () => Console.WriteLine("Até logo!") }
};

if (actions.TryGetValue(option, out var action))
{
    action();
}
else
{
    Console.WriteLine("Opção inválida!");
}

Console.WriteLine("\nPressione qualquer tecla para sair...");
Console.ReadKey();
