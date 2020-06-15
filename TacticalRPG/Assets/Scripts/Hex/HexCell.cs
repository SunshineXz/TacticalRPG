using System;
using UnityEngine;
using UnityEngine.UIElements;

public class HexCell : MonoBehaviour {
    public enum TileState
    {
        None,
        ShowingRange
    }
	public HexCoordinates coordinates;

	public Color color;

    private GameManager manager;

    public Character character;

    [SerializeField]
	HexCell[] neighbors;

    public TileState State;

	public HexCell GetNeighbor (HexDirection direction) {
		return neighbors[(int)direction];
	}

	public void SetNeighbor (HexDirection direction, HexCell cell) {
		neighbors[(int)direction] = cell;
		cell.neighbors[(int)direction.Opposite()] = this;
	}

    public void Start()
    {
        manager = GameManager.GetInstance();
    }

    public Character Chararacter { get; internal set; }

    private void OnMouseOver()
    {
        if (manager.GetState() == CharacterTargetSystem.TargetState.CharacterSelected)
        {
            ChangeColor(new Color(0, 0.5f, 1));
        }
    }

    private void OnMouseExit()
    {
        if (manager.GetState() == CharacterTargetSystem.TargetState.CharacterSelected)
        {
            switch(State)
            {
                case TileState.None:
                    ChangeColor(Color.white);
                    break;
                case TileState.ShowingRange:
                    ChangeColor(new Color(0, 1, 0.5f));
                    break;
            }
        }
    }

    public void ChangeColor(Color c)
    {
        color = c;
    }

    public void ShowPossibleMoves(int depth)
    {
        if(State != TileState.ShowingRange)
        {
            ChangeColor(new Color(0, 1, 0.5f, 1));
            State = HexCell.TileState.ShowingRange;
        }

        if (depth == 0)
        {
            return;
        }

        foreach (HexDirection direction in Enum.GetValues(typeof(HexDirection)))
        {
            var neighbor = GetNeighbor(direction);
            if (neighbor != null)
            {
                neighbor.ShowPossibleMoves(depth - 1);
            }
        }
    }
}