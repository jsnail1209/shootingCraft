using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ǥ: ���� �ٸ� ��ü�� �浹���� �� ���� ȿ���� �߻���Ű�� �ʹ�.
// ���� 1. ���� �ٸ� ��ü�� �浹�����ϱ�.
//      2. ���� ȿ�� ���忡�� ���� ȿ���� �ϳ� ������ �ѵ�.
//      3. ���� ȿ���� �߻�(��ġ)��Ű�� �ʹ�.
// �ʿ� �Ӽ�: ���� ���� �ּ�(�ܺο��� ���� �־��ش�)
public class Enemy : MonoBehaviour
{

	// �ʿ� �Ӽ�: �̵� �ӵ�
	public float speed = 5;

    GameObject player;

    // ������ ���� ������ ����� Start�� Update���� ���
    Vector3 dir;

    // �浹 ����(1. ���� �ٸ� ��ü�� �浹�����ϱ�.)
    private void OnCollisionEnter(Collision collision)
    {
        //2. ���� ȿ�� ���忡�� ���� ȿ���� �ϳ� ������ �Ѵ�.
        GameObject explosion = Instantiate(explosionFactory);

        //3. ���� ȿ���� �߻�(��ġ)��Ű�� �ʹ�.
        explosion.transform.position = transform.position;
        
        Destroy(collision.gameObject);
        Destroy(gameObject);

    }

    //���� ���� �ּ�(�ܺο��� ���� �־��ش�)
    public GameObject explosionFactory;

    void Start()
    {
        
        // 0���� 9���� 10���� �� �߿� �ϳ��� �������� �����´�.
        int randValue = UnityEngine.Random.Range(0, 3);
        // ���� 3���� ������ �÷��̾� ����
        if (randValue < 3)
        {
            // �÷��̾ ã�� target���� �ϰ� �ʹ�.
            GameObject target = GameObject.Find("Player");
            // ������ ���ϰ� �ʹ�. target-me
            dir = target.transform.position - transform.position;
            // ������ ũ�⸦ 1�� �ϰ� �ʹ�.
            dir.Normalize();

        }
        // �׷��� ������ �Ʒ� �������� ���ϰ� �ʹ�.
        else
        {
            dir = Vector3.down;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 1. ������ ���Ѵ�.
        // Vector3 dir = Vector3.down;
		transform.position += dir * speed * Time.deltaTime;

    }

}
