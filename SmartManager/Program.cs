using SmartManager.Brokers.DateTimes;
using SmartManager.Brokers.Loggings;
using SmartManager.Brokers.Spreadsheets;
using SmartManager.Brokers.Storages;
using SmartManager.Services.Foundations.Applicants;
using SmartManager.Services.Foundations.Groups;
using SmartManager.Services.Foundations.Spreadsheets;
using SmartManager.Services.Foundations.Users;
using SmartManager.Services.Orchestrations;
using SmartManager.Services.Proccessings.Applicants;
using SmartManager.Services.Proccessings.Groups;
using SmartManager.Services.Proccessings.Spreadsheets;
using SmartManager.Services.Proccessings.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<IStorageBroker, StorageBroker>();
builder.Services.AddTransient<IDateTimeBroker, DateTimeBroker>();
builder.Services.AddTransient<ILoggingBroker, LoggingBroker>();
builder.Services.AddTransient<IOrchestrationService, OrchestrationService>();
builder.Services.AddTransient<IApplicantProcessingService, ApplicantProcessingService>();
builder.Services.AddTransient<IApplicantService, ApplicantService>();
builder.Services.AddTransient<ISpreadsheetsProcessingService, SpreadsheetsProcessingService>();
builder.Services.AddTransient<ISpreadsheetService, SpreadsheetService>();
builder.Services.AddTransient<ISpreadsheetBroker, SpreadsheetBroker>();
builder.Services.AddTransient<IGroupProcessingService, GroupProcessingService>();
builder.Services.AddTransient<IGroupService, GroupService>();
builder.Services.AddTransient<IUserProcessingService, UserProcessingService>();
builder.Services.AddTransient<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
