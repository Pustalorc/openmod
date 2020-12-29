﻿using OpenMod.Unturned.Players;
using Steamworks;

namespace OpenMod.Unturned.Vehicles.Events
{
    public class UnturnedVehicleLockUpdatedEvent : UnturnedVehicleEvent
    {
        public UnturnedPlayer Instigator { get; }

        public CSteamID Group { get; }

        public bool IsLocked { get; }

        public UnturnedVehicleLockUpdatedEvent(UnturnedPlayer instigator, UnturnedVehicle vehicle, CSteamID group, bool isLocked) : base(vehicle)
        {
            Instigator = instigator;
            Group = group;
            IsLocked = isLocked;
        }
    }
}
