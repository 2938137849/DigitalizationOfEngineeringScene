using System;
using System.Collections;

using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 移动指令
/// </summary>
internal class MoveItemBox : ItemBox {
	/// <summary>
	/// 下拉框
	/// </summary>
	public Dropdown dropDown;
	/// <summary>
	/// 输入框
	/// </summary>
	public InputField inputField;
	/// <summary>
	/// 指令移动对象保存
	/// </summary>
	private PlayerControl player;
	/// <summary>
	/// 移动方向保存
	/// </summary>
	private int value = 0;
	/// <summary>
	/// 速度保存
	/// </summary>
	private float speed;

	protected override void Start() {
		base.Start();
		this.speed = DataManager.instance.speed;
		if (!this.dropDown) {
			this.dropDown = this.GetComponentInChildren<Dropdown>();
		}
		if (!this.inputField) {
			this.inputField = this.GetComponentInChildren<InputField>();
		}
		this.player = DataManager.instance.player;
	}
	/// <summary>
	/// 当移动方向被改变时调用
	/// </summary>
	public void OnValueChanged() {
		this.value = this.dropDown.value;
		//print(dropDown.value);
		//print(dropDown.captionText.text);
	}
	public override IEnumerator Run() {
		print($"MoveItemBox: {this.Index}");
		this.player.body.velocity = this.GetSpeedVector(this.speed);
		var text = this.inputField.text;
		float second = 0;
		if (text.Length > 0 && text != ".") {
			second = Convert.ToSingle(this.inputField.text);
		}
		yield return new WaitForSeconds(second);
		this.player.body.velocity = Vector3.zero;
	}

	public override IEnumerator Back() {
		print($"MoveItemBox:Back {this.Index}");
		this.player.body.velocity = this.GetSpeedVector(-this.speed);
		var text = this.inputField.text;
		float second = 0;
		if (text.Length > 0 && text != ".") {
			second = Convert.ToSingle(this.inputField.text);
		}
		yield return new WaitForSeconds(second);
		this.player.body.velocity = Vector3.zero;
	}
	/// <summary>
	/// 获取移动速度对应的矢量
	/// </summary>
	/// <param name="speed">移动速度</param>
	/// <returns></returns>
	public Vector3 GetSpeedVector(float speed) {
		switch (this.value) {
			case 0:
				return new Vector3(0, 0, speed);
			case 1:
				return new Vector3(0, 0, -speed);
			case 2:
				return new Vector3(-speed, 0, 0);
			case 3:
				return new Vector3(speed, 0, 0);
			default:
				return Vector3.zero;
		}
	}
}

