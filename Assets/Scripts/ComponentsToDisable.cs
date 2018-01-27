using UnityEngine;
[System.Serializable]
public class ComponentsToDisable : MonoBehaviour {
    public MonoBehaviour[] toDisable;

    public void Enabled() {
       for (int i = 0; i < toDisable.Length; i++)
            {
                toDisable[i].enabled = true;
            }
    }
    public void Disabled() {
        for (int i = 0; i < toDisable.Length; i++)
        {
            toDisable[i].enabled = false;
        }
    }
}
