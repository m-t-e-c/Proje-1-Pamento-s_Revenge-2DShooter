using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IInteractible
{
    public bool IsActionPlayed { get; set; }

    public void Action()
    {
        if (!IsActionPlayed)
        {
            IsActionPlayed = true;
            print("Box Is Clicked");
        }
        else
        {
            print("Action Is Already Played");
        }
    }
}
