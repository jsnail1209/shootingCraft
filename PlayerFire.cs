using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 현재 시간
    float currentTime;

    // 일정 시간
    public float createTime = 1;

    // 최소 시간
    float minTime = 0.5f;

    // 최대 시간
    float maxTime = 1;

    // 총알을 생산할 공장
    public GameObject bulletFactory;
	
	// 총구
	public GameObject firePosition;
	// Start is called before the first frame update
    void Start()
    {
        // 태어날 때 적의 생성 시간을 설정하고
        createTime = UnityEngine.Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()

    {
        // 1. 시간이 흐르다가
        currentTime += Time.deltaTime;

        // 2. 만약 현재 시간이 일정 시간이 되면
        if (currentTime > createTime | Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletFactory);
            bullet.transform.position = firePosition.transform.position;
            currentTime = 0;
            createTime = UnityEngine.Random.Range(minTime, maxTime);
        }





    }
}
