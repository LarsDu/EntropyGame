using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoGames.Entropy.Entities;
namespace DoGames.Entropy.Managers
{
    [System.Serializable]
    public class ReceiverObjective {
        public ColorTypeSO type;
        public int threshold;
    }


    public class ObjectivesInfo : ScriptableObject
    {
        
    }
}