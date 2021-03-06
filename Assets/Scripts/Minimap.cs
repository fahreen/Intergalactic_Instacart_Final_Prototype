using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{

    public Transform player;

    private void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y = this.transform.position.y;
        this.transform.position = newPosition;
        this.transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
    }
}
