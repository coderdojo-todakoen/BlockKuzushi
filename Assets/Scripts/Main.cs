using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // ブロックの初期配置をおこないます
        MakeBlocks();
    }

    // ブロックの初期配置をおこないます
    private void MakeBlocks()
    {
        // ブロックのプレハブを読み込みます
        GameObject block = Resources.Load<GameObject>("Prefabs/Block");

        // ブロックを6段に10個ずつ並べます
        for (int y = 0; y != 6; ++y)
        {
            for (int x = 0; x != 10; ++x)
            {
                // ブロックの位置を計算します
                Vector2 position = new Vector2(x * 1.2f - 5.4f, 3.5f - y * 0.4f);
                // ブロックを作成します
                Instantiate(block, position, Quaternion.identity);
            }
        }
    }
}
