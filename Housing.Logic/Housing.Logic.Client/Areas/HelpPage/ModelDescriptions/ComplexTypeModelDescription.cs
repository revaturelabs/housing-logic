using System.Collections.ObjectModel;

namespace Housing.Logic.Client.Areas.HelpPage.ModelDescriptions
{
#pragma warning disable CS1591
    public class ComplexTypeModelDescription : ModelDescription
    {
        public ComplexTypeModelDescription()
        {
            Properties = new Collection<ParameterDescription>();
        }

        public Collection<ParameterDescription> Properties { get; private set; }
    }
}