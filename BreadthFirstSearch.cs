public static class BreadthFirstSearch
{
    public static void Execute()
    {
        // Busca em largura (BFS) percorre um grafo em camadas.
        // Primeiro visita os vizinhos diretos, depois os vizinhos dos vizinhos, e assim por diante.

        // É útil para encontrar o caminho mais curto ou identificar o nó mais próximo que satisfaz uma condição.

        // Exemplo: Queremos encontrar a primeira pessoa que "vende mangas"
        // A regra é simples: o nome dela termina com a letra 'm'

        // Criando o grafo como um dicionário
        var graph = new Dictionary<string, string[]>
        {
            { "you", new[] { "alice", "bob", "claire" } },
            { "bob", new[] { "anuj", "peggy" } },
            { "alice", new[] { "peggy" } },
            { "claire", new[] { "thom", "jonny" } },
            { "anuj", Array.Empty<string>() },
            { "peggy", Array.Empty<string>() },
            { "thom", Array.Empty<string>() },
            { "jonny", Array.Empty<string>() }
        };

        // Iniciando a busca
        Search("you", graph);

        // Exemplo: grafo de conexões (amizades):
        //
        //           you
        //         /  |   \
        //     alice bob claire
        //       |     |      \
        //    peggy  anuj    thom, jonny

        // A ideia é começar em "you" e procurar alguém cuja string termine com 'm'

        // Função de busca em largura
        static bool Search(string name, Dictionary<string, string[]> graph)
        {
            // Inicializa a fila com os vizinhos da pessoa inicial
            var searchQueue = new Queue<string>(graph[name]);

            // Lista para guardar quem já foi verificado (evita repetir)
            var searched = new List<string>();

            while (searchQueue.Any())
            {
                // Pega a próxima pessoa da fila
                var person = searchQueue.Dequeue();

                // Só verifica se ainda não foi analisada
                if (!searched.Contains(person))
                {
                    // Verifica se é um vendedor de manga
                    if (PersonIsSeller(person))
                    {
                        Console.WriteLine($"{person} is a mango seller");
                        return true;
                    }
                    else
                    {
                        // Se não for, adiciona os amigos dela na fila
                        // Junta os atuais da fila com os novos vizinhos
                        searchQueue = new Queue<string>(searchQueue.Concat(graph[person]));

                        // Marca como verificado
                        searched.Add(person);
                    }
                }
            }

            // Se ninguém for vendedor de manga, retorna falso
            return false;
        }

        // Critério para ser considerado vendedor de manga: nome termina com 'm'
        static bool PersonIsSeller(string name)
        {
            return name.EndsWith("m");
        }

        /*
         * Saída esperada:
         * thom is a mango seller
         *
         * A busca visitará:
         * - alice
         * - bob
         * - claire
         * - peggy
         * - anuj
         * - thom (encontrado!)
         */
    }
}
