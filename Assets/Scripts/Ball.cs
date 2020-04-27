using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // パドル・ブロック・壁にあたった時に鳴らす音
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // 画面の中央にボールを表示してから、ボールを動かします
        MoveCenterAndStart();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // パドル・ブロック・壁のいずれかにあたったら
        // 効果音を再生します
        audioSource.Play();
    }

    void OnTriggerExit2D(Collider2D other) {
        // 下の壁だけ、コライダのIsTriggerがtrueになっているため
        // ボールが跳ね返らずに通過します。
        // 下の壁を通り抜けたら、この関数が呼び出されるので
        // 画面の中央へボールを戻します
        MoveCenterAndStart();
    }

    public void MoveCenterAndStart()
    {
        // 指定時間経過後、画面の中央へボールを戻すため
        // コルーチンを呼び出します
        StartCoroutine("Restart");
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(3);

        // 画面の中央へボールを移動します
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().MovePosition(new Vector2(0, -1));

        yield return new WaitForSeconds(1);

        // 右上方向へボールを動かします
        GetComponent<Rigidbody2D>().AddForce(new Vector2(250, 250));
    }
}
