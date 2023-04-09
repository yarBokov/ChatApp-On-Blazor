using BlazeChat.Shared.DTO;
using System.ComponentModel;

namespace BlazeChat.Client.States
{
    public class AuthenticationState : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public string? Name { get; set; }

        public string? Token { get; set; }

        private bool _isAuthenticatied;
        public bool IsAuthenticatied
        {
            get => _isAuthenticatied;
            set 
            { 
                if(_isAuthenticatied != value)
                {
                    _isAuthenticatied = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsAuthenticatied)));
                }
            }
        }


        public void LoadState(AuthResponseDTO authResponse)
        {
            Name = authResponse.Name;
            Token = authResponse.Token;
            IsAuthenticatied = true;
        }
        public void UnLoadState(AuthResponseDTO authResponse)
        {
            Name = null;
            Token = null;
            IsAuthenticatied = false;
        }
    }
}
