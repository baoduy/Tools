using System;
using System.Collections.Generic;
using System.Configuration;
using ConfigEncryption.Exceptions;

namespace ConfigEncryption
{
    public static class Extentions
    {
        public static IEnumerable<ConfigurationSection> GetSections(this Configuration @this, EncryptionType type, string customSectionNames)
        {
            if (type.HasFlag(EncryptionType.AppSettings))
            {
                var section = @this.GetSection("appSettings");
                if (section != null)
                    yield return section;
            }

            if (type.HasFlag(EncryptionType.ConnectionStrings))
            {
                var section = @this.GetSection("connectionStrings");

                if (section != null)
                    yield return section;
            }

            if (type.HasFlag(EncryptionType.Custom) && !string.IsNullOrWhiteSpace(customSectionNames))
            {
                var names = customSectionNames.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var n in names)
                {
                    var section = @this.GetSection(n);

                    if (section == null)
                        throw new SectionNotFoundException(n);

                    yield return section;
                }
            }
        }
    }
}
