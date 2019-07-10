using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ProductCatalog.Data;

namespace ProductCatalog
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<StoreDataContext, StoreDataContext>(); // ele ver se tem na memoria antes de criar
            // services.AddTransient<StoreDataContext, StoreDataContext>();// a cada request ele cria uma nova request
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage(); // vai printar uma pagina de erros detalhadas apenas me produção

            app.UseMvc();
        }
    }
}
