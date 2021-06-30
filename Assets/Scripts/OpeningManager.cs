using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpeningManager : MonoBehaviour
{
  public Text titletext;
  public Text clicktext;
  private float textColor;
  private float time;
  private float rotateSpeed = 5.0f;
  //　スカイボックスのマテリアル
  private Material skyboxMaterial;

    // Start is called before the first frame update
    void Start()
    {
    //   textColor = 0.0f;
    skyboxMaterial = RenderSettings.skybox;
    }

    // Update is called once per frame
    void Update()
    {
      //徐々にテキストの文字色を浮かび上がらせる
    //   if(textColor <= 1){
    //     textColor += 0.01f;
    //     titletext.color = new Color(255, 255, 255, textColor);
    //   }
        skyboxMaterial.SetFloat("_Rotation", Mathf.Repeat(skyboxMaterial.GetFloat("_Rotation") + rotateSpeed * Time.deltaTime, 360f));

        clicktext.color=GetColor(clicktext.color);
        if (Input.touchCount > 0 ){
            SceneManager.LoadScene("GameScene");
        }

    }
    Color GetColor(Color color){
        time+=Time.deltaTime*5.0f*0.5f;
        color.a=Mathf.Sin(time);

        return color;
    }
    
}