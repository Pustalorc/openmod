namespace OpenMod.API.Permissions.Events
{
    public interface IRegisteredPermissionEvent : IPermissionEvent
    {
        IOpenModComponent Component { get; }

        string Permission { get; }

        string? Description { get; }

        PermissionGrantResult? DefaultGrant { get; }
    }
}
