public static class Recursion
{
    public static void Execute()
    {
        //  Recursão é quando uma função chama a si mesma para resolver um problema menor.
        //  Sempre precisa de dois elementos:
        //  Caso base: quando a função deve parar.
        //  Caso recursivo: quando a função se chama novamente com uma entrada menor.

        // Exemplo 1: Contagem regressiva
        Countdown(5);

        // Exemplo 2: Saudação encadeada 
        Greet("adit");

        // Exemplo 3: Fatorial recursivo
        Console.WriteLine($"Fatorial de 5 é: {Fact(5)}");

        // Exemplo 1 - Contagem regressiva usando recursão.
        // A função imprime o número atual e chama a si mesma com (i - 1),
        // até que i seja menor ou igual a zero (caso base).
        static void Countdown(int i)
        {
            Console.WriteLine(i); // Exibe o número atual

            // Caso base: quando i for 0 ou menor, a função para
            if (i <= 0) return;

            // Caso recursivo: chama a si mesma com i - 1
            Countdown(i - 1);
        }

        // Exemplo 2 - Uma função chama outras em sequência para simular uma conversa.
        // Isso mostra como funções podem ser organizadas em cadeia sem usar loops.
        static void Greet(string name)
        {
            Console.WriteLine($"hello, {name}!");   // Saudação inicial
            Greet2(name);                           // Continua a conversa
            Console.WriteLine("getting ready to say bye...");
            Bye();                                  // Finaliza com uma despedida
        }

        // Parte da conversa: pergunta como a pessoa está
        static void Greet2(string name)
        {
            Console.WriteLine($"how are you, {name}?");
        }

        // Finaliza a conversa com uma despedida
        static void Bye()
        {
            Console.WriteLine("ok bye!");
        }

        // Exemplo 3 - Calcula o fatorial de um número de forma recursiva.
        // O fatorial de 5, por exemplo, é 5 * 4 * 3 * 2 * 1 = 120.
        // A função se chama até chegar no caso base (1).
        static int Fact(int x)
        {
            // Caso base: fatorial de 1 (ou menos) é 1
            if (x <= 1) return 1;

            // Caso recursivo: multiplica x pelo fatorial de x - 1
            return x * Fact(x - 1);
        }
    }
}

