using System;
using System.Reflection;

namespace Housing.Logic.Client.Areas.HelpPage.ModelDescriptions
{
#pragma warning disable CS1591
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}