using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimonAnimatorController : MonoBehaviour
{
    public GameManager gm;
    public Animator anim;
    public List<string> animations = new List<string>(new string[] { "Uprock", "BK_Uprock", "HipHop", "Robot", "Shuffle" });
    public List<float> animTimes;
    public List<Button> simonButtons;
    public Color newColor;
    public Color oldColor;

    public GameObject simonUI;

    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        AnimationTimes();

        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        simonUI = GameObject.Find("SimonPanel").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.simonsTurn)
        {
            simonUI.SetActive(true);
        }
        else 
        {
            simonUI.SetActive(false);
        }
    }

    public void SimonDances(int index)
    {
        anim.SetTrigger(animations[index]);
        StartCoroutine(ButtonPressed(index));
    }

    public IEnumerator ButtonPressed(int index)
    {
        simonButtons[index].image.color = newColor;
        yield return new WaitForSecondsRealtime(2f);
        simonButtons[index].image.color = oldColor;
    }

    void AnimationTimes()
    {
        AnimationClip[] clips = anim.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            switch (clip.name)
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
            }
        }
    }
}
