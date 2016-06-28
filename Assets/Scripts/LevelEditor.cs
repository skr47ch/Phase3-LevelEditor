using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelEditor : MonoBehaviour {

	public GameObject grid;
	Vector2 mapSize;

	Vector2 worldOrigin;
	Vector2 gridSize;

	bool state, calledLong, gridVisible;
	float timer, timeForLongPress = 1;

	List<GameObject> gridList = new List<GameObject>() ;

	// Use this for initialization
	void Start () {
		CalculateGridSize();
		CalculateWorldOrigin();
		MakeGrid();
	}

	void Update () {

		GridHandler();

	}

	void GridHandler () {
		if(Input.GetMouseButtonDown(0)) {
			state = true;
			// Call instantly when clicked
		}

		if(state) {
			// Call when mouse button is held
			timer += Time.deltaTime;
			if(timer > timeForLongPress) {
				// Call each frame
				if(!calledLong) {
					calledLong = true;
					// Call once
					ToggleGrid();
				}
			}
		}

		if(Input.GetMouseButtonUp(0)) {
			timer = 0	;
			calledLong = false;
			state = false;
		}
	}

	void CalculateGridSize () {
		gridSize = new Vector2(grid.GetComponent<SpriteRenderer>().bounds.size.x, grid.GetComponent<SpriteRenderer>().bounds.size.y);
	}

	void CalculateWorldOrigin () {
		Vector2 screenDimensions = new Vector2(Camera.main.aspect * Camera.main.orthographicSize * 2, Camera.main.orthographicSize * 2);

		float remainderX = screenDimensions.x%gridSize.x;
		float remainderY = screenDimensions.y%gridSize.y;

		mapSize = new Vector2((int)(screenDimensions.x/gridSize.x), (int)(screenDimensions.y/gridSize.y));

		worldOrigin = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
		worldOrigin.x += remainderX/2;
		worldOrigin.y += remainderY/2;

	}

	void MakeGrid() {
		Vector2 pos = new Vector2(0, 0);

		for (int i = 0; i < mapSize.x; i ++) {
			for (int j = 0; j < mapSize.y; j ++) {
				GameObject newGrid = (GameObject) Instantiate(grid, worldOrigin + pos, transform.localRotation);
				gridList.Add(newGrid);
				pos.y += gridSize.y;
			}
			pos.x += gridSize.x;
			pos.y = 0;
		}
	}

	void ToggleGrid() {
		foreach (GameObject gameObject in gridList) {
			if(gameObject.GetComponent<SpriteRenderer>().enabled) {
				gameObject.GetComponent<SpriteRenderer>().enabled = false;
				Handheld.Vibrate();
			}
			else {
				gameObject.GetComponent<SpriteRenderer>().enabled = true;
				Handheld.Vibrate();
			}
		}
	}
}


