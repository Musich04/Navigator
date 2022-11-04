using UnityEngine;

public interface ISeletable
{
    public void Select();
    public void Cancel();
    public void Add(Color color);
    public void Remove();
}
