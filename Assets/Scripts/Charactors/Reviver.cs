using System.Collections;
using UnityEngine;

public class Reviver : MonoBehaviour
{
    // 用于引用特定安卓Java对象
    public static AndroidJavaObject androidJavaObject;
    // 用于引用当前主角游戏对象
    private GameObject currentPlayer;
    private Transform planeTransform;
    private PlaneCollisionChecker planeCollisionChecker;

    private void Start()
    {
        GetAndroidJavaObject();
        GetCurrentPlayer();
        planeTransform = GameObject.Find("Plane").transform;
        planeCollisionChecker = planeTransform.GetComponent<PlaneCollisionChecker>();
    }

    // 获取安卓Java对象方法
    private void GetAndroidJavaObject()
    {
        // 根据类名构建一个新的安卓Java类
        AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        // 根据字段名称获得当前的安卓Java对象
        androidJavaObject = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
    }

    // 获取当前主角方法
    private void GetCurrentPlayer()
    {
        // 获取Players子对象数量
        int cc = transform.childCount;

        // 遍历Players的子对象
        for (int i = 0; i < cc; i++)
        {
            // 根据索引获取Players的子对象
            GameObject obj = transform.GetChild(i).gameObject;
            // 若获取的Players子对象处于激活状态
            if (obj.activeSelf)
            {
                // 使用currentPlayer引用这个Players子对象，即获取了当前主角游戏对象
                currentPlayer = obj;
            }
        }
    }

    // 本方法开启一个Revive协程
    public void ReadyToRevive()
    {
        StartCoroutine(Revive());
    }

    // 复活协程函数
    public IEnumerator Revive()
    {
        yield return new WaitForSeconds(0.1f);

        // 重置纸飞机
        planeTransform.position = new Vector3(planeTransform.position.x, 2.5f, 0.0f);
        planeCollisionChecker.onGround = false;
        // 将主角状态机设为Idle
        currentPlayer.GetComponent<PlayerController>().Idle();
        // 将主角复活位置向后移3个单位
        currentPlayer.transform.position -= new Vector3(3.0f, 0.0f, 0.0f);
        // 若主角复活位置小于0，则将其位置设为0
        if (currentPlayer.transform.position.x < 0.0f)
        {
            currentPlayer.transform.position = new Vector3(0.0f, currentPlayer.transform.position.y, 0.0f);
        }
        // 重置主角的尺寸
        currentPlayer.transform.localScale = Vector3Int.one;
        // 激活主角游戏对象的Sprite Renderer组件
        currentPlayer.GetComponent<SpriteRenderer>().enabled = true;
    }
}
