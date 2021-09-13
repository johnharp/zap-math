using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LessonEndController : MonoBehaviour
{
    private MainController _MainController = null;

    [SerializeField]
    private AudioClip SoundClick;

    [SerializeField]
    private AudioClip SoundEnd;

    [SerializeField]
    private AudioSource LessonAudioSource;

    [SerializeField]
    private UnityEngine.UI.Text PercentRightText = null;

    private float firstThirdSeconds = 0.1f;
    private float secondThirdSeconds = 0.5f;
    private float thirdThirdSeconds = 3.0f;


    public void Start()
    {
        GameObject controllers = GameObject.Find("Controllers");
        _MainController = controllers.GetComponent<MainController>();

        PercentRightText.text = PercentGradeStr(0);
        StartCoroutine(CountUpToGrade());
    }
    public void HandleBackButton()
    {
        LessonAudioSource.PlayOneShot(SoundClick);
        SceneManager.LoadScene("LessonSelectScene");
    }

    public void Update()
    {
        var delta = Time.deltaTime;
    }

    IEnumerator CountUpToGrade()
    {
        int targetGrade = _MainController.GetPercentGrade();
        float waitTime = 0.01f;

        for (int grade = 0; grade < targetGrade; grade++)
        {
            if (targetGrade - grade <= 5) waitTime = 0.4f;
            else if (targetGrade - grade <= 10) waitTime = 0.1f;

            PercentRightText.text = PercentGradeStr(grade);
            yield return new WaitForSeconds(waitTime);
        }

        PercentRightText.text = PercentGradeStr(targetGrade);

        LessonAudioSource.PlayOneShot(SoundEnd);
    }

    private string PercentGradeStr(int g)
    {
        string s =
            string.Format("{0:N0} %", g);

        return s;
    }
}
