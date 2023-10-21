using BackGroundService;
using Microsoft.AspNetCore.Mvc;


public class HomeController : Controller
{
    private readonly IServiceProvider _serviceProvider;

    public HomeController(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IActionResult Index()
    {
        // Aquí, se considera que el cliente está interactuando
        // Llama a RegisterActivity para registrar la actividad
        var inactivityService = _serviceProvider.GetRequiredService<InactivityService>();
        inactivityService.RegisterActivity();

        // Resto de la lógica del controlador
        return View();
    }
}