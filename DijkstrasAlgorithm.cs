public static class DijkstrasAlgorithm
{
    private const double _infinity = double.PositiveInfinity; // Representa um custo infinito (ou ainda não alcançável)
    private static Dictionary<string, Dictionary<string, double>> _graph = new Dictionary<string, Dictionary<string, double>>(); // Grafo com nós e custos
    private static List<string> _processed = new List<string>(); // Lista de nós já processados

    public static void Execute()
    {
        // -----------------------------
        // Algoritmo de Dijkstra:
        // Usado para encontrar o caminho mais curto de um ponto inicial até todos os outros pontos de um grafo com pesos positivos.
        // -----------------------------
        // Passos principais:
        // 1 - Atribuir um custo inicial para cada nó (0 para o inicial e infinito para os outros).
        // 2 - Visitar o nó com menor custo ainda não processado.
        // 3 - Atualizar os custos dos vizinhos.
        // 4 - Marcar o nó como processado.
        // 5 - Repetir até processar todos os nós.

        // Criando o grafo (representado como dicionário de dicionários)

        //(start) --6--> (a) --1--> (fin)
        //   |                       ^
        //   2                       |
        //   v                       |
        //  (b) --3--> (a) --?--> ...|
        //   \                      
        //    \--5------------------> (fin)

        _graph.Add("start", new Dictionary<string, double>());
        _graph["start"].Add("a", 6.0); // Caminho de start → a custa 6
        _graph["start"].Add("b", 2.0); // Caminho de start → b custa 2

        _graph.Add("a", new Dictionary<string, double>());
        _graph["a"].Add("fin", 1.0); // Caminho de a → fin custa 1

        _graph.Add("b", new Dictionary<string, double>());
        _graph["b"].Add("a", 3.0);   // Caminho de b → a custa 3
        _graph["b"].Add("fin", 5.0); // Caminho de b → fin custa 5

        _graph.Add("fin", new Dictionary<string, double>()); // Nó final não leva a lugar nenhum

        // Dicionário com custos iniciais para cada nó
        var costs = new Dictionary<string, double>();
        costs.Add("a", 6.0);
        costs.Add("b", 2.0);
        costs.Add("fin", _infinity); // Ainda não sabemos o custo até fin

        // Dicionário com os "pais" (nós anteriores no caminho mais curto)
        var parents = new Dictionary<string, string>();
        parents.Add("a", "start");
        parents.Add("b", "start");
        parents.Add("fin", null);

        // Encontrar o nó de menor custo ainda não processado
        var node = FindLowestCostNode(costs);
        while (node != null) // Enquanto houver nós para processar
        {
            var cost = costs[node]; // Custo atual para chegar a este nó
            var neighbors = _graph[node]; // Vizinhos do nó

            // Para cada vizinho, calcula se existe um caminho mais curto passando por 'node'
            foreach (var n in neighbors.Keys)
            {
                var new_cost = cost + neighbors[n];
                if (costs[n] > new_cost)
                {
                    costs[n] = new_cost;   // Atualiza o custo se for menor
                    parents[n] = node;     // Atualiza o pai
                }
            }

            // Marca o nó como processado
            _processed.Add(node);

            // Procura o próximo nó de menor custo
            node = FindLowestCostNode(costs);
        }

        // Exibe os menores custos para cada nó
        Console.WriteLine("Custos mínimos para cada nó:");
        foreach (var kv in costs)
        {
            Console.WriteLine($"{kv.Key}: {kv.Value}");
        }
    }

    // Função que encontra o nó com o menor custo que ainda não foi processado
    private static string FindLowestCostNode(Dictionary<string, double> costs)
    {
        var lowestCost = double.PositiveInfinity;
        string lowestCostNode = null;

        foreach (var node in costs)
        {
            var cost = node.Value;
            if (cost < lowestCost && !_processed.Contains(node.Key))
            {
                lowestCost = cost;
                lowestCostNode = node.Key;
            }
        }
        return lowestCostNode;
    }
}
