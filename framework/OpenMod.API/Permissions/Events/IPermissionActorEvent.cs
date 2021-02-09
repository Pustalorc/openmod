namespace OpenMod.API.Permissions.Events
{
    public interface IPermissionActorEvent : IPermissionEvent
    {
        public IPermissionActor Actor { get; }
    }
}
