using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoCirecle : MonoBehaviour
{
    public Transform cubeTrans;
    public int rotate;
    // Start is called before the first frame update
    void Start()
    {
        ControllerCube();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ControllerCube()
    {
        
        cubeTrans.DORotate(new Vector3(0, rotate, 0), 10).SetEase(Ease.Linear);
    }
}
