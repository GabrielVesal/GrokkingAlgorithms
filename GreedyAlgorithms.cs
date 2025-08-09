public static class GreedyAlgorithms
{
    public static void Execute()
    {
        // -----------------------------
        // Algoritmo Guloso para Cobertura de Conjuntos (Set Cover Problem):
        // O objetivo é selecionar o menor conjunto de "estações" que cubra todos os estados necessários.
        // -----------------------------

        // 1 - Definimos o conjunto de estados que queremos cobrir
        var statesNeeded = new HashSet<string> { "mt", "wa", "or", "id", "nv", "ut", "ca", "az" };

        // 2 - Definimos um dicionário com estações e os estados que cada uma cobre
        var stations = new Dictionary<string, HashSet<string>>();
        stations.Add("kone", new HashSet<string> { "id", "nv", "ut" });
        stations.Add("ktwo", new HashSet<string> { "wa", "id", "mt" });
        stations.Add("kthree", new HashSet<string> { "or", "nv", "ca" });
        stations.Add("kfour", new HashSet<string> { "nv", "ut" });
        stations.Add("kfive", new HashSet<string> { "ca", "az" });

        // 3 - Lista final para armazenar as estações escolhidas
        var finalStations = new HashSet<string>();

        // 4 - Enquanto ainda houver estados não cobertos...
        while (statesNeeded.Any())
        {
            string bestStation = null; // Melhor estação da rodada atual
            var statesCovered = new HashSet<string>(); // Estados cobertos por essa estação

            // 5 - Para cada estação, verificamos quantos estados ainda não cobertos ela pode cobrir
            foreach (var station in stations)
            {
                // Interseção entre estados que precisamos e estados que essa estação cobre
                var covered = new HashSet<string>(statesNeeded.Intersect(station.Value));

                // Se essa estação cobre mais estados do que a melhor até agora, atualizamos
                if (covered.Count > statesCovered.Count)
                {
                    bestStation = station.Key;
                    statesCovered = covered;
                }
            }

            // 6 - Removemos os estados cobertos por essa melhor estação da lista de estados necessários
            statesNeeded.RemoveWhere(s => statesCovered.Contains(s));

            // 7 - Adicionamos essa estação à solução final
            finalStations.Add(bestStation);
        }

        // 8 - Exibimos as estações escolhidas que cobrem todos os estados
        Console.WriteLine(string.Join(", ", finalStations));
    }
}
