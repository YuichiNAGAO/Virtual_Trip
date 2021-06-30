using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetCompass : MonoBehaviour
{
    void Start()
    {
        Input.compass.enabled = true;
        Input.location.Start(); //位置情報有効化
    }
    void Update()
    {
        // Orient an object to point to magnetic north.
        transform.rotation = Quaternion.Euler(0, -Input.compass.magneticHeading, 0);
    }
}




 
public class Compass : MonoBehaviour
{
	[SerializeField]
	private RectTransform m_root;
 
	[SerializeField]
	private Text m_trueHeading;
 
    void Start()
    {
        Input.compass.enabled = true;
		Input.location.Start();
    }
 
    void Update ()
    {
    	m_root.rotation = Quaternion.Euler(0, 0, Input.compass.trueHeading);
		m_trueHeading.text = ((int)Input.compass.trueHeading).ToString() + "°";
    }
}
