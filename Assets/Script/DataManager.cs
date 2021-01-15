
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 游戏内唯一脚本对象类
/// </summary>
public class DataManager : MonoBehaviour {
	public static DataManager instance;

	/// <summary>
	/// 主要指令存放对象
	/// </summary>
	public TestItem testItem;
	/// <summary>
	/// 玩家对象
	/// </summary>
	public PlayerControl player;
	/// <summary>
	/// 运动速度统一控制
	/// </summary>
	public float speed = 10;
	/// <summary>
	/// 停止按钮
	/// </summary>
	public Button stopButton;
	/// <summary>
	/// 回退按钮
	/// </summary>
	public Button BackButton;
	/// <summary>
	/// 连续运行按钮
	/// </summary>
	public Button RunButton;
	/// <summary>
	/// 进位按钮
	/// </summary>
	public Button NextButton;

	public Transform TaskItem;
	public GameObject TargetItem;
	/// <summary>
	/// 快速设置按钮不可用
	/// </summary>
	public bool ButtonEnable {
		set {
			this.stopButton.interactable = value;
			this.BackButton.interactable = value;
			this.RunButton.interactable = value;
			this.NextButton.interactable = value;
		}
	}
	private void Start() {
		this.stopButton.onClick.AddListener(this.ReStartLogic);
		this.BackButton.onClick.AddListener(this.RunBackLogic);
		this.RunButton.onClick.AddListener(this.RunLogic);
		this.NextButton.onClick.AddListener(this.RunNextLogic);
	}
	public void Awake() {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		} else if (instance != this) {
			Destroy(this.gameObject);
		}
	}
	/// <summary>
	/// 提供游戏内调用,传入prefab,新建实例
	/// </summary>
	/// <param name="prefab">游戏内保存的prefab</param>
	public void CreateItemBox(GameObject prefab) {
		Instantiate(prefab, this.testItem.transform);
	}
	/// <summary>
	/// 重设场景
	/// </summary>
	public void ReStartLogic() {
		this.player.transform.position = this.player.startPosition;
		this.testItem.Index = 0;
	}
	/// <summary>
	/// 连续运行指令
	/// </summary>
	public void RunLogic() {
		this.ButtonEnable = false;
		this.testItem.RunLogic(RunType.Run);
	}
	/// <summary>
	/// 回退运行指令
	/// </summary>
	public void RunBackLogic() {
		this.ButtonEnable = false;
		this.testItem.RunLogic(RunType.RunBack);
	}
	/// <summary>
	/// 进位运行指令
	/// </summary>
	public void RunNextLogic() {
		this.ButtonEnable = false;
		this.testItem.RunLogic(RunType.RunNext);
	}

	public GameObject AddTask(GameObject prefab) {
		return Instantiate(prefab, TaskItem);
	}
	public void AddRandomTask() {
		var x = Random.Range(-10, 10);
		var z = Random.Range(-10, 10);
		Instantiate(TargetItem).transform.position = new Vector3(x, 1, z);
	}
}
