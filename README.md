# CrudDotNetCore
 - Demo de um crud feito com Asp.Net Core 6 WebApi Rest, banco de dados em Postgres usando Entity Framework Core com CodeFirst e Migrations, DDD, Injeção de Dependência(AutoFac), Repository Pattern, FluentAssertions, Swagger, Docker, TDD com xUnit e FluentAssertions, etc. 
 - Na aplicação de api eu usei o AutoFac para injetar os serviços, e usei a propria injeção nativa do Asp Net Core para injetar o contexto do EF Core.
 - Na aplicação de teste unitário eu ja mostro a injeção do contexto Ef core usando agora o AutoFac.
 - Utilizei um Repository Patrern de forma bem versátil, com expressões Lambda e apenas um metodo de Salvar de forma inteligente, em vez de usar um Add e um Update.
 - Utilizei a metodologia de usar o FluentValidation com lançamentos de exceptions, e tratar as mensagens nos try catch no controller.
 - Deixei gerado no projeto os codigos para criação da estrutura da tabela no banco usando migration do EF Core.
 - Nos testes unitários, eu não cheguei a implementar todos os testes, apenas deixei alguns como exemplo usando xUnit e FluentAssertions.
 - Ja deixei configurado no projeto as configurações e script para poder rodar o projeto no Docker com Linux.
 - Apesar de que cada arquiteto define como as camadas interagem entre elas, eu fiz esse projeto usando o padrão mais utilizado do DDD. 
