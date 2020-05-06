using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuToGame : MonoBehaviour
{
    [SerializeField] GameObject loadingSet;
    [SerializeField] RectTransform slider;

    [SerializeField] GameObject thisGuy;
    [SerializeField] ParticleSystem manyParticles;
    // Start is called before the first frame update
    public void Tran_SITION(int index)
    {
        iTween.PunchScale(thisGuy, iTween.Hash("z", 10f, "amount", thisGuy.transform.localScale));
        loadingSet.SetActive(true);
        StartCoroutine(Transicao(index));
    }

    IEnumerator Transicao(int buildNumber)
    {
        var em = manyParticles.emission;
        em.rateOverTime = 90;
        //slider.offsetMax += new Vector2(-10f * Time.deltaTime, slider.offsetMax.y);
        //print("Ema");
        yield return new WaitForSeconds(5f);
        AsyncOperation operacao = SceneManager.LoadSceneAsync(buildNumber);
        
        while (!operacao.isDone)
        {
            float progresso = Mathf.Clamp01(operacao.progress / 0.9f);
            slider.offsetMax -= new Vector2(progresso * -1500f * Time.deltaTime, slider.offsetMax.y);
            //xRect.x = Mathf.Clamp(xRect.x, 0f, 1366f);
            yield return null;
        }
        
    }
}
