using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTargetSystem : MonoBehaviour
{
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit info;
        Collider coll = GetComponent<Collider>();
        if (coll.Raycast(ray, out info, 100))
        {
            if (Input.GetMouseButton(0))
            {
                OnCharacterClicked();
            }
        }
    }

    private void OnCharacterClicked()
    {

    }
}
