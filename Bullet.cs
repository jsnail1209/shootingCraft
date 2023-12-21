using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	// �ʿ� �Ӽ�: �̵� �ӵ�
    public float speed = 5;

    // �浹 ����
    private void OnCollisionEnter(Collision collision)
    {

        Destroy(collision.gameObject);
        Destroy(gameObject);

        // ���ʹ̸� ���� ������ ���� ������ ǥ���ϰ� �ʹ�.
        // 1. ������ ScoreManger ��ü�� ã�ƿ���.
        GameObject smObject = GameObject.Find("ScoreManager");
        // 2. ScoreManager ���� ������Ʈ���� ���´�.
        ScoreManager sm = smObject.GetComponent<ScoreManager>();
        // 3. ScoreManager Ŭ������ �Ӽ��� ���� �Ҵ��Ѵ�.
        sm.currentScore = sm.currentScore + 1000;
        // 4. ȭ�鿡 ���� ���� ǥ���ϱ�
        sm.currentScoreUI.text = "��������: " + sm.currentScore;

            // ��ǥ: �ְ� ������ ǥ���ϰ� �ʹ�.
            // 1. ���� ������ �ְ� �������� ũ�ϱ�
            // -> ���� ���� ������ �ְ� ������ �ʰ��ߴٸ�
            if (sm.currentScore > sm.bestScore)
		{
			// 2. �ְ� ������ ���Ž�Ų��.
			sm.bestScore = sm.currentScore;

			// 3. �ְ� ���� UI�� ǥ��
			sm.bestScoreUI.text = "�ְ�����: " + sm.bestScore;

			// ��ǥ: �ְ� ������ �����ϰ� �ʹ�.
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
            // 1. ������ ScoreManger ��ü�� ã�ƿ���.
            GameObject smObject = GameObject.Find("ScoreManager");
            // 2. ScoreManager ���� ������Ʈ���� ���´�.
            ScoreManager sm = smObject.GetComponent<ScoreManager>();
            // 3. ScoreManager Ŭ������ �Ӽ��� ���� �Ҵ��Ѵ�.
            sm.currentScore = sm.currentScore - 1;
            // 4. ȭ�鿡 ���� ���� ǥ���ϱ�
            sm.currentScoreUI.text = "��������: " + sm.currentScore;

            if(sm.currentScore < 0)
            {
                sm.currentScore = 0;
                sm.currentScoreUI.text = "��������: " + sm.currentScore;

            }
        }
    }
}
