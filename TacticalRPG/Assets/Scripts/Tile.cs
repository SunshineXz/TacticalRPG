using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private GameManager manager;

    public void Start()
    {
        manager = GameManager.GetInstance();
    }

    void Update () 
    {
        if (manager.GetState() == CharacterTargetSystem.TargetState.CharacterSelected)
        {
            CheckRayCast();
        }
    }

    void CheckRayCast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit info;
        Collider coll = GetComponent<Collider>();
        if (coll.Raycast(ray, out info, 20))
        {
            if (Input.GetMouseButton(0))
            {
                OnTileClicked();
            }
            else
            {
                OnTileHovered();
            }
        }
        else
        {
            ChangeColor(Color.white);
        }
    }

    private void OnTileHovered()
    {
        ChangeColor(Color.blue);
    }

    private void OnTileClicked()
    {
        ChangeColor(Color.green);
    }

    public void ChangeColor(Color color)
    {
        gameObject.GetComponent<Renderer>().material.color = color;
    }
}
