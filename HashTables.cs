public static class HashTables
{
    public static void Execute()
    {
        // Tabelas hash (em C# chamadas de Dictionary) são estruturas que associam "chaves" a "valores".
        // Elas permitem buscas rápidas, ideais quando você precisa encontrar algo rapidamente com base em uma chave.

        // Exemplo 1 - Criando uma "tabela de preços"
        var book = new Dictionary<string, decimal>();

        // Adicionando produtos com seus preços
        book.Add("apple", 0.67m);     // maçã custa R$ 0,67
        book.Add("milk", 1.49m);      // leite custa R$ 1,49
        book.Add("avocado", 1.49m);   // abacate também custa R$ 1,49

        // Exibindo os itens do dicionário
        Console.WriteLine("Lista de preços:");
        foreach (var item in book)
        {
            Console.WriteLine($"{item.Key}: R$ {item.Value}");
        }

        /*
         * Saída:
         * apple: R$ 0,67
         * milk: R$ 1,49
         * avocado: R$ 1,49
         */

        // Observação:
        // O dicionário (Dictionary) permite que você acesse rapidamente o valor de uma chave.
        // Ex: book["milk"] retornaria 1.49 — tempo de acesso super rápido (O(1)).

        // Exemplo 2 - Controlando votação com uma tabela hash
        // Queremos impedir que alguém vote mais de uma vez.

        // Criando dicionário para registrar quem já votou
        var voted = new Dictionary<string, bool>();

        // Simulando pessoas tentando votar
        Console.WriteLine("\nVerificando votos:");
        CheckVoter("tom", voted);   // tom nunca votou → pode votar
        CheckVoter("mike", voted);  // mike nunca votou → pode votar
        CheckVoter("mike", voted);  // mike já votou → expulsar

        // Função para verificar se a pessoa já votou
        static void CheckVoter(string name, Dictionary<string, bool> voted)
        {
            // Se a pessoa já estiver no dicionário, ela já votou
            if (voted.ContainsKey(name))
            {
                Console.WriteLine($" {name.ToUpper()} já votou. Expulsar!");
            }
            else
            {
                // Marca como "votou"
                voted.Add(name, true);
                Console.WriteLine($" {name.ToUpper()} pode votar!");
            }
        }

        /*
         * Saída:
         * TOM pode votar!
         * MIKE pode votar!
         * MIKE já votou. Expulsar!
         */
    }
}
