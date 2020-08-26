# .Net-Usando-DDD
Arquitetura para DDD

## Dependêcias
- Entity FrameWork
- Swagger
```Swashbuckle.AspNetCore```

## Tabelas

- Loja
- Pet
- Cliente

## Lista de Desenvolvimento

- Criar mapeamento das tabelas :heavy_check_mark:
- Estabelecer relacionamento entre Pet e Cliente :heavy_check_mark:
- Configurar Relacionamento :heavy_check_mark:
- Criar CRUD simples :heavy_check_mark:
- Criar Listagem Para trazer os dados com seus respectivos relacionamentos :heavy_check_mark:
- Implementar o swagger :heavy_check_mark:
- Implementar uma classe para tratar erros
- Implementar validação

## Configuração do Swagger
 - Instalar o pacote Swashbuckle.AspNetCore.
 - Adicionar a dependência do swagger na classe ```Startup```
 
 ```C#
 public void ConfigureServices(IServiceCollection services)
 {
   ...
   services.AddSwaggerGen();
 }
 
 public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
 {
    ...
    app.UseSwagger();
    app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Meu PetShop");
            });
 }
 ```
