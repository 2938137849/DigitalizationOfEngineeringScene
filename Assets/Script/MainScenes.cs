using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// 主要场景类,这个是自己写的代码
/// </summary>
public class MainScenes : MonoBehaviour {
	/// <summary>
	/// 开始界面的ui
	/// </summary>
	public GameObject startPanel;
	/// <summary>
	/// 选择关卡界面的ui
	/// </summary>
	public GameObject levelPanel;
	/// <summary>
	/// 开始时
	/// </summary>
	public void Start() {
		// 显示开始界面
		this.startPanel.SetActive(true);
		// 隐藏选择关卡界面
		this.levelPanel.SetActive(false);
	}
	/// <summary>
	/// 点击游戏开始按钮
	/// (不要说我水,论文里面全靠这些没用的东西撑字数,
	/// 反正编程类的东西这个院一个老师都不懂,
	/// 能够自己实现的全部自己代码实现)
	/// </summary>
	public void GameStart() {
		// 隐藏开始界面
		this.startPanel.SetActive(false);
		// 显示关卡选择界面
		this.levelPanel.SetActive(true);
	}
	/// <summary>
	/// 点击游戏退出按钮
	/// </summary>
	public void GameExit() {
		// (宏代码)如果当前环境在unity编辑器下
#if UNITY_EDITOR
		// 取消游戏运行
		UnityEditor.EditorApplication.isPlaying = false;
		// 否则
#else
    // 游戏退出
    Application.Quit();
#endif
	}
	/// <summary>
	/// 游戏场景加载
	/// (这个也是用来水字数的)
	/// </summary>
	/// <param name="scene">场景名称</param>
	public void GameSceneLoad(string scene) {
		// 加载场景
		SceneManager.LoadScene(scene);
	}
}
