using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTargetSystem : MonoBehaviour
{
    public enum TargetState
    {
        Normal,
        CharacterSelected
    }

    [SerializeField]
    private LayerMask characterMask;

    [SerializeField]
    private LayerMask tileMask;

    public TargetState currentState;
    public Character selectedCharacter;

    private void Start()
    {
        currentState = TargetState.Normal;
    }

    void Update()
    {
        switch(currentState)
        {
            case TargetState.Normal:
                CheckHover();
                break;
            case TargetState.CharacterSelected:
                CheckAction();
                break;
        }
    }

    private void CheckHover()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit info;
        if (Physics.Raycast(ray, out info, 1000, characterMask))
        {
            var character = info.collider.gameObject.GetComponent<Character>();
            if (Input.GetMouseButtonUp(0) && character != null)
            {
                OnCharacterClicked(character);
            }
        }
    }

    private void CheckAction()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit info;
        if (Physics.Raycast(ray, out info, 1000, tileMask))
        {
            var tile = info.collider.gameObject.GetComponent<HexCell>();
            if (Input.GetMouseButtonUp(0))
            {
                if (tile != null && tile.Chararacter == null)
                {
                    OnTileClicked(tile);
                }
            }
        }
    }

    private void OnCharacterClicked(Character character)
    {
        currentState = TargetState.CharacterSelected;
        selectedCharacter = character;
    }

    private void OnTileClicked(HexCell tile)
    {
        tile.character = selectedCharacter;
        selectedCharacter.MoveToTile(tile);
        selectedCharacter = null;

        currentState = TargetState.Normal;
    }
}
