using Simple98;
using System.Collections;
using System.Collections.Generic;
using UGS;

public class TileDatas
{

    public void Initialize ()
    {
        UnityGoogleSheet.Load<Tiles>();
    }

    //인덱스 
    public Tiles GetTile(int index)
    {
        Tiles tile;
        tile = Tiles.TilesMap[index];
        return tile;
    }


    public List<Tiles> GetAllTiles()
    {
        List<Tiles> allTiles = new List<Tiles>();

        foreach (var item in Tiles.TilesList)
        {
            allTiles.Add(item);
        }
        
        return allTiles;
    }

    //타입 별 타일 나누기(type 입력 / 출력 list)
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

    //타일 생성(인덱스값,x,y축 필요)
    /*

    
    */
}
