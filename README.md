# Projeto Blog

## Oque é o Projeto
Backend de um Blog contendo o Mapping pela Fluent API do Ef Core, Utilizando SqlServer, Contém também um projeto de Testes utilizando XUnit.

***
## Pré-requistos para Rodar o Projeto
**<p>.NET RUN TIME - 6.0</p>**
**<p>SQL SERVER</p>**
***
## Como baixar e rodar o projeto
1. Baixe ou Execute um `git clone` do projeto.
2. Vá até a pasta do projeto via CLI(Terminal)
3. Execute um `dotnet restore`
4. Execute um `dotnet build`
5. Execute um `dotnet ef update` para subir a migration e criar o database e as tabelas.

**OBS:Você não precisa ter o DATABASE já CRIADO ou mesmo as TABELAS, a MIGRATION já fará isso para você, MESMO QUE O DATABASE não exista, é necessário apenas que você tenha uma CONNECTION STRING para o seu SERVIDOR SQLSERVER, e nessa string de conexão você colocará o nome do DATABASE que será CRIADO(você pode escolher), também coloquei um SCRIPT EM C# que populará as TABELAS para você, mas só funciona uma vez após a execução, se quiser novos dados, adiciona manualmente.**

6. Execute um `dotnet run`
7. Divirta-se, você poderá consultar os dados/registro das tabelas VIA CLI, pelo ALGORITMO criado por mim, ou utilizando o seu SGBD. 
***
## Oque são Tabelas Virtuais e porque usei elas ao invés de criar um arquivo(model)
São tabelas VIRTUAIS(Que existirão somente em memória), utilizamos o TIPO DICTIONARY<string,Object> para simular uma COLUNA de uma TABELA no BANCO, que é composto por CHAVE(Nome da Coluna), e o Valor(Valor da coluna).

Utilizamos esse tipo de MAPEAMENTO VIRTUAL para EVITAR criar ARQUIVOS(MODEL e MODELMAP) e isso faz com que o projeto tenha menos arquivos e fique mais organizado, possibilitando uma fácil evolução e escalamento do projeto se necessário.


