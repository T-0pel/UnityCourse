using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private int MaxHits;
    private int TimesHit;
    private LevelManager LevelManager;
    public List<Sprite> HitSprites;
    public static int BreakableCount;
    public AudioClip CrackSound;
    private bool IsBreakable;

    private void Start()
    {
        IsBreakable = tag == "Breakable";
        if (IsBreakable)
        {
            BreakableCount++;
        }
        LevelManager = FindObjectOfType<LevelManager>();
        TimesHit = 0;
        MaxHits = HitSprites.Count + 1 ;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (IsBreakable)
        {
            HandleHits();
        }
    }

    private void HandleHits()
    {
        AudioSource.PlayClipAtPoint(CrackSound, transform.position, 0.8f);
        TimesHit++;
        if (TimesHit >= MaxHits)
        {
            BreakableCount--;
            print(BreakableCount);
            LevelManager.BrickDestroyed();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    private void LoadSprites()
    {
        var spriteIndex = TimesHit - 1;
        if (HitSprites[spriteIndex])
        {
            GetComponent<SpriteRenderer>().sprite = HitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError(string.Format("Sprite on index {0} missing", spriteIndex));
        }
    }

    private void SimulateWin()
    {
        LevelManager.LoadNextLevel();
    }
}
