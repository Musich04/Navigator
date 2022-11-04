using UnityEngine;

public class RayCreator
{
    public RaycastHit SetHit()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray);

        foreach (RaycastHit hit in hits)
            if (hit.collider.TryGetComponent(out Point point))
                return hit;

        return hits[hits.Length - 1];
    }
}
