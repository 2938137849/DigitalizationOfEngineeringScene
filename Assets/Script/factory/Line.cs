using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Line : MonoBehaviour {
	public Transform cubeTrans;   //得到cube的transform
	public Vector3[] point;
	private int index;
	private Vector3 beginValue;
	private Vector3 endValue;
	// Start is called before the first frame update
	void Start() {
		beginValue = point[index];
		endValue = point[index];
	}

	// Update is called once per frame
	void Update() {
		cubeTrans.position = beginValue;
		if (beginValue == endValue) {
			if (index + 1 == point.Length) {
				Destroy(gameObject);
				return;
			}
			index++;
			endValue = point[index];
			ControllerCube();
		}
	}

	public void ControllerCube() {
		//DOTween自带的方法：对变量做一个动画（通过插值的方式修改一个值得变化） 要使用 using DG.Tweening; 命名空间
		//第一个参数：使用了 C# 的Lambda语法，对 myValue 值进行修改，返回 myValue
		//第二个：也使用 Lambda 语法，把修改的值赋给 myValue，x是DOTween计算好的一个值
		//第三个：目标值，就是 myValue 最后要变化到的值
		//第四个：变化到目标值需要的时间
		DOTween.To(() => beginValue, x => beginValue = x, endValue, 2).SetEase(Ease.Linear);
	}
}
