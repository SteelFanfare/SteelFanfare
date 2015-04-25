using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class Robot1Behavior : MonoBehaviour
{
    private Animator animator;
    private int beatLayer;

    public float beat
    {
        get
        {
            return animator.GetLayerWeight(beatLayer);
        }
        set
        {
            animator.SetLayerWeight(beatLayer, value);
        }
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        beatLayer = animator.GetLayerIndex("Beat");
    }
}
