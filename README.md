# ToBrasil
Desafio de Desenvolvedor .NET da TO Brasil.

# Cadastro de Usuários

Crie uma aplicação que exponha uma API RESTful de criação de usuários e login.

Todos os endpoints devem aceitar e responder somente JSON, inclusive ao responder mensagens de erro.

Todas as mensagens de erro devem ter o formato:

```json
    {"mensagem": "mensagem de erro"}
```

## Cadastro

* Esse endpoint deverá receber um usuário com os campos "nome", "email", "senha", mais uma lista de objetos "telefone", seguindo o formato abaixo:

```json
    {
        "name": "João da Silva",
        "email": "joao@silva.org",
        "password": "hunter2",
        "phones": [
            {
                "number": "987654321",
                "ddd": "21"
            }
        ]
    }
```

* Responder o código de status HTTP apropriado
* Em caso de sucesso, retorne o usuário, mais os campos:
    * `id`: id do usuário (pode ser o próprio gerado pelo banco, porém seria interessante se fosse um GUID)
    * `created`: data da criação do usuário
    * `modified`: data da última atualização do usuário
    * `last_login`: data do último login (no caso da criação, será a mesma que a criação)
    * `token`: token de acesso da API (pode ser um GUID ou um JWT)

* Caso o e-mail já exista, deverá retornar erro com a mensagem "E-mail já existente".
* O token deverá ser persistido junto com o usuário

## Login

* Este endpoint irá receber um objeto com e-mail e senha.
* Caso o e-mail e a senha correspondam a um usuário existente, retornar igual ao endpoint de Criação.
* Caso o e-mail não exista, retornar erro com status apropriado mais a mensagem "Usuário e/ou senha inválidos"
* Caso o e-mail exista mas a senha não bata, retornar o status apropriado 401 mais a mensagem "Usuário e/ou senha inválidos"

## Perfil do Usuário
* Caso o token não exista, retornar erro com status apropriado com a mensagem "Não autorizado".
* Caso o token exista, buscar o usuário pelo `id` passado no path e comparar se o token no modelo é igual ao token passado no header.
* Caso não seja o mesmo token, retornar erro com status apropriado e mensagem "Não autorizado"
* Caso seja o mesmo token, verificar se o último login foi a MENOS que 30 minutos atrás. Caso não seja a MENOS que 30 minutos atrás, retornar erro com status apropriado com mensagem "Sessão inválida".
* Caso tudo esteja ok, retornar o usuário no mesmo formato do retorno do Login.

## Requisitos
* .Net Core 3.1
* Banco de dados em memória, como o InMemory.
* Persistência com Entity e consultas com Dapper.
* Entregar um repositório público (github ou bitbucket) com o código fonte.
* Organizar o projeto em camadas

## Requisitos desejáveis
* JWT como token
* Testes unitários
* Usar o ASP .NET Identity
* Criptogafia não reversível (hash) na senha e no token
* Criar um Dockerfile para executarmos a aplicação via Docker
