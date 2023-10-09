# InLock Code First

Projeto ensinando como fazer primeiro o codigo em C# para do codigo criar o banco de dados.

1. Para utilização dessa metodologia, é necessario instalar os pacotes :

    Microsoft.EntityFrameworkCore.SqlServer
    
    Microsoft.EntityFrameworkCore.SqlServer.Design
    
    Microsoft.EnityFrameworkCore.Tools

    Microsoft.AspNetCore.Mvc.NewtonsoftJson
   
3. Criar a pasta seguindo Design Pattern
   - Domains
   - Interfaces
   - Repositories
   - Controllers</br></br>
Exemplo: </br></br>
     ![image](https://github.com/AllanR1991/senai-inLockDataBaseFirst-webApi/assets/22855740/6e08f651-f12d-4e6e-a40e-863480755e77)

4. Criar as Domains utilizando de DataAnnotations ex:</br></br>
   ![image](https://github.com/AllanR1991/senai-inLockCodeFirst-webApi/assets/22855740/498981d5-3d84-44bd-93f1-2213a5f4f93c)

5. Após criar as Domains, criar uma pasta Contexts e criar uma classe com nomeDoProjetoContext.cs e nela criar a classe Context que sera utilizada para fazermos a migration e depois criar o bando de dados.

6. Finalizado a Context hora de iniciarmos a migration.
   - Acessar no Visual Studio > Ferramentas > Gerenciador de Pacotes do Nuget > Console do Gerenciador de Pacotes</br></br>
    ![image](https://github.com/AllanR1991/senai-inLockDataBaseFirst-webApi/assets/22855740/b42f9736-d416-44d1-805c-df52ac2d9704)
</br></br>

7. Digitar no console:
   - ```c#
      Add-Migration //Para criar a migração.
     ```
   - ```c#
      Update-Database //Para criar de fato o banco de dados utilizando a migração criada.
     ```
8. Configurar a program para não ficar em loop infinito nas entidades que tem relações com outras entidades.

   ```c#
   builder.Services
    .AddControllers()
    .AddNewtonsoftJson(options =>
    {
        // Ignora os loopings nas consultas
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        // Ignora valores nulos ao fazer junções nas consultas
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
    });
   ```
9. Por útimo criar as Interfaces, Repositories e Controllers.
