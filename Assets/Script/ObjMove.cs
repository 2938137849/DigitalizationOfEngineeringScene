using UnityEngine;
/// <summary>
/// 移动方块类,这个是计算机院写的代码,自己改动了大部分
/// </summary>
public class ObjMove : MonoBehaviour {
	/// <summary>
	/// 内部类,path节点
	/// </summary>
	/// 设置可在unity编辑器中编辑
	[System.Serializable]
	public class Path {
		/// <summary>
		/// 节点位置
		/// </summary>
		public Transform point;
		/// <summary>
		/// 移动时间
		/// </summary>
		public float MoveTime;
		/// <summary>
		/// 移动结束后等待时间
		/// </summary>
		public float waitTime;
		/// <summary>
		/// 移动速度
		/// </summary>
		/// 在unity编辑器中隐藏
		[HideInInspector]
		public Vector3 speed3;
	}
	/// <summary>
	/// 不可以移动
	/// </summary>
	public bool CantMove;
	/// <summary>
	/// 走完全部节点后显示的对象
	/// </summary>
	public GameObject Complate;
	/// <summary>
	/// 节点数组
	/// </summary>
	public Path[] path = new Path[0];
	/// <summary>
	/// 当前节点下标
	/// </summary>
	private int id;
	/// <summary>
	/// 开始时
	/// </summary>
	void Start() {
		//让移动的物体的位置更变为第一个点的位置
		transform.position = path[0].point.position;
		//计算出每两个点之间的速度,并设置进speed3
		for (int i = 1; i < path.Length; i++) {
			path[i].speed3 = (path[i].point.position - path[i - 1].point.position) / path[i].MoveTime;
		}
	}
	/// <summary>
	/// 更新时
	/// </summary>
	void Update() {
		// 如果不可用移动,提前返回
		if (CantMove) return;
		// 如果当前节点下标大于节点长度
		if (id >= path.Length) {
			// 显示走完节点后显示的对象
			Complate.SetActive(true);
			// 销毁自身对象
			Destroy(this.gameObject);
			// 提前返回
			return;
		}
		// 临时变量:当前节点
		Path p = path[id];
		//当移动的时间大于0时让物体向下一个点移动
		if (p.MoveTime > 0) {
			// 移动时间减去世界变化的时间
			p.MoveTime -= Time.deltaTime;
			// 移动物体的位置加上speed3*世界变化的时间
			transform.position += p.speed3 * Time.deltaTime;
		} else {
			// 物体的位置设置为节点的位置
			transform.position = p.point.position;
			// 当等待的时间大于0时，物体停止不动等待时间归零
			if (p.waitTime > 0) {
				// 等待时间减去时间变化的时间
				p.waitTime -= Time.deltaTime;
			} else {
				// 等待世界结束,下一个节点
				id++;
			}
		}
	}

	/// <summary>
	/// 绘制辅助线
	/// </summary>	
	void OnDrawGizmos() {
		// 当path节点长度为0时提前返回
		if (path.Length == 0) return;
		// 当第一个节点没有设置当前位置时提前返回
		if (this.path[0].point == null) return;
		// 设置辅助线颜色为红色
		Gizmos.color = Color.red;
		// 循环取节点
		for (int i = 1; i < path.Length; i++) {
			// 如果当前节点没有设置当前位置时提前返回
			if (path[i].point == null) return;
			// 绘制辅助线:从前一个节点到当前节点
			Gizmos.DrawLine(path[i - 1].point.position, path[i].point.position);
		}
	}
}
