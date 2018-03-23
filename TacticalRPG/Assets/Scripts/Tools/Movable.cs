using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movable : MonoBehaviour {

    [Header("Position")]
    public Vector2 Position;

    protected Movable()
    {
        Position = new Vector2(0, 0);
    }

    private void OnValidate()
    {
        transform.position = new Vector3(Position.x * 2, transform.position.y, Position.y * 2);
    }

    private void Update()
    {
        transform.position = new Vector3(Position.x * 2, transform.position.y, Position.y * 2);
    }
}
