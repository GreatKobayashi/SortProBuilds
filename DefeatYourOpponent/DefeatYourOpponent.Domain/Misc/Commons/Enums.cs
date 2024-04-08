﻿namespace DefeatYourOpponent.Domain.Misc
{
    public enum TeamPosition
    {
        TOP = 1,
        JUNGLE = 2,
        MIDDLE = 3,
        BOTTOM = 4,
        UTILITY = 5
    }

    public enum Tag
    {
        POSITION,
    }

    public enum QueueType
    {
        RANKED = 420,
        NORMAL = 490
    }

    public enum EventType
    {
        PURCHASE,
        KILL
    }
}
