using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Housing.Logic.Client.Areas.HelpPage.ModelDescriptions
{
#pragma warning disable CS1591
    public class EnumTypeModelDescription : ModelDescription
    {
        public EnumTypeModelDescription()
        {
            Values = new Collection<EnumValueDescription>();
        }

        public Collection<EnumValueDescription> Values { get; private set; }
    }
}