using System.Runtime.InteropServices;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using TSPOnline.Extensions;
using TSPOnline.HtmlGenerator;
using TSPOnline.Models;

var builder = WebApplication.CreateBuilder(args);

// Add appsettings.json to configuration
builder.Services.Configure<AppSettings>(builder.Configuration);

// Add HttpContext
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Display Chinese characters
builder.Services.AddSingleton(HtmlEncoder.Create(System.Text.Unicode.UnicodeRanges.All));

// Custom ModelError in ModelState
builder.Services.AddTransient<IHtmlGenerator, AlertHtmlGenerator>();

// Add MVC type
builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();

//builder.WebHost.ConfigureKestrel(options =>
//{
//    options.ListenAnyIP(8200);
//    //options.ListenAnyIP(8201, configure => configure.UseHttps());
//});


var app = builder.Build();

// Select the exception page to use
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler(new ExceptionHandlerOptions()
    {
        ExceptionHandler = async context =>
            await Task.Run(() =>
            {
                var ex = context.Features.Get<IExceptionHandlerFeature>();
                if (ex is not null)
                {
                    string message = $"[Message] {ex.Error.Message}{Environment.NewLine}[StackTrace] {ex.Error.StackTrace.TrimStart(' ')}";
                    System.Text.Encoding.Default.GetBytes(message).SaveToFile(
                        filename: $"{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.log",
                        saveDir: @"logs/",
                        trueDir: $@"{app.Environment.WebRootPath}/");
                    context.Response.Redirect("/Error");
                }
            })
    });
}

// Select DbConnectionStrings to use
if (app.Environment.IsDevelopment())
{
    builder.Configuration["ConnectionStrings:DefaultConnection"] = builder.Configuration["ConnectionStrings:LocalDbConnection"];
}

// Enable `Reverse Proxy` mode when running on Linux
if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
{
    app.UseForwardedHeaders(new ForwardedHeadersOptions
    {
        ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
    });
}

// Use and redirect to HTTPS and
//app.UseRewriter(new RewriteOptions().AddRedirectToHttps(301, 443));
//app.UseHttpsRedirection();
//app.UseHsts();

// Use static files
var provider = new Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider();
provider.Mappings[".properties"] = "text/plain";
app.UseStaticFiles(new StaticFileOptions { ContentTypeProvider = provider });

// Use mvc
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapRazorPages());

app.Run();
