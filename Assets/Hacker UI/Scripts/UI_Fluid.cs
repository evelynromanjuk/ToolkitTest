using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Fluid : MonoBehaviour
{
    public Slider fillSlider;
    public TMP_Text percentage;
    public Image image;
    [SerializeField] FluidCompositionManager FluidCompositionManager;

    private void Awake()
    {
        fillSlider = GetComponent<Slider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        FluidCompositionManager.SubscribeFluidAmountChanged(OnFluidAmountChanged);
        FluidCompositionManager.SubscribeCompositionCorrectEvent(OnFluidCorrect);
    }

    void OnFluidAmountChanged(float percentage)
    {
        fillSlider.value = percentage;
        this.percentage.text = percentage.ToString()+"%";
    }

    void OnFluidCorrect(bool correct)
    {
        if(!correct)
        {
            image.color = Color.red;
        } else
        {
            image.color = Color.green;
        }
    }
}
