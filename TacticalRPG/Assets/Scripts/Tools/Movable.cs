using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour {

    [Header("Position")]
    public Vector2 Position;

    private void OnValidate()
    {
        transform.position = new Vector3(Position.x * 2, transform.position.y, Position.y * 2);
    }

    private void Update()
    {
        transform.position = new Vector3(Position.x * 2, transform.position.y, Position.y * 2);
    }
}
