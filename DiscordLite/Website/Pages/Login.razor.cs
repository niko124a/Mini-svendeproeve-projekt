using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Website.Pages
{
    public partial class Login : ComponentBase
    {
        bool success;
        string[] errors = { };
        MudTextField<string> pwField1;
        MudForm form;


    }
}
