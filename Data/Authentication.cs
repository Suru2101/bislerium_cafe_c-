using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Data
{
    public class Authentication
    {
        private static Dictionary<string, UserInfo> userSessions = new Dictionary<string, UserInfo>();

        //This part indicates that the method is public, asynchronous, and returns a Task<bool>.
        //The async keyword is used to define an asynchronous method, and Task<bool> represents that the method will return a Task that eventually produces a bool result.
        public async Task<bool> AuthenticateAsync(LoginModel loginModel)
        {
            bool isAuthenticated = (loginModel.Username == "admin" && loginModel.Password == "admin") ||
                                   (loginModel.Username == "staff" && loginModel.Password == "staff");

            if (isAuthenticated)
            {
                string sessionToken = Guid.NewGuid().ToString();

                userSessions[sessionToken] = new UserInfo
                {
                    Username = loginModel.Username,
                    UserRole = GetRoleForUser(loginModel.Username)
                };

                return true;
            }

            return false;
        }

        public bool IsUserAuthenticated(string sessionToken)
        {
            return !string.IsNullOrEmpty(sessionToken) && userSessions.ContainsKey(sessionToken) && !IsSessionExpired(sessionToken);
        }

        public string GetUserRole(string sessionToken)
        {
            return userSessions.ContainsKey(sessionToken) ? userSessions[sessionToken].UserRole : null;
        }

        // Gets the session token of the first user in the userSessions dictionary.
        public string GetSessionToken()
        {
            foreach (var kvp in userSessions)
            {
                return kvp.Key;
            }

            return null;
        }

        private bool IsSessionExpired(string sessionToken)
        {
            // Set a time limit for the session (e.g., 30 minutes)
            TimeSpan sessionTimeout = TimeSpan.FromMinutes(30);

            return DateTime.Now - userSessions[sessionToken].LastAccessTime > sessionTimeout;
        }

        private string GetRoleForUser(string username)
        {
            if (username == "admin")
            {
                return "admin";
            }
            else if (username == "staff")
            {
                return "staff";
            }

            return null;
        }

        public void DestroySession()
        {
            userSessions.Clear();
        }
    }

    public class UserInfo
    {
        public string Username { get; set; }
        public string UserRole { get; set; }
        public DateTime LastAccessTime { get; set; } = DateTime.Now;
    }
}
