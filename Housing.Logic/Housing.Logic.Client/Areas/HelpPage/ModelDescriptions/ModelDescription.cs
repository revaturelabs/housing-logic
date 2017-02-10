using System;

namespace Housing.Logic.Client.Areas.HelpPage.ModelDescriptions
{
#pragma warning disable CS1591
    /// <summary>
    /// Describes a type model.
    /// </summary>
    public abstract class ModelDescription
    {
        public string Documentation { get; set; }

        public Type ModelType { get; set; }

        public string Name { get; set; }
    }
}