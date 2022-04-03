using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoGames.Entropy.Phys
{
    public class CooldownGravityControl : GravityControl
    {
        [Header("--COOLDOWN--")]
        [SerializeField] protected float cooldownTime;
    }
}