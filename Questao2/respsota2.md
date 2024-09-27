# Padrão de Projeto Singleton

## Conceito:
O **Singleton** é um padrão de design que tem como objetivo garantir que uma classe tenha apenas **uma única instância** e fornece um ponto global de acesso a essa instância. 
Ou seja, toda vez que você precisa usar essa classe, ela sempre retornará a mesma instância criada anteriormente, independentemente de onde ou quando for solicitada.

## Objetivo:
O objetivo principal do **Singleton** é **controlar o acesso** à instância única de uma classe, 
evitando a criação de várias instâncias desnecessárias. 
Isso pode ser importante em cenários onde o gerenciamento de recursos é crítico, como conexões de banco de dados, gerenciamento de logs ou controle de sessões.

## Cenário de uso:
Um cenário clássico para o uso de **Singleton** é em **sistemas de logging**. Imagine que você tem um sistema que registra logs de eventos e erros. 
Se você criar várias instâncias da classe responsável por gravar logs, pode acabar com inconsistências nos arquivos de log ou até problemas de concorrência.
Ao usar o **Singleton**, você garante que apenas uma instância da classe de log existirá em toda a aplicação, centralizando e sincronizando a gravação dos logs.


Exemplo em C#:

public class Logger
{
    private static Logger _instance;
    private static readonly object _lock = new object();

    private Logger() { }

    public static Logger Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Logger();
                }
                return _instance;
            }
        }
    }

    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

Nesse exemplo, a classe Logger só permite que uma única instância seja criada e controlada de maneira thread-safe, 
o que é especialmente útil em aplicações que lidam com múltiplas threads.
