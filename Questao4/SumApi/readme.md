
Voc� pode testar a API executando o projeto e fazendo uma requisi��o GET, por exemplo:

http://localhost:5004/sum?a=5&b=10

{
    "result": 15
}


--


Se passar um par�metro inv�lido:

GET http://localhost:5000/sum?a=abc&b=10

{
    "error": "O par�metro 'a' n�o � um n�mero v�lido: abc"
}

