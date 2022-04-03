using UnityEngine;

namespace DoGames.Events
{
    /// <summary>
    /// A type of event channel for types of events that pass
    /// more complex data than GameEventSO
    /// </summary>

    public class EventChannelBaseSO : ScriptableObject
    {
        [TextArea] public string description;

    }
}
