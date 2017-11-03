/*
Necromancer GUI Demo Script
Author: Jason Wentzel
jc_wentzel@ironboundstudios.com

In this script you'll find some handy little functions for some of the 
Custom elements in the skin, these should help you create your own;

AddSpikes (not perfect but works well enough if youre careful with your window widths)
FancyTop (just an example of using the elements to do a centered header graphic)
WaxSeal (adds the waxseal and ribbon to the right of the window)
DeathBadge (adds the iconFrame, skull, and ribbon elements properly aligned)

*/

var doWindow0 = true;
var doWindow1 = true;
var doWindow2 = true;
var doWindow3 = true;
var doWindow4 = true;

private var leafOffset;
private var frameOffset;
private var skullOffset;

private var RibbonOffsetX;
private var FrameOffsetX;
private var SkullOffsetX;
private var RibbonOffsetY;
private var FrameOffsetY;
private var SkullOffsetY;

private var WSwaxOffsetX;
private var WSwaxOffsetY;
private var WSribbonOffsetX;
private var WSribbonOffsetY;
	
private var spikeCount;


var mySkin : GUISkin;

//定义第一个窗口
private var windowRect0 = Rect (500, 140, 350, 510);
//定义第二个窗口
private var windowRect1 = Rect (380, 40, 262, 420);
//定义第三个窗口
private var windowRect2 = Rect (700, 40, 306, 480);
//定义第四个窗口
private var windowRect3 = Rect (0, 40, 350, 500);

private var scrollPosition : Vector2;
private var HroizSliderValue = 0.5;
private var VertSliderValue = 0.5;
private var ToggleBTN = false;

//GUISkin的创建
private var NecroText ="GUISkin的创建可以右击Assets，依次打开菜单栏的Creat→GUISkin，如需在你的图形用户界面中使用图形用户界面皮肤，你必须使用一个简单的脚本去读取和使用皮肤到你的控件。";


function AddSpikes(winX)
{
	spikeCount = Mathf.Floor(winX - 152)/22;
	GUILayout.BeginHorizontal();
	GUILayout.Label ("", "SpikeLeft");//自定义样式
	for (i = 0; i < spikeCount; i++)
        {
			GUILayout.Label ("", "SpikeMid");//自定义样式
        }
	GUILayout.Label ("", "SpikeRight");//自定义样式
	GUILayout.EndHorizontal();
}

function FancyTop(topX)
{
	leafOffset = (topX/2)-64;
	frameOffset = (topX/2)-27;
	skullOffset = (topX/2)-20;
	GUI.Label(new Rect(leafOffset, 18, 0, 0), "", "GoldLeaf");//自定义样式	
	GUI.Label(new Rect(frameOffset, 3, 0, 0), "", "IconFrame");//自定义样式	
	GUI.Label(new Rect(skullOffset, 12, 0, 0), "", "Skull");//自定义样式	
}

function WaxSeal(x,y)
{
	WSwaxOffsetX = x - 120;
	WSwaxOffsetY = y - 115;
	WSribbonOffsetX = x - 114;
	WSribbonOffsetY = y - 83;
	
	GUI.Label(new Rect(WSribbonOffsetX, WSribbonOffsetY, 0, 0), "", "RibbonBlue");//自定义样式	
	GUI.Label(new Rect(WSwaxOffsetX, WSwaxOffsetY, 0, 0), "", "WaxSeal");//自定义样式	
}

function DeathBadge(x,y)
{
	RibbonOffsetX = x;
	FrameOffsetX = x+3;
	SkullOffsetX = x+10;
	RibbonOffsetY = y+22;
	FrameOffsetY = y;
	SkullOffsetY = y+9;
	
	GUI.Label(new Rect(RibbonOffsetX, RibbonOffsetY, 0, 0), "", "RibbonRed");//自定义样式	
	GUI.Label(new Rect(FrameOffsetX, FrameOffsetY, 0, 0), "", "IconFrame");//自定义样式	
	GUI.Label(new Rect(SkullOffsetX, SkullOffsetY, 0, 0), "", "Skull");//自定义样式	
}

function DoMyWindow0 (windowID : int) 
{
	// 调用AddSpikes函数增加道钉，参数值传递窗口的宽度
	
		AddSpikes(windowRect0.width);

		GUILayout.BeginVertical();
		GUILayout.Space(8);
		GUILayout.Label("", "Divider");//自定义样式
        GUILayout.Label("标准标签");
		GUILayout.Label("短标签", "ShortLabel");//自定义样式
		GUILayout.Label("", "Divider");//自定义样式
		GUILayout.Button("标准按钮");
		GUILayout.Button("短按钮", "ShortButton");//自定义样式
		GUILayout.Label("", "Divider");//自定义样式
		ToggleBTN = GUILayout.Toggle(ToggleBTN, "这是一个切换按钮");
		GUILayout.Label("", "Divider");//自定义样式
		GUILayout.Box("文本区域\n 可以扩展使用 \n");
		GUILayout.TextField("文本域（单行）");
        GUILayout.TextArea("文本区（多行）");
		GUILayout.EndVertical();
		
		// 使GUI界面能够拖拽
		GUI.DragWindow (Rect (0,0,10000,10000));
}

function DoMyWindow1 (windowID : int) 
{
		// 调用AddSpikes函数增加道钉，参数值传递窗口的宽度
		AddSpikes(windowRect1.width);
		
		GUILayout.BeginVertical();
		GUILayout.Label ("", "Divider");//自定义样式
		GUILayout.Label ("清晰文本", "PlainText");//----自定义样式
		
		GUILayout.Label ("发亮文本", "LightText");//---自定义样式
		GUILayout.Label ("粗体文本", "BoldText");//-----自定义样式
		
		GUILayout.Label ("轮廓文本", "OutlineText");//--------------------------- custom
		
		GUILayout.Label ("光轮廓文本", "LightOutlineText");//---自定义样式
		GUILayout.Label ("清晰轮廓文本", "BoldOutlineText");//----------------- custom
		GUILayout.EndVertical();
		// 使窗口能够进行拖动
		GUI.DragWindow (Rect (0,0,10000,10000));
}

function DoMyWindow2 (windowID : int) 
{
		// 调用AddSpikes函数增加道钉，参数值传递窗口的宽度
		AddSpikes(windowRect2.width);

		GUILayout.Space(8);
		GUILayout.BeginVertical();
		GUILayout.BeginHorizontal();
		scrollPosition = GUILayout.BeginScrollView(scrollPosition, true, true);
        GUILayout.Label (NecroText, "PlainText");
        GUILayout.EndScrollView();
		GUILayout.EndHorizontal();
		GUILayout.Space(8);
		HroizSliderValue = GUILayout.HorizontalSlider(HroizSliderValue, 0.0, 1.1);
        VertSliderValue = GUILayout.VerticalSlider(VertSliderValue, 0.0, 1.1, GUILayout.Height(70));
		DeathBadge(200,350);
        GUILayout.EndVertical();
		GUI.DragWindow (Rect (0,0,10000,10000));
}


function DoMyWindow3 (windowID : int) 
{
		// 调用AddSpikes函数增加道钉，参数值传递窗口的宽度
		AddSpikes(windowRect3.width);
		
		//add a fancy top using the fancy top function
		FancyTop(windowRect0.width);

		GUILayout.Space(8);
		GUILayout.BeginVertical();
		GUILayout.Label("Necromancer GUI案例");
		GUILayout.Label ("感谢Necromancer的开发人员Jason Wentzel为\n本书提供素材。", "Divider");
		GUILayout.Label ("", "LightText");
		GUILayout.Label ("", "Divider");
		GUILayout.Space(8);
		doWindow0 = GUILayout.Toggle(doWindow0, "标准组件面板");
		doWindow1 = GUILayout.Toggle(doWindow1, "文本示例");
		doWindow2 = GUILayout.Toggle(doWindow2, "滚动条示例");
		GUILayout.Space(8);
		GUILayout.Label ("", "Divider");
        GUILayout.Label ("请仔细阅读该脚本", "PlainText");
		GUILayout.BeginHorizontal();
		GUILayout.Label ("熟练使用 ", "PlainText");
		GUILayout.Label ("GUI组件 ", "LegendaryText");
		GUILayout.Label ("与 ", "PlainText");
		GUILayout.Label ("GUI函数 ", "CursedText");
		GUILayout.Label ("!", "PlainText");
		GUILayout.EndHorizontal();
		GUILayout.Label ("", "Divider");
		GUILayout.Space(26);
		GUILayout.Label ("由Jason Wentzel创建于2011年", "SingleQuotes");
        GUILayout.EndVertical();
		
		//在窗口的底部增加WaxSeal样式 
		WaxSeal(windowRect3.width , windowRect3.height);
		
		GUI.DragWindow (Rect (0,0,10000,10000));
}

function OnGUI ()
{
GUI.skin = mySkin;

if (doWindow0)
	windowRect0 = GUI.Window (0, windowRect0, DoMyWindow0, "");
	//调整组的位置，（0,0）代表组在左上角的位置
	GUI.BeginGroup (Rect (0,0,100,100));
	// 结束上面开始的组. 这是非常重要的!
	GUI.EndGroup ();
	
if (doWindow1)
	windowRect1 = GUI.Window (1, windowRect1, DoMyWindow1, "");
	
	GUI.BeginGroup (Rect (0,0,100,100));
	
	GUI.EndGroup ();
	
if (doWindow2)
	windowRect2 = GUI.Window (2, windowRect2, DoMyWindow2, "");
	
	GUI.BeginGroup (Rect (0,0,100,100));
	
	GUI.EndGroup ();
	
if (doWindow3)
	windowRect3 = GUI.Window (3, windowRect3, DoMyWindow3, "");
	
	GUI.BeginGroup (Rect (0,0,100,100));
	
	GUI.EndGroup ();
}