using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // ��� ���͸���
    public Material bgMaterial;

    // ��ũ�� �ӵ�
    public float scrollSpeed = 0.2f;

    void Start()
    {
        
    }

    // 1. ��� �ִ� ���� ��� �ϰ� �ʹ�.
    void Update()
    {
        //2. ������ �ʿ��ϴ�.
        Vector2 direction = Vector2.down;

        //3. ��ũ���ϰ� �ʹ�. P = P0 + vt
        bgMaterial.mainTextureOffset += direction * scrollSpeed * Time.deltaTime;
        
    }
}
