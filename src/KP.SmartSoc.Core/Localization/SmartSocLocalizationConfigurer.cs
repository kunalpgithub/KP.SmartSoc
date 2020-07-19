using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace KP.SmartSoc.Localization
{
    public static class SmartSocLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(SmartSocConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(SmartSocLocalizationConfigurer).GetAssembly(),
                        "KP.SmartSoc.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
