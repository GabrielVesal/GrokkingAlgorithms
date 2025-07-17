public static class SelectionSort
{
    public static void Execute()
    {
        // Temos aqui uma lista de números bagunçada. Precisamos organizá-los!
        var numbers = new int[] { 4, 5, 1, 3, 10, 9, 6, 8, 7, 2 };

        // Aplicando o algoritmo de ordenação por seleção
        var sortedArr = SelectionSortBasic(numbers);

        // Exibindo os números ordenados
        Console.WriteLine("Array ordenado com Selection Sort clássico:");
        Console.WriteLine(string.Join(", ", sortedArr));

        // Agora vamos usar uma versão alternativa com List<int>
        var arr = new List<int> { 5, 3, 6, 2, 10 };
        Console.WriteLine("\nArray ordenado com remoção de menores sucessivos:");
        Console.WriteLine(string.Join(", ", SelectionSortByRemovingMin(arr)));

        // Chamada da versão com LinkedList e LINQ
        var linkedListInput = new int[] { 9, 1, 4, 7, 6, 3 };
        var sortedWithLinkedList = SelectionSortWithLinkedList(linkedListInput);
        Console.WriteLine("\nArray ordenado com LinkedList + LINQ (menores + maiores intercalados):");
        Console.WriteLine(string.Join(", ", sortedWithLinkedList));

        // Algoritmo clássico de ordenação por seleção (versão para array).
        // A cada rodada, encontra o menor elemento do restante e troca com o da posição atual.
        static int[] SelectionSortBasic(int[] unorderedArray)
        {
            // Percorre cada elemento do array
            for (var i = 0; i < unorderedArray.Length; i++)
            {
                // Assume que o menor está na posição atual
                var smallestIndex = i;

                // Verifica o restante da lista para encontrar o menor elemento
                for (var j = i + 1; j < unorderedArray.Length; j++)
                {
                    if (unorderedArray[j] < unorderedArray[smallestIndex])
                    {
                        smallestIndex = j;
                    }
                }

                // Troca o atual com o menor encontrado
                (unorderedArray[i], unorderedArray[smallestIndex]) = (unorderedArray[smallestIndex], unorderedArray[i]);
            }

            return unorderedArray;
        }

        // Versão que constrói um novo array, retirando sempre o menor elemento da lista original.
        // Menos eficiente, mas mais intuitiva para entender o conceito.
        static int[] SelectionSortByRemovingMin(List<int> arr)
        {
            var newArr = new int[arr.Count];

            for (int i = 0; i < newArr.Length; i++)
            {
                // Encontra o índice do menor número na lista
                var smallest = FindSmallest(arr);

                // Adiciona esse menor número no novo array ordenado
                newArr[i] = arr[smallest];

                // Remove o menor número da lista original
                arr.RemoveAt(smallest);
            }

            return newArr;
        }

        // Função auxiliar que encontra o índice do menor número na lista.
        static int FindSmallest(List<int> arr)
        {
            var smallest = arr[0];
            var smallestIndex = 0;

            for (int i = 1; i < arr.Count; i++)
            {
                if (arr[i] < smallest)
                {
                    smallest = arr[i];
                    smallestIndex = i;
                }
            }

            return smallestIndex;
        }

        // Versão alternativa usando LinkedList e LINQ para ordenação "diferentona".
        // Aqui ele junta os menores no início e os maiores no final, alternando.
        static int[] SelectionSortWithLinkedList(int[] array)
           => SortLinkedList(new LinkedList<int>(array)).ToArray();

        static IEnumerable<int> SortLinkedList(LinkedList<int> list)
        {
            var minList = new LinkedList<int>();
            var maxList = new LinkedList<int>();

            while (list.Count != 0)
            {
                // Pega o menor valor da lista atual
                var min = list.Min();
                list.Remove(min);
                minList.AddLast(min);

                // Se ainda houver elementos, pega o maior também
                if (list.Count > 0)
                {
                    var max = list.Max();
                    list.Remove(max);
                    maxList.AddFirst(max);
                }
            }

            // Junta os dois: os menores do início e os maiores do fim
            return minList.Union(maxList);
        }
    }
}
