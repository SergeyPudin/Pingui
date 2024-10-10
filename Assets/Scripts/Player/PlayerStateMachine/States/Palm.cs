using UnityEngine;

public class Palm : State
{
    [SerializeField] private PlayerAnimatorChanger _animatorChanger;

    private void OnEnable()
    {
        Debug.Log("Palm");
    }

    private void Update()
    {       
           
    }

    public void TrySetBulldog()
    {
        // if(nextStateBulldogFish)
        _animatorChanger.GetFish();
            NeedTransit();
    }
}