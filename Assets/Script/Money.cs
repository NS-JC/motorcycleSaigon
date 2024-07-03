using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public SpriteRenderer wallet1;
    public SpriteRenderer wallet2;
    public SpriteRenderer wallet3;
    public Sprite cashSprite; // Public으로 선언된 'cash' 이미지

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ChangeWalletSprite();
            Destroy(gameObject); // 충돌 후 Money 오브젝트 파괴
        }
    }

    private void ChangeWalletSprite()
    {
        SpriteRenderer sr1 = wallet1.GetComponent<SpriteRenderer>();
        SpriteRenderer sr2 = wallet2.GetComponent<SpriteRenderer>();
        SpriteRenderer sr3 = wallet3.GetComponent<SpriteRenderer>();

        if (sr1.sprite != cashSprite)
        {
            sr1.sprite = cashSprite;
        }
        else if (sr2.sprite != cashSprite)
        {
            sr2.sprite = cashSprite;
        }
        else if (sr3.sprite != cashSprite)
        {
            sr3.sprite = cashSprite;
        }
        else
        {
            // 모든 지갑에 cashSprite가 이미 적용된 경우 점수 증가
            if (sr1.sprite == cashSprite && sr2.sprite == cashSprite && sr3.sprite == cashSprite)
            {
                Score.score += 3;
            }
        }
    }
}