using OpenMod.API.Eventing;

namespace OpenMod.API.Permissions.Events
{
    public interface IRegisteringPermissionEvent : IPermissionEvent, ICancellableEvent
    {
        IOpenModComponent Component { get; }

        string Permission { get; }

        string? Description { get; }

        PermissionGrantResult? DefaultGrant { get; }
    }
}
