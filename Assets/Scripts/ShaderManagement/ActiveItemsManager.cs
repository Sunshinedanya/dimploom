using UnityEngine;

public class ActiveItemsManager : MonoBehaviour
{
    private GlowingObject[] activeItems;
    public float glowDuration = 5f;

    private void Start()
    {
        activeItems = FindObjectsByType<GlowingObject>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
    }

    public void HighlightAllActiveItems()
    {
        foreach (var item in activeItems)
        {
            item.StartGlow(glowDuration);
        }
    }
}