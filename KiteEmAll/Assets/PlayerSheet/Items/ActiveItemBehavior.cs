using UnityEngine;

public class ActivateItemBehavior : MonoBehaviour
{
    protected PlayerStats playerStats;
    virtual public void SetStats(PlayerStats playerStats)
    {
        this.playerStats = playerStats;
    }
    virtual public void ActivateItem(Component sender, object data)
    {
        Debug.Log("xDD");
    }
}
