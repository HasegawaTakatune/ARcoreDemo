using GoogleARCore;
using UnityEngine;

public class PutScript : MonoBehaviour
{
    public GameObject andy;

    private void Update()
    {
        // タッチしていないなら戻る
        if (Input.touchCount < 1) return;
        Touch touch = Input.GetTouch(0);

        // 画面をスワイプしていなければ戻る
        if (touch.phase != TouchPhase.Moved) return;

        // タップした座標が平面か判定する
        TrackableHit hit;
        TrackableHitFlags filter = TrackableHitFlags.PlaneWithinPolygon;
        if(Frame.Raycast(touch.position.x, touch.position.y, filter, out hit))
        {
            // 平面にヒットしたら位置・姿勢を指定
            andy.transform.position = hit.Pose.position;
            andy.transform.rotation = hit.Pose.rotation;
            andy.transform.Rotate(0, 180, 0, Space.Self);

            // Anchorを設定
            Anchor anchor = hit.Trackable.CreateAnchor(hit.Pose);
            andy.transform.parent = anchor.transform;
            // ※Anchor設定は指を離した時だけで十分。
        }
    }
}
