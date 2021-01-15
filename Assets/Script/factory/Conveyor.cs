using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Conveyor : MonoBehaviour {
	public Transform start;

	public List<GameObject> items;

	void Update() {
		foreach (GameObject item in items) {
			item.transform.position =
					Vector3.MoveTowards(
						item.transform.position,
						start.position,
						DataManager.instance.speed
					);
		}
	}
}
