using BackGroundService.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace BackGroundService
{
    public class InactivityService : BackgroundService
    {
        private readonly ILogger<InactivityService> _logger;
        private readonly IHubContext<NotificationHub> _hubContext;
        private DateTime lastActivityTime; // Registra el momento de la última interacción del cliente

        public InactivityService(ILogger<InactivityService> logger, IHubContext<NotificationHub> hubContext)
        {
            _logger = logger;
            _hubContext = hubContext;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            lastActivityTime = DateTime.Now; // Inicializa la hora de la última actividad

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Verificando inactividad...");

                // Calcula el tiempo transcurrido desde la última actividad
                TimeSpan elapsed = DateTime.Now - lastActivityTime;

                if (elapsed.TotalSeconds >= 5) // Si ha estado inactivo durante 20 segundos
                {
                    // Envia una notificación al cliente utilizando SignalR
                    await _hubContext.Clients.All.SendAsync("ReceiveNotification", "¡Estás inactivo!");

                    // Implementa lógica para cerrar la aplicación del cliente (puede variar según la plataforma)
                    // Por ejemplo, si es una aplicación web, puedes redirigir al cliente a una página de cierre.
                }

                await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
            }
        }

        // Método para registrar la actividad del cliente
        public void RegisterActivity()
        {
            lastActivityTime = DateTime.Now; // Actualiza el tiempo de la última actividad cuando el cliente interactúa.
        }
    }
}
