using Simple98;
using System.Collections;
using System.Collections.Generic;
using UGS;

public class DataManager : Singleton<DataManager>
{
    //��� ������ �Ŵ����� �����͸� ������ �ִ� �Ŵ���
    //�����ʹ� ������ �Ŵ����� ���ؼ� �ҷ�����
    //Sheet�� �ִ� Data ����
    //�� �����͸Ŵ���, Ÿ�� ������ �Ŵ���
    //��,
    //�̱��� ����
    //�� �����͸Ŵ���
    
    public TileDataManager tileDataManager = new ();

    public void Initialize()//�ʱ�ȭ
    {
        tileDataManager.Initialize();
    }   
}
