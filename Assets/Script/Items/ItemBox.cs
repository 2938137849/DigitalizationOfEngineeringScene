using System.Collections;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary>
/// 所有指令基类,空指令
/// </summary>
public class ItemBox : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {
	/// <summary>
	/// 文本
	/// </summary>
	public Text m_text;

	protected float topPadding, spacing, height;
	protected int sibling;
	/// <summary>
	/// 由于需要设置空指令位置,保存指令控制类
	/// </summary>
	protected TestItem test;
	/// <summary>
	/// TODO
	/// </summary>
	protected LayoutElement layout;
	/// <summary>
	/// 储存行数,同时设置行数显示
	/// </summary>
	public int Index {
		get {
			return this._index;
		}
		set {
			this.m_text.text = $"{value}";
			this._index = value;
		}
	}
	private int _index;

	protected virtual void Start() {
		this.test = DataManager.instance.testItem;
		this.layout = this.GetComponent<LayoutElement>();
		this.test.AddItem(this);
	}
	private void OnEnable() {
		this.topPadding = this.transform.parent.GetComponent<VerticalLayoutGroup>().padding.top;
		this.spacing = this.transform.parent.GetComponent<VerticalLayoutGroup>().spacing;
		this.height = this.GetComponent<RectTransform>().sizeDelta.y;
	}
	/// <summary>
	/// 拖动时调用
	/// </summary>
	/// <param name="eventData"></param>
	public void OnDrag(PointerEventData eventData) {
		this.transform.position = new Vector3(this.transform.position.x, eventData.position.y, this.transform.position.z);
		this.sibling = -(int)((this.transform.localPosition.y - this.topPadding + 10) / (this.height + this.spacing));
		this.test.SetEmpty(this.sibling);
	}
	/// <summary>
	/// 开始拖动时调用
	/// </summary>
	/// <param name="eventData"></param>
	public void OnBeginDrag(PointerEventData eventData) {
		this.transform.SetAsLastSibling();
		this.layout.ignoreLayout = true;
	}
	/// <summary>
	/// 结束拖动时调用
	/// </summary>
	/// <param name="eventData"></param>
	public void OnEndDrag(PointerEventData eventData) {
		this.transform.SetSiblingIndex(this.sibling);
		this.test.DeActiveEmpty();
		this.layout.ignoreLayout = false;
	}
	/// <summary>
	/// 运行时
	/// </summary>
	/// <returns></returns>
	public virtual IEnumerator Run() {
		print($"ItemBox:Run {this.Index}");
		yield return 0;
	}
	/// <summary>
	/// 回退时
	/// </summary>
	/// <returns></returns>
	public virtual IEnumerator Back() {
		print($"ItemBox:Back {this.Index}");
		yield return 0;
	}
	/// <summary>
	/// 移除自身
	/// </summary>
	public void Remove() {
		this.test.RemoveItem(this);
	}
}
