#pragma strict

//X轴的移动位置
var posX:float;
//Y轴的移动位置
var posY:float;
//Z轴的移动位置
var posZ:float;

function Start () {

}

function Update () {
	//设置移动的范围
	var x:float = Time.deltaTime*3;
	var y:float = Time.deltaTime*2;
	var z:float = Time.deltaTime*1;
	//移动的方向X轴
	transform.Translate(x,y,z);
	//赋值计算模型在三维坐标系中的位置
	posX += x;
	posY += y;
	posZ += z;
}
function OnGUI () {  
 
  //将坐标信息显示在3D屏幕中
  GUI.Label(Rect(50, 50,200,20),"x pos is" + posX +"float");  
  GUI.Label(Rect(50, 70,200,20),"y pos is" + posY +"float");  
  GUI.Label(Rect(50, 90,200,20),"z pos is" + posZ +"float");  
 
}