using UnityEngine;
using UnityEngine.Events;

namespace DoGames.Events.Channels
{
    public class VoidEventListener : BaseEventListener
    {
        // One event can have multiple responses
        public VoidEventChannelSO Event;
        public UnityEvent Response;

        protected virtual void OnEnable()
        {
            if (Event != null)
            {
                Event.RegisterListener(this);
            }
            else
            {
                Debug.LogError("OnEnable Null event in " + this.gameObject.name);
            }
        }

        protected virtual void OnDisable()
        { 
            if(Event != null){
                Event.UnregisterListener(this); 
            } else {
                Debug.LogError("OnDisable Null event in " + this.gameObject.name);
            }
        }

        public void OnEventRaised()
        {
            if (Response != null)
            {
                Response.Invoke();
            }
        }


    }
}
