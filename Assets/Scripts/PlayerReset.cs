using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReset : MonoBehaviour
{
    public Transform startPoint; // ÆðµãÎ»ÖÃ
    public KeyCode ResetKey = KeyCode.R;

    void Update()
    {
        if (Input.GetKeyDown(ResetKey))
        {
            ResetPlayerPosition();
        }
    }

    void ResetPlayerPosition()
    {
        transform.position = startPoint.position;
        transform.rotation = startPoint.rotation;
    }
}

