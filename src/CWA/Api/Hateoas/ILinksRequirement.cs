using System;

namespace Api.Hateoas
{
    public interface ILinksRequirement
    {
        string Name { get; }
        object RouteValues(object input);
        Type ResourceType { get; }
        bool IsEnabled(object input);
    }
}
