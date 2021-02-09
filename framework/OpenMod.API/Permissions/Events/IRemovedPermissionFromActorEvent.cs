namespace OpenMod.API.Permissions.Events
{
    public interface IRemovedPermissionFromActorEvent : IPermissionActorEvent
    {
        PermissionType PermissionType { get; }

        string Permission { get; }
    }
}
