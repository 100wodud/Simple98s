using Simple98;
using System.Collections;
using System.Collections.Generic;
using UGS;

public class TileDatas
{
    //������ �����س���
    public void Initialize ()
    {
        UnityGoogleSheet.Load<Tiles>();
    }

    //�ε��� 
    public Tiles GetTile(int index)
    {
        Tiles tile;
        tile = Tiles.TilesMap[index];
        return tile;
    }


    public List<Tiles> GetAllTiles()//�׳ɸ���
    {
        List<Tiles> allTiles = new List<Tiles>();

        foreach (var item in Tiles.TilesList)
        {
            allTiles.Add(item);
        }
        
        return allTiles;
    }

    //Ÿ�� �� Ÿ�� ������(type �Է� / ��� list)
    public List<Tiles> FindTypeTiles(string type)
    {
        List<Tiles> typeTiles = new List<Tiles>();
        foreach (var item in Tiles.TilesList)
        {
            if (type == item.Type)
            {
                typeTiles.Add(item);
            }
        }
        return typeTiles;
    }

}