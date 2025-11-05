using Entity.DTOs.Auth;

namespace Business.Interfaces.Implements.Auth
{
    public interface IToken
    {
        //Task<string> GenerateToken(LoginUserDto dto);
        /// <summary>
        /// Valida credenciales y emite Access + Refresh + CSRF.
        /// </summary>
        Task<(string AccessToken, string RefreshToken, string CsrfToken)> GenerateTokensAsync(LoginUserDto dto);

        /// <summary>
        /// Rota el refresh token y devuelve nuevo Access + Refresh.
        /// </summary>
        Task<(string NewAccessToken, string NewRefreshToken)> RefreshAsync(string refreshTokenPlain, string remoteIp = null);

        /// <summary>
        /// Revoca explícitamente un refresh token.
        /// </summary>
        Task RevokeRefreshTokenAsync(string refreshToken);
    }
}
