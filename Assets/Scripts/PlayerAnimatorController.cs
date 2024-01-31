using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAnimatorController : MonoBehaviour
{
    public GameManager gm;
    public Animator anim;
    public List<string> animations = new List<string>(new string[] { "Uprock", "BK_Uprock", "HipHop", "Robot", "Shuffle" });
    public List<float> animTimes;
    public GameObject playerUI;
    public List<Button> playerButtons;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        AnimationTimes();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerUI = GameObject.Find("PlayerPanel").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(!gm.simonsTurn && !gm.isGameOver)
        {
            playerUI.SetActive(true);
        }
        else
        {
            playerUI.SetActive(false);
        }
    }

    void AnimationTimes()
    {
        AnimationClip[] clips = anim.runtimeAnimatorController.animationClips;
        foreach(AnimationClip clip in clips)
        {
            switch(clip.name)
            {
                case "Breakdance Uprock Var 2":
                    float urTime = clip.length;
                    animTimes.Add(urTime);
                    break;
                case "Brooklyn Uprock":
                    float bkTime = clip.length;
                    animTimes.Add(bkTime);
                    break;
                case "Hip Hop Dancing":
                    float hhTime = clip.length;
                    animTimes.Add(hhTime);
                    break;
                case "Robot Hip Hop Dance":
                    float rbTime = clip.length;
                    animTimes.Add(rbTime);
                    break;
                case "Shuffling":
                    float sfTime = clip.length;
                    animTimes.Add(sfTime);
                    break;
                default:
                    break;
            }
        }
    }

    IEnumerator ButtonPressed(int index)
    {
        anim.SetTrigger(animations[index]);
        gm.playerMoves.Add(index);

        foreach(Button button in playerButtons)
        {
            button.interactable = false;
        }

        yield return new WaitForSeconds(animTimes[index]);

        gm.CheckPlayerMoves(index);

        foreach (Button button in playerButtons)
        {
            button.interactable = true;
        }
    }

    public void Uprock()
    {
        StartCoroutine(ButtonPressed(0));
    }
    public void BKUprock()
    {
        StartCoroutine(ButtonPressed(1));
    }
    public void HipHop()
    {
        StartCoroutine(ButtonPressed(2));
    }
    public void RBHipHop()
    {
        StartCoroutine(ButtonPressed(3));
    }
    public void Shuffling()
    {
        StartCoroutine(ButtonPressed(4));
    }
}
