using Common.Entities;
using Database.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace Website.Pages
{
    public partial class Index : ComponentBase, IAsyncDisposable
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IUserRepository UserRepository { get; set; }

        [Parameter]
        public int Id { get; set; }

        private HubConnection? hubConnection;
        private List<string> messages = new List<string>();
        private string? messageInput = string.Empty;

        private User CurrentUser = new User();

        protected override async Task OnInitializedAsync()
        {
            CurrentUser = UserRepository.GetUserById(Id);

            hubConnection = new HubConnectionBuilder()
                .WithUrl(NavigationManager.ToAbsoluteUri("/chathub"))
                .WithAutomaticReconnect()
                .Build();

            hubConnection.On<string, string>("ReceiveMessageAll", (user, message) =>
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
                await hubConnection.SendAsync("SendMessage", CurrentUser.Username, messageInput);
                messageInput = string.Empty;
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
