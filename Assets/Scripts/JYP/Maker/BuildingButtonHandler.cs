using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuildingButtonHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] BuildingObjectBase item;
    Button button;
    public Tooltip tooltip;

    BuildingCreator buildingCreator;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ButtonClicked);
        buildingCreator = BuildingCreator.Instance;
    }

    private void ButtonClicked()
    {
        buildingCreator.ObjectSelected(item);
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if(item.Description.Length != 0)
        {
            tooltip.gameObject.SetActive(true);
            tooltip.SetupTooltip(item.Description);
        }
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        tooltip.gameObject.SetActive(false);
    }
}