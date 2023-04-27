using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace Website.Pages
{
    public partial class Index : ComponentBase, IAsyncDisposable
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private HubConnection? hubConnection;
        private List<string> messages = new List<string>();
        private string? userInput;
        private string? messageInput;

        protected override async Task OnInitializedAsync()
        {
            hubConnection = new HubConnectionBuilder()
                .WithUrl(NavigationManager.ToAbsoluteUri("/chathub"))
                .WithAutomaticReconnect()
                .Build();

            hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                var encodedMsg = $"{user}: {message}";
                messages.Add(encodedMsg);
                InvokeAsync(StateHasChanged);
            });

            await hubConnection.StartAsync();
        }

        private async Task Send()
        {
            if (hubConnection is not null)
            {
                await hubConnection.SendAsync("SendMessage", userInput, messageInput);
            }
        }

        public bool IsConnected =>
            hubConnection?.State == HubConnectionState.Connected;

        public async ValueTask DisposeAsync()
        {
            if (hubConnection is not null)
            {
                await hubConnection.DisposeAsync();
            }
        }
    }
}
