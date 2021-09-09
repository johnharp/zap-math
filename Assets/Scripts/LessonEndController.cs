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
    private AudioSource LessonAudioSource;

    [SerializeField]
    private UnityEngine.UI.Text PercentRightText = null;

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
        int grade = 0;

        while (grade < targetGrade)
        {
            grade++;
            PercentRightText.text = PercentGradeStr(grade);
            yield return new WaitForSeconds(0.05f);
        }
    }

    private string PercentGradeStr(int g)
    {
        string s =
            string.Format("{0:N0} %", g);

        return s;
    }
}
