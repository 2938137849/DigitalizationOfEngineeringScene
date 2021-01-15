
using UnityEngine;
/// <summary>
/// 玩家控制类
/// </summary>
public class PlayerControl : MonoBehaviour {
	/// <summary>
	/// 物理类
	/// </summary>
	public Rigidbody body;
	/// <summary>
	/// 初始位置
	/// </summary>
	public Vector3 startPosition;
	/// <summary>
	/// 移动速度
	/// </summary>
	private float speed;

	private void Start() {
		this.speed = DataManager.instance.speed;
		this.startPosition = this.transform.position;
	}

	private void Update() {
		var x = Input.GetButton(nameof(Axis.Horizontal)) ? Input.GetAxisRaw(nameof(Axis.Horizontal)) : 0;
		var z = Input.GetButton(nameof(Axis.Vertical)) ? Input.GetAxisRaw(nameof(Axis.Vertical)) : 0;

		this.body.velocity = new Vector3(x * speed, 0, z * speed);

	}

	private void OnTriggerEnter(Collider other) {
		
	}
}

internal enum Axis {
	Horizontal,
	Vertical
}



///方案
///一个完整的关卡
///任务
///
///画面