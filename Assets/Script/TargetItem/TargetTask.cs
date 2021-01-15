using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
public class TargetTask : MonoBehaviour {
	public Text text;

	public string Target {
		set {
			text.text = $"任务:移动到点 ({value})";
		}
	}


}
