#pragma checksum "C:\Users\yeins\Downloads\Telegram Desktop\EscenarioDeportivo\EscenarioDeportivo\EscenarioDeportivo.FrontEnd\Pages\Registro\Deportista\VerDeportistas.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "704884ab3373bbe4b0a4820534c3174cfd126c32"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(EscenarioDeportivo.FrontEnd.Pages.Registro.Deportista.Pages_Registro_Deportista_VerDeportistas), @"mvc.1.0.razor-page", @"/Pages/Registro/Deportista/VerDeportistas.cshtml")]
namespace EscenarioDeportivo.FrontEnd.Pages.Registro.Deportista
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\yeins\Downloads\Telegram Desktop\EscenarioDeportivo\EscenarioDeportivo\EscenarioDeportivo.FrontEnd\Pages\_ViewImports.cshtml"
using EscenarioDeportivo.FrontEnd;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"704884ab3373bbe4b0a4820534c3174cfd126c32", @"/Pages/Registro/Deportista/VerDeportistas.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5222b05c98fab3b9a5e1cd250012d5f01446c152", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Registro_Deportista_VerDeportistas : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "CrearDeportista", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "EditarDeportista", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "EliminarDeportista", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\yeins\Downloads\Telegram Desktop\EscenarioDeportivo\EscenarioDeportivo\EscenarioDeportivo.FrontEnd\Pages\Registro\Deportista\VerDeportistas.cshtml"
  
    ViewData["Title"]="Deportistas";

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\yeins\Downloads\Telegram Desktop\EscenarioDeportivo\EscenarioDeportivo\EscenarioDeportivo.FrontEnd\Pages\Registro\Deportista\VerDeportistas.cshtml"
 if (TempData["mensajeCreado"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-warning alert-dismissible fade show\" role=\"alert\">\r\n        ");
#nullable restore
#line 9 "C:\Users\yeins\Downloads\Telegram Desktop\EscenarioDeportivo\EscenarioDeportivo\EscenarioDeportivo.FrontEnd\Pages\Registro\Deportista\VerDeportistas.cshtml"
   Write(TempData["mensajeCreado"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">\r\n            <span aria-hidden=\"true\">&times;</span>\r\n        </button>\r\n    </div>\r\n");
#nullable restore
#line 14 "C:\Users\yeins\Downloads\Telegram Desktop\EscenarioDeportivo\EscenarioDeportivo\EscenarioDeportivo.FrontEnd\Pages\Registro\Deportista\VerDeportistas.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container\">\r\n    <div class=\"row justify-content-center bg-light\">\r\n        <div class=\"col-sm-6\">\r\n            <h3>Deportistas</h3>\r\n        </div>\r\n        <div class=\"col-sm-6\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "704884ab3373bbe4b0a4820534c3174cfd126c326852", async() => {
                WriteLiteral("Agregar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"row justify-content-center\">\r\n");
#nullable restore
#line 25 "C:\Users\yeins\Downloads\Telegram Desktop\EscenarioDeportivo\EscenarioDeportivo\EscenarioDeportivo.FrontEnd\Pages\Registro\Deportista\VerDeportistas.cshtml"
         if (Model._listaVistaDeportista.Count() > 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <table class=""table table-bordered table-striped"">
                <thead>
                    <tr>
                        <td>Documento</td>
                        <td>Nombres</td>
                        <td>Apellidos</td>
                        <td>Género</td>
                        <td>Rh</td>
                        <td>EPS</td>
                        <td data-type=""date"">Fecha de Nacimiento</td>
                        <td>Disciplina Deportista</td>
                        <td>Dirección</td>
                        <td>Equipo</td>
                        <td>Disciplina Equipo</td>
                        <td>Qué desea hacer?</td>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 45 "C:\Users\yeins\Downloads\Telegram Desktop\EscenarioDeportivo\EscenarioDeportivo\EscenarioDeportivo.FrontEnd\Pages\Registro\Deportista\VerDeportistas.cshtml"
                     foreach (var dep in Model._listaVistaDeportista)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 48 "C:\Users\yeins\Downloads\Telegram Desktop\EscenarioDeportivo\EscenarioDeportivo\EscenarioDeportivo.FrontEnd\Pages\Registro\Deportista\VerDeportistas.cshtml"
                           Write(dep.Documento);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 49 "C:\Users\yeins\Downloads\Telegram Desktop\EscenarioDeportivo\EscenarioDeportivo\EscenarioDeportivo.FrontEnd\Pages\Registro\Deportista\VerDeportistas.cshtml"
                           Write(dep.Nombres);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 50 "C:\Users\yeins\Downloads\Telegram Desktop\EscenarioDeportivo\EscenarioDeportivo\EscenarioDeportivo.FrontEnd\Pages\Registro\Deportista\VerDeportistas.cshtml"
                           Write(dep.Apellidos);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 51 "C:\Users\yeins\Downloads\Telegram Desktop\EscenarioDeportivo\EscenarioDeportivo\EscenarioDeportivo.FrontEnd\Pages\Registro\Deportista\VerDeportistas.cshtml"
                           Write(dep.Genero);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 52 "C:\Users\yeins\Downloads\Telegram Desktop\EscenarioDeportivo\EscenarioDeportivo\EscenarioDeportivo.FrontEnd\Pages\Registro\Deportista\VerDeportistas.cshtml"
                           Write(dep.Rh);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 53 "C:\Users\yeins\Downloads\Telegram Desktop\EscenarioDeportivo\EscenarioDeportivo\EscenarioDeportivo.FrontEnd\Pages\Registro\Deportista\VerDeportistas.cshtml"
                           Write(dep.EPS);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 54 "C:\Users\yeins\Downloads\Telegram Desktop\EscenarioDeportivo\EscenarioDeportivo\EscenarioDeportivo.FrontEnd\Pages\Registro\Deportista\VerDeportistas.cshtml"
                           Write(dep.FechaNacimiento);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 55 "C:\Users\yeins\Downloads\Telegram Desktop\EscenarioDeportivo\EscenarioDeportivo\EscenarioDeportivo.FrontEnd\Pages\Registro\Deportista\VerDeportistas.cshtml"
                           Write(dep.Disciplina);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 56 "C:\Users\yeins\Downloads\Telegram Desktop\EscenarioDeportivo\EscenarioDeportivo\EscenarioDeportivo.FrontEnd\Pages\Registro\Deportista\VerDeportistas.cshtml"
                           Write(dep.Direccion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 57 "C:\Users\yeins\Downloads\Telegram Desktop\EscenarioDeportivo\EscenarioDeportivo\EscenarioDeportivo.FrontEnd\Pages\Registro\Deportista\VerDeportistas.cshtml"
                           Write(dep.EquipoNombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 58 "C:\Users\yeins\Downloads\Telegram Desktop\EscenarioDeportivo\EscenarioDeportivo\EscenarioDeportivo.FrontEnd\Pages\Registro\Deportista\VerDeportistas.cshtml"
                           Write(dep.EquipoDisciplina);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "704884ab3373bbe4b0a4820534c3174cfd126c3213674", async() => {
                WriteLiteral("Editar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-depDocumento", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 60 "C:\Users\yeins\Downloads\Telegram Desktop\EscenarioDeportivo\EscenarioDeportivo\EscenarioDeportivo.FrontEnd\Pages\Registro\Deportista\VerDeportistas.cshtml"
                                                                                                        WriteLiteral(dep.Documento);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["depDocumento"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-depDocumento", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["depDocumento"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "704884ab3373bbe4b0a4820534c3174cfd126c3216124", async() => {
                WriteLiteral("Eliminar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-depDocumento", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 61 "C:\Users\yeins\Downloads\Telegram Desktop\EscenarioDeportivo\EscenarioDeportivo\EscenarioDeportivo.FrontEnd\Pages\Registro\Deportista\VerDeportistas.cshtml"
                                                                                                            WriteLiteral(dep.Documento);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["depDocumento"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-depDocumento", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["depDocumento"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 64 "C:\Users\yeins\Downloads\Telegram Desktop\EscenarioDeportivo\EscenarioDeportivo\EscenarioDeportivo.FrontEnd\Pages\Registro\Deportista\VerDeportistas.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n");
#nullable restore
#line 67 "C:\Users\yeins\Downloads\Telegram Desktop\EscenarioDeportivo\EscenarioDeportivo\EscenarioDeportivo.FrontEnd\Pages\Registro\Deportista\VerDeportistas.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <p class=\"lead\">No hay Deportistas registrados!</p>\r\n");
#nullable restore
#line 71 "C:\Users\yeins\Downloads\Telegram Desktop\EscenarioDeportivo\EscenarioDeportivo\EscenarioDeportivo.FrontEnd\Pages\Registro\Deportista\VerDeportistas.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EscenarioDeportivo.FrontEnd.Pages.VerDeportistasModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<EscenarioDeportivo.FrontEnd.Pages.VerDeportistasModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<EscenarioDeportivo.FrontEnd.Pages.VerDeportistasModel>)PageContext?.ViewData;
        public EscenarioDeportivo.FrontEnd.Pages.VerDeportistasModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591