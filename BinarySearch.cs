// Bem-vindo ao Festival do Caos, onde 100 pessoas estão curtindo uma festa épica!
// Nosso herói, o detetive Max, precisa encontrar o suspeito número 54, que roubou o Mapa do Festival.
// Mas a multidão está uma bagunça, com todos misturados aleatoriamente!
var random = new Random();
var nums = Enumerable.Range(1, 100).OrderBy(n => random.Next()).ToArray();

// O suspeito número 54 é o alvo, e Max tem pouco tempo antes que ele fuja!
var n = 54;

// Max começa com a abordagem clássica de detetive novato: checar cada pessoa uma a uma.
// É como perguntar "Você é o 54?" para cada um na multidão. Cansativo, né?
var simpleSearch = SimpleSearch(nums, n);

// Então, aparece Luna, a hacker genial, com um plano esperto: a busca binária!
// "Max, organize a multidão por número e divida o trabalho ao meio a cada passo!"
var binarySearch = BinarySearch(nums.ToArray(), n); // Clona o array para não bagunçar


// Busca Simples: O método do detetive novato
static (int value, int attemps) SimpleSearch(int[] nums, int n)
{
    // Max, com seu caderninho, vai de pessoa em pessoa no festival.
    // Ele pergunta: "Qual é o seu número?" para cada um, começando do primeiro.
    // No pior caso, ele vai ter que falar com TODAS as 100 pessoas. Que trabalheira!
    int attemps = 0;

    for (int i = 0; i < nums.Length; i++)
    {
        attemps++; // Cada pergunta é uma tentativa
        if (nums[i] == n)
        {
            // Max aponta a lanterna: "AHA! Você é o 54, ladrão do Mapa do Festival!"
            return (nums[i], attemps);
        }
        // Se não encontrar o suspeito, Max volta de mãos vazias, exausto.
        // Ele tentou até 100 vezes no pior caso (complexidade O(n)).
    }
    return (0, attemps);
}

// Busca Binária: O plano genial da hacker Luna
static (int value, int attemps) BinarySearch(int[] nums, int n)
{
    // Luna diz: "Max, primeiro organize a multidão por número de forma ordenada, como se fosse uma fila crescente!"
    // Isso é crucial para a busca binária funcionar, tipo um truque de mágica.
    Array.Sort(nums);

    // Max define os limites: o começo e o fim da multidão.
    int start = 0;
    int end = nums.Length - 1;
    int attemps = 0;

    // Enquanto houver pessoas para checar, Max segue o plano de Luna.
    while (start <= end)
    {
        attemps++; // Cada checagem é uma tentativa

        // Luna sussurra pelo comunicador: "Vai no meio da multidão!"
        // O meio é calculado com cuidado para não dar problema.
        int mid = start + (end - start) / 2;
        int suspect = nums[mid]; // Max checa a pessoa no meio

        // Max pergunta: "Você é o número 54?"
        if (suspect == n)
        {
            // "PEGUEI VOCÊ!" Max algema o suspeito 54, salvando o festival!
            return (suspect, attemps);
        }
        // Se o número da pessoa for maior que 54, Luna diz:
        // "O suspeito tá na metade de baixo, esquece a parte de cima!"
        else if (suspect > n)
        {
            end = mid - 1; // Ajusta o limite superior
        }
        // Se for menor, Luna orienta:
        // "O 54 tá na metade de cima, ignora a parte de baixo!"
        else
        {
            start = mid + 1; // Ajusta o limite inferior
        }
    }
    // Se não encontrar, Max fica confuso: "Cadê o 54?"
    // Mas Luna explica: "Relaxa, com 100 pessoas, você só precisou de ~7 checagens (log₂(100) ≈ 6,64)."
    // Isso é a mágica da complexidade O(log n), muito mais rápida que O(n)!
    return (0, attemps);
}


// Hora de ver como Max se saiu!
Console.WriteLine(" Resultados da Busca Simples (Estilo Detetive Novato):");
Console.WriteLine($"Suspeito encontrado: {(simpleSearch.value == 0 ? "Ninguém!" : simpleSearch.value)}");
Console.WriteLine($"Tentativas: {simpleSearch.attemps} (O(n) - pode levar até 100 checagens, que preguiça!)");

Console.WriteLine("\n Resultados da Busca Binária (Plano Genial da Luna):");
Console.WriteLine($"Suspeito encontrado: {(binarySearch.value == 0 ? "Ninguém!" : binarySearch.value)}");
Console.WriteLine($"Tentativas: {binarySearch.attemps} (O(log n) - no máximo ~7 checagens, puro estilo!)");


// *** O QUE É BUSCA BINÁRIA E O QUE É ESSE TAL DE "LOG"? ***
// (Se você nunca ouviu falar de logaritmo, não se assuste! Vamos tornar isso simples!)
//
// O que é Busca Binária?
// Imagine que você está procurando um nome em uma lista telefônica (lembra delas?).
// A busca linear é como ler cada nome, um por um, da primeira à última página. Pode levar muito tempo!
// A busca binária é mais esperta: como a lista está em ordem alfabética, você abre no meio.
// Se o nome que você quer vem antes, você ignora a segunda metade; se vem depois, ignora a primeira.
// A cada passo, você corta o problema pela metade, como Max fez com a multidão.
// Isso faz a busca binária MUITO mais rápida, mas só funciona se a lista (ou multidão) estiver ordenada.
//
// O que é O(n) e O(log n)?
// - O(n) (busca linear): Max checa cada pessoa, uma por uma. Para 100 pessoas, pode levar até 100 checagens.
//   Se fossem 1 milhão de pessoas, ele precisaria de até 1 milhão de checagens. É trabalhoso!
// - O(log n) (busca binária): Max, com a ajuda de Luna, divide a multidão ao meio a cada checagem.
//   Para 100 pessoas, ele precisa de no máximo ~7 checagens. Para 1 milhão, só ~20!
//
// O que é esse "log" (logaritmo)?
// Logaritmo (neste caso, log na base 2) é uma forma de contar quantas vezes você pode dividir algo ao meio
// até chegar a quase nada. Pense assim: se você tem 100 pessoas e divide ao meio repetidamente (100 → 50 → 25 → 13 → 7 → 4 → 2 → 1),
// você precisa de cerca de 7 divisões. Esse número de divisões é o "log₂(100)".
// É como perguntar: "Quantas vezes posso cortar meu problema pela metade até ele ficar bem pequeno?"
// Para 100 pessoas, são ~7 cortes. Para 1 milhão, são ~20. Por isso a busca binária é tão rápida!
//
// Observação para quem não sabe o que é logaritmo:
// Não precisa entender a matemática chata de logaritmos. Só lembre que "log n" significa que o número de passos
// cresce muito devagar, mesmo que a lista seja enorme. É como se Max tivesse um superpoder para eliminar
// metade da multidão a cada pergunta, enquanto o método novato (busca linear) faz ele correr atrás de todo mundo!




