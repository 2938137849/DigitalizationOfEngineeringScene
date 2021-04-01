using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ObjMove : MonoBehaviour {
	// Start is called before the first frame update
	[System.Serializable]
	public class Path {
		public Transform point;
		public float MoveTime;
		public float waitTime;
		[HideInInspector]
		public Vector3 speed3;
	}

	public int speed = 10;
	public Path[] path = new Path[0];
	private int id;
	void Start() {
		//让移动的物体的位置更变为第一个点的位置
		transform.position = path[0].point.position;
		//计算出每两个点之间的速度-speed
		for (int i = 1; i < path.Length; i++) {
			path[i].speed3 = (path[i].point.position - path[i - 1].point.position) / path[i].MoveTime;
		}
	}

	void Update() {
		if (id >= path.Length) {
			return;
		}
		Path p = path[id];
		//当移动的时间大于0时让物体向下一个点移动
		if (p.MoveTime > 0) {
			p.MoveTime -= Time.deltaTime;
			transform.position += p.speed3 * Time.deltaTime;
		} else {
			//当等待的时间大于0时，物体停止不动等待时间归零
			transform.position = p.point.position;
			if (p.waitTime > 0) {
				p.waitTime -= Time.deltaTime;
			} else {
				id++;
			}
		}
	}

	// 辅助线
	void OnDrawGizmos() {
		Gizmos.color = Color.red;
		for (int i = 1; i < path.Length; i++) {
			Gizmos.DrawLine(path[i - 1].point.position, path[i].point.position);
		}
	}
}
