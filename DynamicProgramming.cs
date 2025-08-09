public static class DynamicProgramming
{
    public static void Execute()
    {
        // -----------------------------
        // Programação Dinâmica (Dynamic Programming - DP):
        // Técnica usada para resolver problemas complexos dividindo-os em subproblemas menores,
        // resolvendo-os apenas uma vez e armazenando o resultado para reutilização.
        // -----------------------------
        // Dois exemplos aqui:
        // 1 - Longest Common Subsequence (LCS): Maior subsequência comum entre duas strings.
        // 2 - Levenshtein Distance: Quantidade mínima de operações para transformar uma string em outra.
        // -----------------------------

        // ===== EXEMPLO 1 - LCS =====
        var result = LongestCommonSubsequence("fish", "vistafh");
        Console.WriteLine($"LCS: '{result.Item1}' | Tamanho: {result.Item2}"); // Saída esperada: 'ish' | Tamanho: 3

        // ===== EXEMPLO 2 - Distância de Levenshtein =====
        var distance = LevenshteinDistance("kitten", "sitting");
        Console.WriteLine($"Distância de Levenshtein entre 'kitten' e 'sitting': {distance}"); // Saída: 3
    }

    // --------------------------------------------------------
    // 1 - Longest Common Subsequence (LCS)
    // --------------------------------------------------------
    // Problema:
    // Encontrar a maior subsequência de caracteres (não necessariamente contínuos)
    // que aparece em ambas as strings na mesma ordem.
    // Exemplo: "fish" e "vistafh" → "ish"
    // --------------------------------------------------------
    public static (string, int) LongestCommonSubsequence(string word1, string word2)
    {
        if (string.IsNullOrEmpty(word1) || string.IsNullOrEmpty(word2))
            return ("", 0);

        // Matriz de tamanho (len1+1) x (len2+1)
        // Cada célula [i, j] guarda o tamanho da LCS até word1[0..i-1] e word2[0..j-1]
        var matrix = new int[word1.Length + 1, word2.Length + 1];

        // Preenche a matriz
        for (int i = 1; i <= word1.Length; i++)
        {
            for (int j = 1; j <= word2.Length; j++)
            {
                if (word1[i - 1] == word2[j - 1])
                {
                    // Caracteres iguais → soma 1 ao valor da diagonal
                    matrix[i, j] = matrix[i - 1, j - 1] + 1;
                }
                else
                {
                    // Caracteres diferentes → pega o maior valor de cima ou da esquerda
                    matrix[i, j] = Math.Max(matrix[i, j - 1], matrix[i - 1, j]);
                }
            }
        }

        // Reconstrói a subsequência a partir da matriz
        var subSeq = Read(matrix, word1, word2);

        return (subSeq, subSeq.Length);
    }

    // Função para reconstruir a LCS percorrendo a matriz de baixo para cima
    private static string Read(int[,] matrix, string word1, string word2)
    {
        string subSeq = "";
        int x = word1.Length;
        int y = word2.Length;

        while (x > 0 && y > 0)
        {
            if (word1[x - 1] == word2[y - 1])
            {
                // Parte da LCS → adiciona o caractere e anda na diagonal
                subSeq += word1[x - 1];
                x--;
                y--;
            }
            else if (matrix[x - 1, y] > matrix[x, y - 1])
            {
                // Move para cima
                x--;
            }
            else
            {
                // Move para a esquerda
                y--;
            }
        }

        // Como percorremos de trás pra frente, invertendo no final
        var charArray = subSeq.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    // --------------------------------------------------------
    // 2 - Levenshtein Distance
    // --------------------------------------------------------
    // Problema:
    // Determinar o número mínimo de operações necessárias para transformar
    // uma string em outra, usando:
    // - Inserção
    // - Remoção
    // - Substituição
    // Exemplo: "kitten" → "sitting" = 3 operações (substituir 'k' por 's', substituir 'e' por 'i', inserir 'g')
    // --------------------------------------------------------
    public static int LevenshteinDistance(string source, string target)
    {
        // Cria a matriz de distâncias
        var matrix = CreateMatrix(source, target);

        // Preenche a matriz usando DP
        for (int i = 1; i <= source.Length; i++)
        {
            for (int j = 1; j <= target.Length; j++)
            {
                // Calcula o custo da substituição (0 se iguais, 1 se diferentes)
                int cost = (source[i - 1] != target[j - 1]) ? 1 : 0;

                matrix[i, j] = Math.Min(
                    matrix[i, j - 1] + 1, // Inserção
                    Math.Min(
                        matrix[i - 1, j] + 1, // Remoção
                        matrix[i - 1, j - 1] + cost // Substituição
                    )
                );
            }
        }

        // Resultado final está na última célula
        return matrix[source.Length, target.Length];
    }

    // Cria e inicializa a matriz de distâncias
    private static int[,] CreateMatrix(string source, string target)
    {
        var matrix = new int[source.Length + 1, target.Length + 1];

        // Inicializa primeira coluna (remoções)
        for (int i = 0; i <= source.Length; i++)
        {
            matrix[i, 0] = i;
        }

        // Inicializa primeira linha (inserções)
        for (int j = 0; j <= target.Length; j++)
        {
            matrix[0, j] = j;
        }

        return matrix;
    }
}
