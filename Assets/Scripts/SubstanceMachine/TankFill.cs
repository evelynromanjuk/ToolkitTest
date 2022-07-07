using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankFill : MonoBehaviour
{

    [SerializeField] FluidCompositionManager FluidCompositionManager;
    public Material tankMaterial;
    // Start is called before the first frame update

    private void Awake()
    {
        tankMaterial = GetComponent<MeshRenderer>().material;
        tankMaterial.SetFloat("_FillRate", -1);
    }
    void Start()
    {
        FluidCompositionManager.SubscribeFluidAmountChanged(OnFluidAmountChanged);

    }

    void OnFluidAmountChanged(float percentage)
    {
        float conversion1 = percentage / 100;
        float fillRate = conversion1 - 0.5f;

        tankMaterial.SetFloat("_FillRate", fillRate);

    }
}
