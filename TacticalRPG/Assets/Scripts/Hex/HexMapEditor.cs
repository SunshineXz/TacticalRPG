using UnityEngine;
using UnityEngine.EventSystems;

public class HexMapEditor : MonoBehaviour {

	public Color[] colors;

	public HexGrid hexGrid;

	private Color activeColor;

	private GameManager gameManager;

	void Awake () {
		SelectColor(0);
	}

	private void Start()
	{
		gameManager = GameManager.GetInstance();
	}

	void Update () {
		if (
			Input.GetMouseButton(0) &&
			!EventSystem.current.IsPointerOverGameObject() &&
			gameManager.characterTargetSystem.currentState == CharacterTargetSystem.TargetState.Normal
		) {
			HandleInput();
		}
	}

	void HandleInput () {
		Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(inputRay, out hit)) {
			hexGrid.ColorCell(hit.point, activeColor);
		}
	}

	public void SelectColor (int index) {
		activeColor = colors[index];
	}
}