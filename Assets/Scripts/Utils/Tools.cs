using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;

/// <summary>
/// 工具类
/// </summary>
public class Tools {
    public static T GetControll<T>(GameObject go, string name)
    {
        T[] t = go.transform.GetComponentsInChildren<T>();
        if (t != null && t.Length > 0)
        {
            for (int i = 0; i < t.Length; i++)
            {
                if (t[i] is Component && (t[i] as Component).gameObject.name == name)
                {
                    return t[i];
                }
            }
        }
        return default(T);
    }
    public static int[] LoadPlayerPrefsArray(string _arrName,int[] _array)
    {
        int _length = _array.Length;
        for (int i = 0; i < _length; i++)
        {
            _array[i] = PlayerPrefs.GetInt(_arrName + i, _array[i]);
        }
        return _array;
    }

    public static void SavePlayerPrefsArray(string _arrName,int[] _array)
    {
        int _length = _array.Length;
        for (int i = 0; i < _length; i++)
        {
            PlayerPrefs.SetInt(_arrName + i, _array[i]);
        }
    }

    /// <summary>
    /// 缩放粒子
    /// </summary>
    /// <param name="gameObj">粒子节点</param>
    /// <param name="scale">绽放系数</param>
    public static void ScaleParticleSystem(GameObject gameObj, float scale)
    {
        var hasParticleObj = false;
        var particles = gameObj.GetComponentsInChildren<ParticleSystem>(true);
        var max = particles.Length;
        for (int idx = 0; idx < max; idx++)
        {
            var particle = particles[idx];
            if (particle == null) continue;
            hasParticleObj = true;
            particle.startSize *= scale;
            particle.startSpeed *= scale;
            particle.startRotation *= scale;
            particle.transform.localScale *= scale;
        }
        if (hasParticleObj)
        {
            gameObj.transform.localScale = new Vector3(scale, scale, 1);
        }
    }

    /// <summary>
    /// 旋转粒子
    /// </summary>
    /// <param name="gameObj">粒子节点</param>
    /// <param name="scale">绽放系数</param>
    public static void ParticleSystemRotate(GameObject gameObj, float rotate)
    {
        var hasParticleObj = false;
        var particles = gameObj.GetComponentsInChildren<ParticleSystem>(true);
        var max = particles.Length;
        for (int idx = 0; idx < max; idx++)
        {
            var particle = particles[idx];
            if (particle == null) continue;
            hasParticleObj = true;
            particle.startRotation = rotate;
        }
    }

    /// <summary>
    /// 设置例子透明度
    /// </summary>
    public static void SetParticleSystemAlpha(GameObject gameObj, float alpha)
    {
        var particles = gameObj.GetComponentsInChildren<ParticleSystem>(true);
        var max = particles.Length;
        for (int idx = 0; idx < max; idx++)
        {
            var particle = particles[idx];
            if (particle == null) continue;
            particle.startColor = GetColr(255,255,255,alpha);
        }
    }

    /// <summary>
    /// 移除对象的全部子对象
    /// </summary>
    /// <param name="parent"></param>
    public static void RemoveAllChildren(GameObject parent)
    {
        Transform transform;
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            transform = parent.transform.GetChild(i);
            GameObject.Destroy(transform.gameObject);
        }
    }

    /// <summary>
    /// 播放animation动画
    /// </summary>
    public static void PlayAnimation(Animation ani,string stateName)
    {
        AnimationState state = ani[stateName];
        state.time = 0;
        ani.Stop();
        ani.Play(stateName ,PlayMode.StopAll);
    }

    /// <summary>
    /// 暂停播放animation动画
    /// </summary>
    public static void StopAnimation(Animation ani, string stateName)
    {
        AnimationState state = ani[stateName];
        state.time = 0;
        ani.Stop();
    }


    /// <summary>
    /// 存储字符串为文本
    /// </summary>
    /// <param name="html"></param>
    /// <param name="file"></param>
    /// <returns></returns>
    public static string writTxt(string html, string file)
    {
        FileStream fileStream = new FileStream(System.Environment.CurrentDirectory + "\\" + file+".txt", FileMode.Append);
        StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.Default);
        streamWriter.Write(html + "\r\n");
        streamWriter.Flush();
        streamWriter.Close();
        fileStream.Close();
        return "ture";
    }

    /// <summary>
    /// 获得2D平面内两个点的角度
    /// </summary>
    /// <returns></returns>
    public static float GetForRotation(Vector3 vecA, Vector3 vecB)
    {
        float targetAngle = 0;
        //Vector3 targetVec;
        //float AtanTarget = 0;
        
        //Vector3 direction = vecB - vecA;                                    ///< 终点减去起点（AB方向与X轴的夹角）
        Vector3 direction = vecA - vecB;                                  ///< （BA方向与X轴的夹角）
        float angle = Vector3.Angle(direction, Vector3.right);              ///< 计算旋转角度
        direction = Vector3.Normalize(direction);                           ///< 向量规范化
        float dot = Vector3.Dot(direction, Vector3.up);                  ///< 判断是否Vector3.right在同一方向
        if (dot < 0)
            angle = 360 - angle;

        targetAngle = angle;
        //targetVec = new Vector3(0, 0, angle);
        //< 补充点1： 通过Atan2与方向向量的两条边可以计算出转向的角度，通过计算结果可以看到targetAngle与-AtanTarget相加正好是360°，即二者都指向同一方向。具体使用场景需要根据具体需求分析。
        //AtanTarget = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //Debug.LogWarning("vecA：" + vecA.ToString() + ", vecB：" + vecB.ToString() + ", targetAngle: " + targetAngle.ToString() + ", AtanTarget: " + AtanTarget.ToString());
        //arrow.GetComponent<Transform>().Rotate(0, 0, angle);

        //< 补充点2： 使用欧拉角来控制物体的旋转
        //arrow.GetComponent<Transform>().eulerAngles = new Vector3(0, 0, angle);
        return targetAngle;
    }


    public static float GetAngle_360(Vector3 from_, Vector3 to_)
    {
        //两点的x、y值
        float x = from_.x - to_.x;
        float y = from_.y - to_.y;

        //斜边长度
        float hypotenuse = Mathf.Sqrt(Mathf.Pow(x, 2f) + Mathf.Pow(y, 2f));

        //求出弧度
        float cos = x / hypotenuse;
        float radian = Mathf.Acos(cos);

        //用弧度算出角度    
        float angle = 180 / (Mathf.PI / radian);

        if (y < 0)
        {
            angle = -angle;
        }
        else if ((y == 0) && (x < 0))
        {
            angle = 180;
        }
        angle += 180;
        return angle;
    }


    /// <summary>
    /// 获取颜色值
    /// </summary>
    /// <param name="r"></param>
    /// <param name="g"></param>
    /// <param name="b"></param>
    /// <param name="a"></param>
    /// <returns></returns>
    public static Color GetColr(float r,float g,float b,float a)
    {
        return new Color(r/255f,g/255f,b/255f,a/255f);
    }

    /// <summary>
    /// 3维中如何计算两点之间的距离
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <returns></returns>
    public static  float GetTwoPointDistance3D(Vector3 p1, Vector3 p2)
    {
        float i = Mathf.Sqrt((p1.x - p2.x) * (p1.x - p2.x)
                            + (p1.y - p2.y) * (p1.y - p2.y)
                            + (p1.z - p2.z) * (p1.z - p2.z));

        return i;
    }

    /// <summary>
    /// 2维中如何计算两点之间的距离
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <returns></returns>
    public static float TwoPointDistance2D(Vector2 p1, Vector2 p2)
    {

        float i = Mathf.Sqrt((p1.x - p2.x) * (p1.x - p2.x)
                            + (p1.y - p2.y) * (p1.y - p2.y));

        return i;
    }

    /// <summary>
    /// 2维中如何计算两点之间的距离
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <returns></returns>
    public static float GetTwointDistance2D(Vector3 p1, Vector3 p2)
    {
        float i = Mathf.Sqrt((p1.x - p2.x) * (p1.x - p2.x)
                            + (p1.y - p2.y) * (p1.y - p2.y));

        return i;
    }

    ///// <summary>
    ///// 获得两点之间的角度
    ///// </summary>
    ///// <param name="from_"></param>
    ///// <param name="to_"></param>
    ///// <returns></returns>
    //public static float GetTwoPointRotate(Vector3 from_, Vector3 to_)
    //{
    //    Vector3 v3 = Vector3.Cross(from_, to_); //叉乘判断正方向

    //    if (v3.z > 0)
    //        return Vector3.Angle(from_, to_);
    //    else
    //        return 360 - Vector3.Angle(from_, to_);
    //}

    public static void Log(object message)
    {
        //Debug.Log("[-- Tools debug log --]"+message);
    }

}
