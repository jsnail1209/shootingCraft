using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//목표: 적이 다른 물체와 충돌했을 때 복팔 효과를 발생시키고 싶다.
// 순서 1. 적이 다른 물체와 충돌했으니까.
//      2. 폭발 효과 공장에서 폭발 효과를 하나 만들어야 한디.
//      3. 폭발 효과를 발생(위치)시키고 싶다.
// 필요 속성: 폭발 공장 주소(외부에서 값을 넣어준다)
public class Enemy : MonoBehaviour
{

	// 필요 속성: 이동 속도
	public float speed = 5;

    GameObject player;

    // 방향을 전역 변수로 만들어 Start와 Update에서 사용
    Vector3 dir;

    // 충돌 시작(1. 적이 다른 물체와 충돌했으니까.)
    private void OnCollisionEnter(Collision collision)
    {
        //2. 폭발 효과 공장에서 폭발 효과를 하나 만들어야 한다.
        GameObject explosion = Instantiate(explosionFactory);

        //3. 폭발 효과를 발생(위치)시키고 싶다.
        explosion.transform.position = transform.position;
        
        Destroy(collision.gameObject);
        Destroy(gameObject);

    }

    //폭발 공장 주소(외부에서 값을 넣어준다)
    public GameObject explosionFactory;

    void Start()
    {
        
        // 0부터 9까지 10개의 값 중에 하나를 랜덤으로 가져온다.
        int randValue = UnityEngine.Random.Range(0, 3);
        // 만약 3보다 작으면 플레이어 방향
        if (randValue < 3)
        {
            // 플레이어를 찾아 target으로 하고 싶다.
            GameObject target = GameObject.Find("Player");
            // 방향을 구하고 싶다. target-me
            dir = target.transform.position - transform.position;
            // 방향의 크기를 1로 하고 싶다.
            dir.Normalize();

        }
        // 그렇지 않으면 아래 방향으로 정하고 싶다.
        else
        {
            dir = Vector3.down;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 1. 방향을 구한다.
        // Vector3 dir = Vector3.down;
		transform.position += dir * speed * Time.deltaTime;

    }

}
