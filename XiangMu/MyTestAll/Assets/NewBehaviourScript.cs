using UnityEngine;
using System.Collections;

public class TestGoto : MonoBehaviour
{
    public GUISkin skin;
    float width;
    float height;
    public Texture up;
    public Texture down;
    public Texture right;
    public Texture left;
    public Texture up_down;
    public Texture right_left;
    int[] images;
    Vector4[] dires;
    int flag;
    int step;
    int coml;
    int row;
    int m;
    int n;
    bool isend;
    bool iswin;
    int[] TF;
    void Start() {
    		//width=80*(Screen.width/480);  
    		width = Screen.width * 0.12F;
    		height = width;
    		flag = 0;
    		step = 0;
    		row = 4;
    		coml = 8;
    		m = 0;
    		n = 0;
    		iswin = false;
    		images = new int[32];
    		dires = new Vector4[32];
    		TF = new int[32];
    		for (int k = 0; k <= 31; k++) {
    			flag = Random.Range(1, 7);
    			images[k] = flag;
    		}

    		//level 01  
    	}

    void OnGUI()
    {

        GUI.skin = skin;
        GUI.Window(1, new Rect(0, 0, Screen.width, Screen.height), ShowWindow, "");

        if (isend)
        {
            WinOrLose();
        }

    }
    void ShowWindow(int windowID) {
    		if (GUI.Button(new Rect(width * 0.2F, 0, width, height), "open")) {
    			isend = true;
    		}
    		for (int j = 0; j < row; j++) {
    			for (int i = 0; i < coml; i++) {
    				if (GUI.Button(new Rect(i * width + width * 0.2F, (j + 1) * height, width, height), select(images[j * coml + i]))) {
    					step += 1;
    					if (images[j * coml + i] < 5) {
    						images[j * coml + i] += 1;
    						if (images[j * coml + i] == 5) {
    							images[j * coml + i] = 1;
    						}
    					} else {
    						images[j * coml + i] += 1;
    						if (images[j * coml + i] == 7) {
    							images[j * coml + i] = 5;
    						}
    					}
    				}

    				Vector4 dir;
    				if (select(images[j * coml + i]) == up) {
    					dir = new Vector4(1, 1, 0, 0);
    				} else if (select(images[j * coml + i]) == right) {
    					dir = new Vector4(0, 1, 1, 0);
    				} else if (select(images[j * coml + i]) == down) {
    					dir = new Vector4(0, 0, 1, 1);
    				} else if (select(images[j * coml + i]) == left) {
    					dir = new Vector4(1, 0, 0, 1);
    				} else if (select(images[j * coml + i]) == up_down) {
    					dir = new Vector4(1, 0, 1, 0);
    				} else {
    					dir = new Vector4(0, 1, 0, 1);
    				}
    				dires[j * coml + i] = dir;
    				//print(j*coml+i+":"+dires[j*coml+i]);  
    			}
    		}
    	}
    Texture select(int n)
    {
        Texture image = new Texture();
        switch (n)
        {
            case 1:
                image = up;
                break;
            case 2:
                image = right;
                break;
            case 3:
                image = down;
                break;
            case 4:
                image = left;
                break;
            case 5:
                image = up_down;
                break;
            case 6:
                image = right_left;
                break;
        }
        return image;
    }
    //判断输赢  
    void WinOrLose()
    {
        switch (images[n * coml + m])
        {
            //第一种类型的图片,向上+向右  
            // if(dires[n*coml+m].x==1&&dires[n*coml+m].y==1){  
            case 1:
                if (n == 0)
                {
                    if (m == 0)
                    {
                        TF[n * coml + m] = 1;
                        m++;
                    }
                } //Unity3D教程手册：www.unitymanual.com   
                else
                {
                    if (m < (coml - 1))
                    {
                        if (dires[(n - 1) * coml + m].z == 1 && dires[n * coml + (m + 1)].w == 1)
                        {
                            TF[n * coml + m] = 1;
                            if (TF[(n - 1) * coml + m] == 1)
                            {
                                m++;
                            }
                            if (TF[n * coml + (m + 1)] == 1)
                            {
                                n--;
                            }
                        }
                    }
                }

                break;
            //第二种类型的图片 向上+向下  
            // if(dires[n*coml+m].x==1&&dires[n*coml+m].z==1){  
            case 5:
                if (n == 0)
                {
                    if (m == 0)
                    {
                        TF[n * coml + m] = 1;
                        n++;
                    }
                }
                else if (n > 0 && n < (row - 1))
                {
                    if (dires[(n - 1) * coml + m].z == 1 && dires[(n + 1) * coml + m].x == 1)
                    {
                        TF[n * coml + m] = 1;
                        if (TF[(n - 1) * coml + m] == 1)
                        {
                            n++;
                        }
                        if (TF[(n + 1) * coml + m] == 1)
                        {
                            n--;
                        }
                    }
                }
                else
                {
                    if (m == (coml - 1))
                    {
                        print("1:win!!!");
                        iswin = true;
                    }
                } //Unity3D教程手册：www.unitymanual.com   
                break;
            //第三种类型的图片 向上+向左  
            // if(dires[n*coml+m].x==1&&dires[n*coml+m].w==1){  
            case 4:
                if (n > 0 && m > 0)
                {
                    if (dires[(n - 1) * coml + m].z == 1 && dires[n * coml + (m - 1)].w == 1)
                    {
                        TF[n * coml + m] = 1;
                        if (TF[(n - 1) * coml + m] == 1)
                        {
                            m--;
                        }
                        if (TF[n * coml + (m - 1)] == 1)
                        {
                            n--;
                        }
                    }
                }
                break;
            //第四种类型的图片 向右+向下  
            // if(dires[n*coml+m].y==1&&dires[n*coml+m].z==1){  
            case 2:
                if (n < (row - 1) && m < (coml - 1))
                {
                    if (dires[(n + 1) * coml + m].x == 1 && dires[n * coml + (m + 1)].w == 1)
                    {
                        TF[n * coml + m] = 1;
                        if (TF[(n + 1) * coml + m] == 1)
                        {
                            m++;
                        }
                        if (TF[n * coml + (m + 1)] == 1)
                        {
                            n++;
                        }
                    }
                }

                break;
            //第五种类型的图片 向右+向左  
            //  if(dires[n*coml+m].y==1&&dires[n*coml+m].w==1){  
            case 6:
                if (m > 0 && m < (coml - 1))
                {
                    if (dires[n * coml + (m - 1)].y == 1 && dires[n * coml + (m + 1)].w == 1)
                    {
                        TF[n * coml + m] = 1;
                        if (TF[n * coml + (m - 1)] == 1)
                        {
                            m++;
                        }
                        if (TF[n * coml + (m + 1)] == 1)
                        {
                            m--;
                        }
                    }
                }
                //Unity3D教程手册：www.unitymanual.com   
                break;
            //第六种类型的图片 向下+向左  
            //if(dires[n*coml+m].z==1&&dires[n*coml+m].w==1){  
            case 3:
                if (n == (row - 1) && m == (coml - 1))
                {
                    print("2:win!!!");
                    iswin = true;
                }
                if (m > 0 && n < (row - 1))
                {
                    if (dires[n * coml + (m - 1)].y == 1 && dires[(n + 1) * coml + m].x == 1)
                    {
                        TF[n * coml + m] = 1;
                        if (TF[n * coml + (m - 1)] == 1)
                        {
                            n++;
                        }
                        if (TF[(n + 1) * coml + m] == 1)
                        {
                            m--;
                        }
                    }
                }

                break;
        }

        if (iswin)
        {
            print("i win dlnuchunge");
        }
        print("n:" + n + "--m:" + m);

        for (int a = 0; a < 32; a++)
        {
            print(a + ":" + TF[a]);
        }
    }

}