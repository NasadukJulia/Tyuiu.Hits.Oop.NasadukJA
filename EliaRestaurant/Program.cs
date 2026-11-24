using EliaRestaurant.Components;
using EliaRestaurant.Services;

// Создаём веб-приложение
var builder = WebApplication.CreateBuilder(args);

// Подключаем Blazor и интерактивность страниц
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Подключаем сервис управления бронированиями
builder.Services.AddScoped<BookingService>();

// Собираем приложение
var app = builder.Build();

// Настройки обработки ошибок
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// Подключаем защищённое соединение HTTPS
app.UseHttpsRedirection();

// Подключаем статические файлы: фотографии и CSS
app.UseStaticFiles();

// Подключаем защиту от поддельных запросов
app.UseAntiforgery();

// Подключаем компоненты Blazor
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Запускаем приложение
app.Run();