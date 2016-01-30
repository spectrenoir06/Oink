﻿using System;
using System.Collections.Generic;

public delegate void Callback();
public delegate void Callback<T>(T arg1);
public delegate void Callback<T, U>(T arg1, U arg2);
public delegate void Callback<T, U, V>(T arg1, U arg2, V arg3);

public enum EnumEvent
{
    IsNight
}

/// <summary>
///  An EventManager for events that have no parameters..
/// </summary>
static public class EventManager
{
    private static Dictionary<EnumEvent, Delegate> eventTable = new Dictionary<EnumEvent, Delegate>();

    static public void AddListener(EnumEvent eventType, Callback handler)
    {
        // Obtain a lock on the event table to keep this thread-safe.
        lock (eventTable)
        {
            // Create an entry for this event type if it doesn't already exist.
            if (!eventTable.ContainsKey(eventType))
            {
                eventTable.Add(eventType, null);
            }
            // Add the handler to the event.
            eventTable[eventType] = (Callback)eventTable[eventType] + handler;
        }
    }

    static public void RemoveListener(EnumEvent eventType, Callback handler)
    {
        // Obtain a lock on the event table to keep this thread-safe.
        lock (eventTable)
        {
            // Only take action if this event type exists.
            if (eventTable.ContainsKey(eventType))
            {
                // Remove the event handler from this event.
                eventTable[eventType] = (Callback)eventTable[eventType] - handler;

                // If there's nothing left then remove the event type from the event table.
                if (eventTable[eventType] == null)
                {
                    eventTable.Remove(eventType);
                }
            }
        }
    }

    static public void Raise(EnumEvent eventType)
    {
        Delegate d;
        // Raise the delegate only if the event type is in the dictionary.
        if (eventTable.TryGetValue(eventType, out d))
        {
            // Take a local copy to prevent a race condition if another thread
            // were to unsubscribe from this event.
            Callback callback = (Callback)d;

            // Raise the delegate if it's not null.
            if (callback != null)
            {
                callback();
            }
        }
    }
}

/// <summary>
/// An EventManager for events that have one parameter of type T.
/// </summary>
static public class EventManager<T>
{
    private static Dictionary<EnumEvent, Delegate> eventTable = new Dictionary<EnumEvent, Delegate>();

    static public void AddListener(EnumEvent eventType, Callback<T> handler)
    {
        // Obtain a lock on the event table to keep this thread-safe.
        lock (eventTable)
        {
            // Create an entry for this event type if it doesn't already exist.
            if (!eventTable.ContainsKey(eventType))
            {
                eventTable.Add(eventType, null);
            }
            // Add the handler to the event.
            eventTable[eventType] = (Callback<T>)eventTable[eventType] + handler;
        }
    }

    static public void RemoveListener(EnumEvent eventType, Callback<T> handler)
    {
        // Obtain a lock on the event table to keep this thread-safe.
        lock (eventTable)
        {
            // Only take action if this event type exists.
            if (eventTable.ContainsKey(eventType))
            {
                // Remove the event handler from this event.
                eventTable[eventType] = (Callback<T>)eventTable[eventType] - handler;

                // If there's nothing left then remove the event type from the event table.
                if (eventTable[eventType] == null)
                {
                    eventTable.Remove(eventType);
                }
            }
        }
    }

    static public void Raise(EnumEvent eventType, T arg1)
    {
        Delegate d;
        // Raise the delegate only if the event type is in the dictionary.
        if (eventTable.TryGetValue(eventType, out d))
        {
            // Take a local copy to prevent a race condition if another thread
            // were to unsubscribe from this event.
            Callback<T> callback = (Callback<T>)d;

            // Raise the delegate if it's not null.
            if (callback != null)
            {
                callback(arg1);
            }
        }
    }
}

/// <summary>
/// An EventManager for events that have one parameter of type T and U.
/// </summary>
static public class EventManager<T, U>
{
    private static Dictionary<EnumEvent, Delegate> eventTable = new Dictionary<EnumEvent, Delegate>();

    static public void AddListener(EnumEvent eventType, Callback<T, U> handler)
    {
        // Obtain a lock on the event table to keep this thread-safe.
        lock (eventTable)
        {
            // Create an entry for this event type if it doesn't already exist.
            if (!eventTable.ContainsKey(eventType))
            {
                eventTable.Add(eventType, null);
            }
            // Add the handler to the event.
            eventTable[eventType] = (Callback<T, U>)eventTable[eventType] + handler;
        }
    }

    static public void RemoveListener(EnumEvent eventType, Callback<T, U> handler)
    {
        // Obtain a lock on the event table to keep this thread-safe.
        lock (eventTable)
        {
            // Only take action if this event type exists.
            if (eventTable.ContainsKey(eventType))
            {
                // Remove the event handler from this event.
                eventTable[eventType] = (Callback<T, U>)eventTable[eventType] - handler;
                // If there's nothing left then remove the event type from the event table.
                if (eventTable[eventType] == null)
                {
                    eventTable.Remove(eventType);
                }
            }
        }
    }

    static public void Raise(EnumEvent eventType, T arg1, U arg2)
    {
        Delegate d;
        // Raise the delegate only if the event type is in the dictionary.
        if (eventTable.TryGetValue(eventType, out d))
        {
            // Take a local copy to prevent a race condition if another thread
            // were to unsubscribe from this event.
            Callback<T, U> callback = (Callback<T, U>)d;

            // Raise the delegate if it's not null.
            if (callback != null)
            {
                callback(arg1, arg2);
            }
        }
    }
}

/// <summary>
/// An EventManager for events that have one parameter of type T, U and V.
/// </summary>
static public class EventManager<T, U, V>
{
    private static Dictionary<EnumEvent, Delegate> eventTable = new Dictionary<EnumEvent, Delegate>();

    static public void AddListener(EnumEvent eventType, Callback<T, U, V> handler)
    {
        // Obtain a lock on the event table to keep this thread-safe.
        lock (eventTable)
        {
            // Create an entry for this event type if it doesn't already exist.
            if (!eventTable.ContainsKey(eventType))
            {
                eventTable.Add(eventType, null);
            }
            // Add the handler to the event.
            eventTable[eventType] = (Callback<T, U, V>)eventTable[eventType] + handler;
        }
    }

    static public void RemoveListener(EnumEvent eventType, Callback<T, U, V> handler)
    {
        // Obtain a lock on the event table to keep this thread-safe.
        lock (eventTable)
        {
            // Only take action if this event type exists.
            if (eventTable.ContainsKey(eventType))
            {
                // Remove the event handler from this event.
                eventTable[eventType] = (Callback<T, U, V>)eventTable[eventType] - handler;

                // If there's nothing left then remove the event type from the event table.
                if (eventTable[eventType] == null)
                {
                    eventTable.Remove(eventType);
                }
            }
        }
    }

    static public void Raise(EnumEvent eventType, T arg1, U arg2, V arg3)
    {
        Delegate d;
        // Raise the delegate only if the event type is in the dictionary.
        if (eventTable.TryGetValue(eventType, out d))
        {
            // Take a local copy to prevent a race condition if another thread
            // were to unsubscribe from this event.
            Callback<T, U, V> callback = (Callback<T, U, V>)d;

            // Raise the delegate if it's not null.
            if (callback != null)
            {
                callback(arg1, arg2, arg3);
            }
        }
    }
}