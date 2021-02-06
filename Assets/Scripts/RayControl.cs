using System;
using UnityEngine;

public class RayControl : MonoBehaviour
{
    private RaycastHit2D[] hits;
    private Vector2 direction;

    private void Update()
    {
        if (GetComponent<Rigidbody2D>().velocity.x < -0.01f)
        {
            direction = Vector2.left;
        }
        else direction = Vector2.right;

        hits = Physics2D.RaycastAll(transform.position, direction, 2f);
        Debug.DrawRay((Vector2) transform.position, direction * 2f, Color.magenta);

        foreach (var hit in hits)
        {
            if (hit.transform.TryGetComponent<IInteractible>(out IInteractible iInteractible))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    iInteractible.Action();
                }
            }
        }
        
    }
}