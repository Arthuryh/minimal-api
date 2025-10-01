using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Hosting;
using MinimalApi.Dominio.Interfaces;

namespace Api.Test.Helpers;
public class Setup
{
    public const string PORT = "5011';
    public static TestContext testContext = default!;
    public static WebApplicationFactory<Program> factory = default!;
    public static HttpClient client = default!;

    public static void ClassInit(TestContext testContext)
    {
        Setup.testContext = testContext;
        Setup.http = new WebApplicationFactory<Startup>(builder =>
        {
            builder.UseSetting("https_port", Setup.PORT).UseEnvironment("Testing");

            builder.ConfigureServices(services =>
            {
                services.AddScoped<IAdministradorServico, AdministradoresServicoMock>();
            });
        })
    }
}
