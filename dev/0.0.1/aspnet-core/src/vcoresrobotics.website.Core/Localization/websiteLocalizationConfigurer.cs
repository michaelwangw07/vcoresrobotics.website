using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace vcoresrobotics.website.Localization
{
    public static class websiteLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(websiteConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(websiteLocalizationConfigurer).GetAssembly(),
                        "vcoresrobotics.website.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
