using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu]
public class ActiveAbility : ScriptableObject
{
    public string abilityName;
    public Sprite icon;
    public string casterTag;
    public float cooldownTime;
    public float activeTime;
    public virtual void Activate() { }
    public virtual void DeActivate() { }
}
