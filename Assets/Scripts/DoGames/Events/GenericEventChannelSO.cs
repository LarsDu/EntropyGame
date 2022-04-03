using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

/// <summary>
/// This class is used as the parent class for generic types of events.
/// Note that this cannot be serialized in the inspector due to use of generics.
/// Use this as a .
/// </summary>
namespace DoGames.Events
{

    public class GenericEventChannelSO<T> : EventChannelBaseSO
    {
        public UnityAction<T> eventAction;
        protected List<GenericEventListener<T>> listeners = new List<GenericEventListener<T>>();

        public virtual void RaiseEvent(T value)
        {
            if (eventAction != null)
                eventAction.Invoke(value);


            // Raise events in listeners
            foreach (GenericEventListener<T> listener in listeners)
            {
                listener.OnEventRaised(value);
            }
        }

        public void RegisterListener(GenericEventListener<T> listener)
        { listeners.Add(listener); }

        public void UnregisterListener(GenericEventListener<T> listener)
        { listeners.Remove(listener); }
    }
}

