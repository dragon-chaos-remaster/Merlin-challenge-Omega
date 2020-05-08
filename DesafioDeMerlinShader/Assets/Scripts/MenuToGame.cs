using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuToGame : MonoBehaviour
{
    [SerializeField] GameObject loadingSet;
    [SerializeField] RectTransform slider;
    //[SerializeField] GameObject windParticle;
    [SerializeField] GameObject thisGuy;
    [SerializeField] ParticleSystem manyParticles;
    // Start is called before the first frame update
    public void Tran_SITION(int index)
    {
        iTween.PunchScale(thisGuy, iTween.Hash("z", 10f, "amount", thisGuy.transform.localScale));
        loadingSet.SetActive(true);
        StartCoroutine(Transicao(index));
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Tran_SITION(1);
    }
    IEnumerator Transicao(int buildNumber)
    {
        var em = manyParticles.emission;
        em.rateOverTime = 0;
        //slider.offsetMax += new Vector2(-10f * Time.deltaTime, slider.offsetMax.y);
        //print("Ema");
        yield return new WaitForSeconds(2f);
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
