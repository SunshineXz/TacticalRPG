using UnityEngine;
using UnityEngine.UIElements;

public class HexCell : MonoBehaviour {

	public HexCoordinates coordinates;

	public Color color;

    private GameManager manager;

    public Character character;

    [SerializeField]
	HexCell[] neighbors;

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

    public void Update()
    {
        if (manager.GetState() == CharacterTargetSystem.TargetState.CharacterSelected)
        {
            CheckRayCast();
        }
    }

    public Character Chararacter { get; internal set; }

    void CheckRayCast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit info;
        Collider coll = GetComponent<Collider>();
        if (coll.Raycast(ray, out info, 1000))
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
        ChangeColor(new Color(0,0.5f,1));
    }

    private void OnTileClicked()
    {
        ChangeColor(new Color(0, 1, 0.5f, 1));
    }

    public void ChangeColor(Color c)
    {
        color = c;
        GameManager.GetInstance().Triangulate();
    }
}