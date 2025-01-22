using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    public int score = 20; // 최초 점수 20
    public TextMeshProUGUI scoreText; // 점수를 표시할 TextMeshPro UI
    public GameObject gameOverPanel; // 게임 종료 UI 패널 (게임 오버 메시지)
    public float scoreDecreaseInterval = 1f; // 점수 감소 주기 (1초)

    private bool isGameOver = false; // 게임 오버 여부 체크

    void Start()
    {
        // 초기 점수를 UI에 표시
        UpdateScoreText();
        
        // 게임 오버 패널 숨기기
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        // Coroutine을 이용해 1초마다 점수 감소
        StartCoroutine(DecreaseScoreOverTime());
    }

    void OnCollisionEnter(Collision collision)
    {
        if (isGameOver)
            return;

        // 충돌한 오브젝트의 태그 확인
        if (collision.gameObject.CompareTag("Point"))
        {
            score += 3; // 점수 +3
        }
        else if (collision.gameObject.CompareTag("Block"))
        {
            score -= 5; // 점수 -5
        }

        // UI 점수 업데이트
        UpdateScoreText();

        // 게임 종료 조건 (점수가 0 이하일 경우)
        if (score <= 0)
        {
            GameOver();
        }

        // 충돌한 오브젝트 삭제
        Destroy(collision.gameObject);
    }

    // 점수를 UI에 업데이트하는 함수
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    // 게임 오버 처리
    void GameOver()
    {
        // 게임 오버 패널 활성화
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        // 게임 멈추기
        Time.timeScale = 0f; // 게임 시간을 멈춤
        isGameOver = true; // 게임 오버 상태 설정
    }

    // 점수를 자동으로 감소시키는 Coroutine
    IEnumerator DecreaseScoreOverTime()
    {
        while (!isGameOver)
        {
            // 점수 감소
            score -= 1;

            // UI 점수 업데이트
            UpdateScoreText();

            // 점수가 0 이하로 내려가면 게임 종료
            if (score <= 0)
            {
                GameOver();
            }

            // 1초마다 점수 감소
            yield return new WaitForSeconds(scoreDecreaseInterval);
        }
    }
}
