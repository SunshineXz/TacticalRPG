using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        //if (GameManager.GetInstance().isPlayerTurn())
        //{
            CheckRayCast();
        //}
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
        //TESTS
        //GameManager.instance.characters[GameManager.instance.currentPlayerIndex].moving = false;
        //GameManager.instance.characters[GameManager.instance.currentPlayerIndex].attacking = true;

        //if (GameManager.instance.isPlayerMoving())
        //{
        //    ChangeColor(Color.blue);
        //}
        //else if (GameManager.instance.isPlayerAttacking())
        //{
        //    ChangeColor(Color.red);
        //}
        //else
        //{
        //    ChangeColor(Color.black);
        //}

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
