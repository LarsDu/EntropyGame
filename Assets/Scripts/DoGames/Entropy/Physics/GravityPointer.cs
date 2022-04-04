using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoGames.Entropy.Phys
{
    public class GravityPointer : MonoBehaviour
    {
        
        [SerializeField] protected float factor = 3;
            protected void Update()
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Physics.gravity), Time.deltaTime * factor);
        }

    }
}