namespace AppMovil.Config
{
    public sealed class ApiOptions
    {
        public string BaseUrl { get; init; } = "https://pottiest-administrative-madaline.ngrok-free.dev/api/v1/";
    }

    public static class ApiRoutes
    {
        // Ajusta según tu backend. Empezaremos con 'movies'.
        public const string Movies = "Movie?getAllType=0";
        public static string MovieById(int id) => $"Movie/{id}";
    }
}
