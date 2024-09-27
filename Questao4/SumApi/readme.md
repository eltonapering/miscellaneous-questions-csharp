
### Você pode testar a API executando o projeto e fazendo uma requisição GET, por exemplo:

http://localhost:5004/sum?a=5&b=10

{
    "result": 15
}


## 


### Se passar um parâmetro inválido:

GET http://localhost:5000/sum?a=abc&b=10

{
    "error": "O parâmetro 'a' não é um número válido: abc"
}

