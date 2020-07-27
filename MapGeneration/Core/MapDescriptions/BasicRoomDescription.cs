﻿using System.Collections.Generic;
using MapGeneration.Core.MapDescriptions.Interfaces;
using Newtonsoft.Json;

namespace MapGeneration.Core.MapDescriptions
{
    /// <summary>
    /// Class that describes a basic (non-corridor) room
    /// </summary>
    public class BasicRoomDescription : IRoomDescription
    {
        /// <summary>
        /// This room is handled in the first stage of the generator.
        /// </summary>
        public int Stage => 1;

        /// <summary>
        /// List of room templates available for this room.
        /// </summary>
        public List<RoomTemplate> RoomTemplates { get; }

        [JsonConstructor]
        public BasicRoomDescription(List<RoomTemplate> roomTemplates)
        {
            RoomTemplates = roomTemplates;
        }
    }
}