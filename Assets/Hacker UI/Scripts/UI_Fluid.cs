using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Fluid : MonoBehaviour
{
    public Slider fillSlider;
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
    }

    void OnFluidCorrect(bool correct)
    {

    }
}
