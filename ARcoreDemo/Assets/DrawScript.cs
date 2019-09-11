using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class DrawScript : MonoBehaviour
{
    // 描くオブジェクトの元データ
    public GameObject obj;

    // 実際の描画に使うオブジェクト
    private GameObject drawObj;

    List<GameObject> lines = new List<GameObject>();

    void Update()
    {
        if(Input.touchCount == 1)
        {
            // カメラ手前10cmの位置を取得
            Vector3 pos = Camera.main.transform.TransformPoint(0, 0, 0.1f);

            // タッチスタート
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                //drawObj = Instantiate(obj, pos, Quaternion.identity);
                GameObject tmp = Instantiate(obj, pos, Quaternion.identity);
                lines.Add(tmp);
                drawObj = tmp;
            }

            // スワイプ中
            else if(Input.GetTouch(0).phase == TouchPhase.Stationary)
            {
                drawObj.transform.position = pos;
            }
        }
        else if(Input.touchCount == 2)
        {
            // 線を消す
            if(Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                for(int i = 0;i < lines.Count; i++)
                {
                    Destroy(lines[i]);
                    lines[i] = null;
                }
                lines.Clear();
            }
        }

    }
}
