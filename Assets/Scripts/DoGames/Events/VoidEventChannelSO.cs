using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This class is used for Events that have no arguments (Example: Exit game event)
/// </summary>
namespace DoGames.Events.Channels
{
    [CreateAssetMenu(menuName = "DoGames/Events/Void Event Channel")]
    public class VoidEventChannelSO : EventChannelBaseSO
    {
        public UnityAction eventAction;
        protected List<VoidEventListener> listeners = new List<VoidEventListener>();

        public void RaiseEvent()
        {
            if (eventAction != null)
                eventAction.Invoke();

            // Raise events in listeners
            foreach(VoidEventListener listener in listeners){
                listener.OnEventRaised();
            }
        }

        public void RegisterListener(VoidEventListener listener)
        { listeners.Add(listener); }

        public void UnregisterListener(VoidEventListener listener)
        { listeners.Remove(listener); }
        
    }
}

