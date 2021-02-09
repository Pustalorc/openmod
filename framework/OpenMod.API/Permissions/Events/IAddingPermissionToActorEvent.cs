using OpenMod.API.Eventing;

namespace OpenMod.API.Permissions.Events
{
    public interface IAddingPermissionToActorEvent : IPermissionActorEvent, ICancellableEvent
    {
        PermissionType PermissionType { get; }

        string Permission { get; }
    }
}
