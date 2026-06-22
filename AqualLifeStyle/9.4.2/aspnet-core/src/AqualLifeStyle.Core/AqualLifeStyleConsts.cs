using AqualLifeStyle.Debugging;

namespace AqualLifeStyle
{
    public class AqualLifeStyleConsts
    {
        public const string LocalizationSourceName = "AqualLifeStyle";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "a6afa3f0e7e74880a0605fe7fe4df06a";
    }
}
