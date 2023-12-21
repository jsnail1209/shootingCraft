using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	// 필요 속성: 이동 속도
    public float speed = 5;

    // 충돌 시작
    private void OnCollisionEnter(Collision collision)
    {

        Destroy(collision.gameObject);
        Destroy(gameObject);

        // 에너미를 잡을 때마다 현재 점수를 표시하고 싶다.
        // 1. 씬에서 ScoreManger 객체를 찾아오자.
        GameObject smObject = GameObject.Find("ScoreManager");
        // 2. ScoreManager 게임 오브젝트에서 얻어온다.
        ScoreManager sm = smObject.GetComponent<ScoreManager>();
        // 3. ScoreManager 클래스의 속성에 값을 할당한다.
        sm.currentScore = sm.currentScore + 1000;
        // 4. 화면에 현재 점수 표시하기
        sm.currentScoreUI.text = "현재점수: " + sm.currentScore;

            // 목표: 최고 점수를 표시하고 싶다.
            // 1. 현재 점수가 최고 점수보다 크니까
            // -> 만약 현재 점수가 최고 점수를 초과했다면
            if (sm.currentScore > sm.bestScore)
		{
			// 2. 최고 점수를 갱신시킨다.
			sm.bestScore = sm.currentScore;

			// 3. 최고 점수 UI에 표시
			sm.bestScoreUI.text = "최고점수: " + sm.bestScore;

			// 목표: 최고 점수를 저장하고 싶다.
			PlayerPrefs.SetInt("Best Score", sm.bestScore);
		}
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		Vector3 dir = Vector3.up;
		transform.position += dir * speed * Time.deltaTime;

        if (Input.GetButtonDown("Fire1") | Input.GetKey(KeyCode.DownArrow))
        {
            // 1. 씬에서 ScoreManger 객체를 찾아오자.
            GameObject smObject = GameObject.Find("ScoreManager");
            // 2. ScoreManager 게임 오브젝트에서 얻어온다.
            ScoreManager sm = smObject.GetComponent<ScoreManager>();
            // 3. ScoreManager 클래스의 속성에 값을 할당한다.
            sm.currentScore = sm.currentScore - 1;
            // 4. 화면에 현재 점수 표시하기
            sm.currentScoreUI.text = "현재점수: " + sm.currentScore;

            if(sm.currentScore < 0)
            {
                sm.currentScore = 0;
                sm.currentScoreUI.text = "현재점수: " + sm.currentScore;

            }
        }
    }
}
