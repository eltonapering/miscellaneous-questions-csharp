# Padr�o de Projeto Singleton

## Conceito:
O **Singleton** � um padr�o de design que tem como objetivo garantir que uma classe tenha apenas **uma �nica inst�ncia** e fornece um ponto global de acesso a essa inst�ncia. 
Ou seja, toda vez que voc� precisa usar essa classe, ela sempre retornar� a mesma inst�ncia criada anteriormente, independentemente de onde ou quando for solicitada.

## Objetivo:
O objetivo principal do **Singleton** � **controlar o acesso** � inst�ncia �nica de uma classe, 
evitando a cria��o de v�rias inst�ncias desnecess�rias. 
Isso pode ser importante em cen�rios onde o gerenciamento de recursos � cr�tico, como conex�es de banco de dados, gerenciamento de logs ou controle de sess�es.

## Cen�rio de uso:
Um cen�rio cl�ssico para o uso de **Singleton** � em **sistemas de logging**. Imagine que voc� tem um sistema que registra logs de eventos e erros. 
Se voc� criar v�rias inst�ncias da classe respons�vel por gravar logs, pode acabar com inconsist�ncias nos arquivos de log ou at� problemas de concorr�ncia.
Ao usar o **Singleton**, voc� garante que apenas uma inst�ncia da classe de log existir� em toda a aplica��o, centralizando e sincronizando a grava��o dos logs.


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

Nesse exemplo, a classe Logger s� permite que uma �nica inst�ncia seja criada e controlada de maneira thread-safe, 
o que � especialmente �til em aplica��es que lidam com m�ltiplas threads.
