using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    // ���� �ȿ� �ٸ� ��ü�� ������ ���
    private void OnTriggerEnter(Collider other)
    {
        // �� ��ü�� ���ְ� �ʹ�.
        Destroy(other.gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
