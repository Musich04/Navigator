using UnityEngine;

public abstract class PlayerState : MonoBehaviour
{
    public abstract void Accept();
    public abstract void Remove();
    public abstract void ExecuteHit(RaycastHit hit);
}
