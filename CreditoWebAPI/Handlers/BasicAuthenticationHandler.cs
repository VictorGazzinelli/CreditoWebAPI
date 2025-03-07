using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace CreditoWebAPI.Handlers
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder): base(options, logger, encoder)
        {

        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.NoResult();
            }

            string authorizationHeader = Request.Headers["Authorization"].ToString();
            if (!authorizationHeader.StartsWith("Basic ", StringComparison.OrdinalIgnoreCase))
            {
                return AuthenticateResult.NoResult();
            }

            string encodedCredentials = authorizationHeader.Substring("Basic ".Length).Trim();
            string decodedCredentials = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCredentials));
            string[] credentials = decodedCredentials.Split(':', 2);

            if (credentials.Length != 2)
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }

            string username = credentials[0];
            string password = credentials[1];

            if(!CredentialsAreValid(username, password))
                return AuthenticateResult.Fail("Invalid Username or Password");

            return CreateSuccessfullAuthenticateResult(username);
        }

        private AuthenticateResult CreateSuccessfullAuthenticateResult(string username)
        {
            Claim[] claims = { new Claim(ClaimTypes.NameIdentifier, username), new Claim(ClaimTypes.Name, username) };
            ClaimsIdentity identity = new ClaimsIdentity(claims, Scheme.Name);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            AuthenticationTicket ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }

        /// This simplistic credential validation function is for demonstration purposes only.
        /// 
        /// WARNING: This is a highly insecure and overly simplified implementation.
        ///          It should NEVER be used in a real-world production scenario.
        ///          Proper credential validation should involve:
        ///          - Secure password hashing (e.g., bcrypt, Argon2)
        ///          - Secure storage of credentials (e.g., hashed passwords in a database)
        ///          - Protection against brute-force attacks (e.g., rate limiting, account lockout)
        ///          - Multi-factor authentication (MFA) for added security
        private bool CredentialsAreValid(string username, string password) =>
            username == "admin" && password == "password";
    }
}
