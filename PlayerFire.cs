using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // ���� �ð�
    float currentTime;

    // ���� �ð�
    public float createTime = 1;

    // �ּ� �ð�
    float minTime = 0.5f;

    // �ִ� �ð�
    float maxTime = 1;

    // �Ѿ��� ������ ����
    public GameObject bulletFactory;
	
	// �ѱ�
	public GameObject firePosition;
	// Start is called before the first frame update
    void Start()
    {
        // �¾ �� ���� ���� �ð��� �����ϰ�
        createTime = UnityEngine.Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()

    {
        // 1. �ð��� �帣�ٰ�
        currentTime += Time.deltaTime;

        // 2. ���� ���� �ð��� ���� �ð��� �Ǹ�
        if (currentTime > createTime | Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletFactory);
            bullet.transform.position = firePosition.transform.position;
            currentTime = 0;
            createTime = UnityEngine.Random.Range(minTime, maxTime);
        }





    }
}
