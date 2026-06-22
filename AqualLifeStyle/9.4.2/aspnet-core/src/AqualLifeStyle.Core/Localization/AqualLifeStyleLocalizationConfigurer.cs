using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace AqualLifeStyle.Localization
{
    public static class AqualLifeStyleLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(AqualLifeStyleConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(AqualLifeStyleLocalizationConfigurer).GetAssembly(),
                        "AqualLifeStyle.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
