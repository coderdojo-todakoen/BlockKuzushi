using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // マウスの方向にパドルを移動する処理をおこないます

        // マウスの位置を取得します
        Vector3 mousePosition = Input.mousePosition;
        // マウスの位置はスクリーン座標なので、ゲーム内のワールド座標へ変換します
        Vector3 position = Camera.main.ScreenToWorldPoint(mousePosition);

        // 両端の壁を超えないようにx座標を調整し、y方向・z方向へは移動しないようにします
        position.x = Mathf.Max(Mathf.Min(5.2f, position.x), -5.2f);
        position.y = transform.position.y;
        position.z = transform.position.z;
        
        // マウスから少し遅れてパドルが移動するように見せるため
        // 現在の位置からマウスの方向に1/10の距離だけ移動します
        Vector3 newPosition = Vector3.Lerp(transform.position, position, 0.1f);
        transform.position = newPosition;
    }
}
