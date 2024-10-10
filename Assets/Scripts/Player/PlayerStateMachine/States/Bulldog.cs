using UnityEngine;

public class Bulldog : State
{
    [SerializeField] private BulldogFish _bulldogFish;
    [SerializeField] private PlayerAnimatorChanger _animatorChanger;

    private void Update()
    {
        
    }

    public void TryGetPalm()
    {
        if (_bulldogFish.gameObject.activeSelf == true)
        {
            _animatorChanger.MoveOut();
        }

        NeedTransit();
    }
}