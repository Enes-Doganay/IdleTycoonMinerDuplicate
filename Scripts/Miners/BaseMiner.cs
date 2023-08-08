using System.Collections;
using UnityEngine;
using DG.Tweening;
using System;

public class BaseMiner : MonoBehaviour
{
    public static Action<BaseMiner, float> OnLoading;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private int initialCollectCapacity = 200;
    [SerializeField] private float goldCollectPerSecond = 50f;

    public float MoveSpeed { get; set; }
    public int CurrentGold { get; set; }
    public int CollectCapacity { get; set; }
    public float CollectPerSecond { get; set; }
    public bool IsTimeToCollect { get; set; }
    protected Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        IsTimeToCollect = true;
        MoveSpeed = moveSpeed;
        CurrentGold = 0;
        CollectCapacity = initialCollectCapacity;
        CollectPerSecond = goldCollectPerSecond;
    }
    public virtual void MoveMiner(Vector3 newPosition)
    {
        transform.DOMove(newPosition, 10 / MoveSpeed).OnComplete(() =>
        {
            if (IsTimeToCollect)
            {
                CollectGold();
            }
            else
            {
                DepositGold();
            }
        }).Play();
    }

    protected virtual void CollectGold()
    {
        
    }

    protected virtual IEnumerator IECollect(int collectGold, float collectTime)
    {
        yield return null;
    }
    protected virtual void DepositGold()
    {

    }
    protected virtual IEnumerator IEDeposit(int goldCollected, float depositTime)
    {
        yield return null;
    }
    public void ChangeGoal()
    {
        IsTimeToCollect = !IsTimeToCollect;
    }
    public void RotateMiner(int direction)
    {
        if (direction == 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
