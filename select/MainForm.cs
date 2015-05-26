/*
 * Created by SharpDevelop.
 * User: fungchu
 * Date: 2014/11/2
 * Time: 下午 01:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
namespace select
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		string[] name1= {"王","江","江","周","林","林","張","張","張","張","梁","莊","許","許","郭","陳","曾","賀","黃","黃","黃","黃","黃","楊","溫","廖","熊","趙","劉","蔡"};
		int[] selected={0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
		string str = System.Windows.Forms.Application.StartupPath;
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			
			button1.Enabled=false;
			int check=0,i=0;
			for(i=0;i<30;i++)
			{
				if(selected[i]==0)
				{
					check=1;
				}
			}
			if(check==0)
			{
				MessageBox.Show("每個人都抽過一輪了耶!!那再來抽一輪吧~啾咪>wO","恭喜您");
				for(i=0;i<30;i++)
				{
					selected[i]=0;
				}
			}
			System.Media.SoundPlayer sp = new System.Media.SoundPlayer(Application.StartupPath+"\\music\\music.wav");
			System.Media.SoundPlayer sp2 = new System.Media.SoundPlayer(Application.StartupPath+"\\music\\surprise.wav");
			sp.Play(); 
			
			Random r= new Random();
			int i2,x1,x2,x3;
			for(i2=0;i2<=80;i2++)   //第一次
			{
				x1 =r.Next(0,30);
				x2 =r.Next(0,30);
				x3 =r.Next(0,30);
				this.Controls.Find("label1", false)[0].Text = name1[x1];

				Application.DoEvents(); //更新畫面
				Thread.Sleep(10);
				
				
			}		
			int finalx =r.Next(0,30);	
			while(selected[finalx]!=0) {
				finalx =r.Next(0,30);
			}			
			this.Controls.Find("label1", false)[0].Text = name1[finalx];
			selected[finalx]=1;
			sp2.Play(); 
			button1.Enabled=true;
		}
		

		
		void Button2Click(object sender, EventArgs e)
		{
			int count = 0,i=0;
			for(i=0;i<30;i++)
				{
					selected[i]=0;
				}
        	try{
        			// Read the file and display it line by line.
					System.IO.StreamReader file = new System.IO.StreamReader(@str + "\\students.txt");
					while((name1[count] = file.ReadLine()) != null)
					{
						//name1[count] = file.ReadLine();
						//MessageBox.Show(name[count]);
   						count++;
					}
					file.Close();
					
        		}
				catch(Exception)
				{
					//MessageBox.Show("Something went wrong.請檢查檔案students.txt是否有問題!!");
				}
				MessageBox.Show("同學姓名已讀取！");
					button1.Enabled = true;
				
			
				
		}
	}
}
