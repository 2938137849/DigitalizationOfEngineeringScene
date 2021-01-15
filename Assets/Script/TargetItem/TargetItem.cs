using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class TargetItem : MonoBehaviour {
	public GameObject cube;
	public GameObject task;


	private void Start() {
		task = DataManager.instance.AddTask(task);
		task.GetComponent<TargetTask>().Target = $"{transform.position.x},{transform.position.z}";
	}
	private void Update() {
		cube.transform.RotateAround(transform.position, Vector3.up, 2);
	}

	private void OnTriggerEnter(Collider other) {
		Destroy(task);
		Destroy(gameObject);
	}
}
