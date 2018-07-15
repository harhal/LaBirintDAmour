using System.Collections;
using System.Collections.Generic;
using DragonBones;
using UnityEngine;

public class AnimatedVisualController : VisualController
{
    [SerializeField]
    protected UnityArmatureComponent Animation;
    [SerializeField]
    protected string IdleAnimation = "animtion0";
    [SerializeField]
    protected string RunAnimation = "newAnimation_1";
    [SerializeField]
    protected float MaxRunSpeed;
    [SerializeField]
    string playerPrefsName;


    private void Awake()
    {
        int type = PlayerPrefs.GetInt(playerPrefsName);
        var children = gameObject.GetComponentsInChildren<UnityArmatureComponent>();
        for(int i = 0; i < children.Length; i++)
        {
            if (type == i)
            {
                children[i].gameObject.SetActive(true);
            }
            else
            {
                children[i].gameObject.SetActive(false);
            }
        }
        Animation = children[type];
    }


    public override void SetMovement(Vector2 Direction, float Velocity)
    {
        Animation.armature.flipX = Direction.x == 0 ? Direction.y > 0 : Direction.x > 0;
        if (Velocity == 0)
        {
            Animation.animation.timeScale = 1;
            var state = Animation.animation.GetState(IdleAnimation);
            if (state == null || !state.isPlaying)
            {
                if (Animation.animation.HasAnimation(IdleAnimation))
                {
                    Animation.animation.FadeIn(IdleAnimation, 0.1f);
                }
            }
        }
        else
        {
            Animation.animation.timeScale = Velocity / MaxRunSpeed;
            var state = Animation.animation.GetState(RunAnimation);
            if (state == null || !state.isPlaying)
            {
                if (Animation.animation.HasAnimation(RunAnimation))
                {
                    Animation.animation.FadeIn(RunAnimation, 0.1f);
                }
            }
        }
    }

    protected override void SwitchVisualVisibility()
    {
        Animation.gameObject.SetActive(Animation.gameObject.activeSelf);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
