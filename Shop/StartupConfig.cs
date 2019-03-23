namespace Shop
{
    using System.Web.Http;

    using Microsoft.Owin.Security.OAuth;

    /// <summary>
    /// startup config
    /// </summary>
    public class StartupConfig
    {
        /// <summary>
        /// The config.
        /// </summary>
        private static HttpConfiguration config;

        /// <summary>
        /// Gets the config.
        /// </summary>
        public static HttpConfiguration Config => config ?? (config = new HttpConfiguration());
    }
}