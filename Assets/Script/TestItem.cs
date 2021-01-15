using System.Collections;
using System.Collections.Generic;

using UnityEngine;
/// <summary>
/// 指令统一控制类
/// </summary>
public class TestItem : MonoBehaviour {
	//public event Func<ItemBox> Test {
	//	add {
	//		AddItem(value());
	//	}
	//	remove {
	//		RemoveItem(value());
	//	}
	//}

	/// <summary>
	/// 空的指令预制体
	/// </summary>
	public GameObject emptyPrefab;
	/// <summary>
	/// 保存的唯一空指令实例对象
	/// </summary>
	private GameObject e_button;
	/// <summary>
	/// 指令列表,新建指令时自行添加进这个列表
	/// </summary>
	private List<ItemBox> items = new List<ItemBox>();
	/// <summary>
	/// 保存指令运行的当前位置
	/// </summary>
	public int Index { get; set; }
	public void Start() {
		this.e_button = Instantiate(this.emptyPrefab, this.transform);
		this.e_button.SetActive(false);
	}
	/// <summary>
	/// 设置空指令所在位置
	/// </summary>
	/// <param name="index">从上往下的位置,从0开始</param>
	public void SetEmpty(int index) {
		this.e_button.transform.SetSiblingIndex(index);
		this.e_button.SetActive(true);
	}
	/// <summary>
	/// 隐藏空指令
	/// </summary>
	public void DeActiveEmpty() {
		this.e_button.SetActive(false);
		this.e_button.transform.SetSiblingIndex(0);
		this.ResetItemIndex();
	}
	/// <summary>
	/// 指令新建时,调用这个函数将指令添加到列表中存储
	/// </summary>
	/// <param name="item">指令自身</param>
	public void AddItem(ItemBox item) {
		this.items.Add(item);
		item.Index = this.items.Count;
	}
	/// <summary>
	/// 隐形空指令时,由于修改了指令顺序,直接重新刷新一遍指令的行数显示
	/// </summary>
	public void ResetItemIndex() {
		foreach (var item in this.items) {
			item.Index = item.transform.GetSiblingIndex();
		}
	}
	/// <summary>
	/// 删除指令时,调用这个方法删除指令自身
	/// </summary>
	/// <param name="itemBox">指令自身</param>
	public void RemoveItem(ItemBox itemBox) {
		this.items.Remove(itemBox);
		Destroy(itemBox.gameObject);
	}
	/// <summary>
	/// 按传入运行方式运行指令
	/// </summary>
	/// <param name="runType">控制指令运行方式</param>
	public void RunLogic(RunType runType) {
		switch (runType) {
			case RunType.Run:
				this.items.Sort((item1, item2) => {
					return item1.transform.GetSiblingIndex() - item2.transform.GetSiblingIndex();
				});
				this.StartCoroutine(this.Run());
				break;
			case RunType.RunBack:
				this.StartCoroutine(this.RunBack());
				break;
			case RunType.RunNext:
				this.StartCoroutine(this.RunNext());
				break;
		}
	}
	/// <summary>
	/// 顺序运行
	/// </summary>
	/// <returns></returns>
	private IEnumerator Run() {
		for (; this.Index < this.items.Count; this.Index++) {
			yield return this.items[this.Index].Run();
		}
		DataManager.instance.ButtonEnable = true;
	}
	/// <summary>
	/// 回退运行
	/// </summary>
	/// <returns></returns>
	public IEnumerator RunBack() {
		if (this.Index > 0) {
			this.Index--;
			yield return this.items[this.Index].Back();
		} else {
			print($"{this.Index} < 0");
		}
		DataManager.instance.ButtonEnable = true;
	}
	/// <summary>
	/// 运行下一个指令
	/// </summary>
	/// <returns></returns>
	public IEnumerator RunNext() {
		if (this.Index < this.items.Count) {
			yield return this.items[this.Index++].Run();
		} else {
			print($"{this.Index} > items.Count");
		}
		DataManager.instance.ButtonEnable = true;
	}
}
/// <summary>
/// 运行类型
/// </summary>
public enum RunType {
	/// <summary>
	/// 正常运行指令
	/// </summary>
	Run,
	/// <summary>
	/// 回退运行指令
	/// </summary>
	RunBack,
	/// <summary>
	/// 运行下一个指令
	/// </summary>
	RunNext
}