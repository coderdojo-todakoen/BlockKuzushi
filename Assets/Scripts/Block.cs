using UnityEngine;

public class Block : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        // ボールに触れたブロックは、消去します
        Destroy(gameObject);
    }
}
