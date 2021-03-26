using System;
using System.Runtime.InteropServices;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using TSPOnline.Extensions;
using TSPOnline.Models;

namespace TSPOnline
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration) =>
            this.configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            // Add appsettings.json to configuration
            services.Configure<AppSettings>(configuration);

            // Add HttpContext
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Display Chinese characters
            services.AddSingleton(HtmlEncoder.Create(System.Text.Unicode.UnicodeRanges.All));

            // Custom ModelError in ModelState
            services.AddTransient<IHtmlGenerator, AlertHtmlGenerator>();

            // Add MVC type
            services.AddRazorPages()
                .AddRazorRuntimeCompilation();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Select the exception page to use
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseExceptionHandler(new ExceptionHandlerOptions()
                {
                    ExceptionHandler = async context =>
                        await Task.Run(() =>
                        {
                            var ex = context.Features.Get<IExceptionHandlerFeature>();
                            string message = $"[Message] {ex.Error.Message}{Environment.NewLine}[StackTrace] {ex.Error.StackTrace.TrimStart(' ')}";
                            System.Text.Encoding.Default.GetBytes(message).SaveToFile(
                                filename: $"{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.log",
                                saveDir: @"logs/",
                                trueDir: $@"{env.WebRootPath}/");
                            context.Response.Redirect("/Error");
                        })
                });

            // Select DbConnectionStrings to use
            if (env.IsDevelopment())
                configuration["ConnectionStrings:DefaultConnection"] = configuration["ConnectionStrings:LocalDbConnection"];

            // Enable `Reverse Proxy` mode when running on Linux
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                app.UseForwardedHeaders(new ForwardedHeadersOptions
                {
                    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
                });

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
        }

        // Source code
        // https://github.com/aspnet/Mvc/blob/release/2.2/src/Microsoft.AspNetCore.Mvc.ViewFeatures/ViewFeatures/DefaultHtmlGenerator.cs
        public class AlertHtmlGenerator : DefaultHtmlGenerator
        {
            public AlertHtmlGenerator(IAntiforgery antiforgery, IOptions<MvcViewOptions> optionsAccessor, IModelMetadataProvider metadataProvider, IUrlHelperFactory urlHelperFactory, HtmlEncoder htmlEncoder, ValidationHtmlAttributeProvider validationAttributeProvider)
                : base(antiforgery, optionsAccessor, metadataProvider, urlHelperFactory, htmlEncoder, validationAttributeProvider)
            {
            }

            public override TagBuilder GenerateValidationMessage(ViewContext viewContext, ModelExplorer modelExplorer, string expression, string message, string tag, object htmlAttributes) =>
                base.GenerateValidationMessage(viewContext, modelExplorer, expression, message, tag, htmlAttributes);

            public override TagBuilder GenerateValidationSummary(ViewContext viewContext, bool excludePropertyErrors, string message, string headerTag, object htmlAttributes)
            {
                var htmlSummary = new TagBuilder("div");
                if (!viewContext.ModelState.IsValid)
                    foreach (var modelState in viewContext.ModelState)
                        if (modelState.Value.ValidationState != ModelValidationState.Valid)
                            foreach (var error in modelState.Value.Errors)
                                switch (modelState.Key.Split(new char[] { '_' })[0])
                                {
                                    case "Info":
                                        {
                                            TagBuilder div = new TagBuilder("div");
                                            TagBuilder icon = new TagBuilder("i");
                                            icon.AddCssClass("fas fa-info-circle fa-fw");
                                            div.InnerHtml.AppendHtml(icon);
                                            div.InnerHtml.AppendLine(" " + error.ErrorMessage);
                                            div.AddCssClass("alert alert-info");
                                            htmlSummary.InnerHtml.AppendHtml(div);
                                            break;
                                        }
                                    case "Success":
                                        {
                                            TagBuilder div = new TagBuilder("div");
                                            TagBuilder icon = new TagBuilder("i");
                                            icon.AddCssClass("fas fa-check-circle fa-fw");
                                            div.InnerHtml.AppendHtml(icon);
                                            div.InnerHtml.AppendLine(" " + error.ErrorMessage);
                                            div.AddCssClass("alert alert-success");
                                            htmlSummary.InnerHtml.AppendHtml(div);
                                            break;
                                        }
                                    case "Warning":
                                        {
                                            TagBuilder div = new TagBuilder("div");
                                            TagBuilder icon = new TagBuilder("i");
                                            icon.AddCssClass("fas fa-exclamation-triangle fa-fw");
                                            div.InnerHtml.AppendHtml(icon);
                                            div.InnerHtml.AppendLine(" " + error.ErrorMessage);
                                            div.AddCssClass("alert alert-warning");
                                            htmlSummary.InnerHtml.AppendHtml(div);
                                            break;
                                        }
                                    default:
                                        {
                                            TagBuilder div = new TagBuilder("div");
                                            TagBuilder icon = new TagBuilder("i");
                                            icon.AddCssClass("fas fa-exclamation-circle fa-fw");
                                            div.InnerHtml.AppendHtml(icon);
                                            div.InnerHtml.AppendLine(" " + error.ErrorMessage);
                                            div.AddCssClass("alert alert-danger");
                                            htmlSummary.InnerHtml.AppendHtml(div);
                                            break;
                                        }
                                }
                        else
                            htmlSummary.MergeAttribute("display", "none");
                return htmlSummary;
            }
        }
    }
}
