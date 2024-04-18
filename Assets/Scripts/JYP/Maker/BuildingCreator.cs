using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class BuildingCreator : Singleton<BuildingCreator>
{
    [SerializeField]
    Tilemap previewMap,
    defaultMap;
    PlayerInput playerInput;

    TileBase tileBase;
    BuildingObjectBase selectedObj;

    Camera _camera;

    Vector2 mousePos;
    Vector3Int currentGridPosition;
    Vector3Int lastGridPosition;

    bool showUI = true;
    public GameObject UIObject;

    public List<StageData> makeStage = new List<StageData>();

    private bool isDragging = false;

    private void Awake()
    {
        playerInput = new PlayerInput();
        _camera = Camera.main;
        DataManager.Instance.Initialize();
    }
    private void OnEnable()
    {
        playerInput.Enable();

        playerInput.GameMaker.MousePosition.performed += OnMouseMove;
        playerInput.GameMaker.MouseLeftClick.performed += OnLeftClick;
        playerInput.GameMaker.MouseRightClick.performed += OnRightClick;
        playerInput.GameMaker.TabKey.performed += OnPressTab;
    }

    private void OnDisable()
    {
        playerInput.Disable();

        playerInput.GameMaker.MousePosition.performed -= OnMouseMove;
        playerInput.GameMaker.MouseLeftClick.performed -= OnLeftClick;
        playerInput.GameMaker.MouseRightClick.performed -= OnRightClick;
        playerInput.GameMaker.TabKey.performed -= OnPressTab;
    }

    private BuildingObjectBase SelectedObj
    {
        set
        {
            selectedObj = value;

            tileBase = selectedObj != null ? selectedObj.TileBase : null;

            UpdatePreview();
        }
    }

    private void Update()
    {
        // Ÿ�� ���ý� �̸������ֱ�
        if (selectedObj != null)
        {
            Vector3 pos = _camera.ScreenToWorldPoint(mousePos);
            Vector3Int gridPos = previewMap.WorldToCell(pos);

            if (gridPos != currentGridPosition)
            {
                lastGridPosition = currentGridPosition;
                currentGridPosition = gridPos;

                UpdatePreview();
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }

    private void OnMouseMove(InputAction.CallbackContext ctx)
    {
        mousePos = ctx.ReadValue<Vector2>();
        if (isDragging && selectedObj != null && ctx.phase == InputActionPhase.Performed)
        {
            HandleDrawing();
        }
    }

    private void OnLeftClick(InputAction.CallbackContext ctx)
    {
        if (selectedObj != null & EventSystem.current.IsPointerOverGameObject() ==false)
        {
            float clickValue = ctx.ReadValue<float>();
            if (clickValue > 0) // ��ư�� ���� ����
            {
                isDragging = true;
            }
            else // ��ư�� ������ ����
            {
                isDragging = false;
            }

            HandleDrawing();
        }
    }


    private void OnPressTab(InputAction.CallbackContext ctx)
    {
        showUI = !showUI;
        UIObject.SetActive(showUI);
    }

    private void OnRightClick(InputAction.CallbackContext ctx)
    {
        //SelectedObj = null;
        if (selectedObj != null)
        {
            // �׸��� ��ġ�� Ÿ���� null�� ����
            defaultMap.SetTile(currentGridPosition, null);
            makeStage.RemoveAll(s => (s.x == currentGridPosition.x && s.y == currentGridPosition.y));
        }
    }

    public void ObjectSelected(BuildingObjectBase obj)
    {
        SelectedObj = obj;
    }


    private void UpdatePreview()
    {
        // �� Ÿ�� ����
        previewMap.SetTile(lastGridPosition, null);
        previewMap.SetTile(currentGridPosition, tileBase);
    }

    private void HandleDrawing()
    {
        DrawItem();
    }

    private void DrawItem()
    {
        defaultMap.SetTile(currentGridPosition, tileBase);
        StageData stage = new StageData(currentGridPosition.x, currentGridPosition.y, selectedObj.Index);
        //����Ʈ �� �ߺ� ��ǥ ����
        makeStage.RemoveAll(s => (s.x == currentGridPosition.x & s.y == currentGridPosition.y));
        if (selectedObj.Index != 10000)
        {
            makeStage.Add(stage);
        }
    }

    public void LoadDrawItem(StageData stage)
    {
        Vector3Int position = new Vector3Int(stage.x, stage.y, 0);
        BuildingObjectBase tileObject = BuildingObjectData.Instance.GetBuildingObject(stage.tile);

        defaultMap.SetTile(position, tileObject.TileBase);
        makeStage.Add(stage);
    }

    public void ResetItem()
    {
        defaultMap.ClearAllTiles();
    }

}