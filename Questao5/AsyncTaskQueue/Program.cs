using System.Diagnostics;

class Program
{
    static async Task Main(string[] args)
    {
        // Definir quantidade de tarefas e limite de tarefas simultâneas
        int quantidadeDeTarefas = 10;
        int limiteTarefasSimultaneas = 3;

        // Criar lista de tarefas e um semáforo para limitar o número de tarefas simultâneas
        List<Task> tarefas = new List<Task>();
        using SemaphoreSlim semaforo = new SemaphoreSlim(limiteTarefasSimultaneas);

        // Medir o tempo total de execução
        Stopwatch stopwatch = Stopwatch.StartNew();

        // Adicionar cada tarefa à lista
        for (int i = 1; i <= quantidadeDeTarefas; i++)
        {
            int tarefaId = i;
            tarefas.Add(ProcessarTarefaAsync(tarefaId, semaforo));
        }

        // Esperar todas as tarefas terminarem
        await Task.WhenAll(tarefas);

        // Parar cronômetro e exibir o tempo total de execução
        stopwatch.Stop();
        Console.WriteLine($"Todas as tarefas foram concluídas em {stopwatch.Elapsed.TotalSeconds} segundos.");
    }

    static async Task ProcessarTarefaAsync(int tarefaId, SemaphoreSlim semaforo)
    {
        await semaforo.WaitAsync(); // Limitar o número de tarefas simultâneas
        try
        {
            // Simular falha aleatória para demonstrar tentativas
            Random aleatorio = new Random();
            if (aleatorio.Next(0, 10) < 2) // 20% de chance de falhar
            {
                throw new Exception($"Falha simulada na tarefa {tarefaId}");
            }

            // Simular processamento da tarefa (sem atraso aleatório)
            Console.WriteLine($"Tarefa {tarefaId} começou a ser processada.");
            await Task.Delay(3000); // Simular um tempo fixo de 3 segundos para processamento

            // Imprimir o ID da tarefa e o tempo fixo de execução
            Console.WriteLine($"Tarefa {tarefaId} concluída após 3 segundos.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro na tarefa {tarefaId}: {ex.Message}. Tentando novamente...");
            await ProcessarTarefaAsync(tarefaId, semaforo); // Retry
        }
        finally
        {
            semaforo.Release(); // Liberar o semáforo
        }
    }
}