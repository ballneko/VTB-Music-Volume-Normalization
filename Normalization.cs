using System;
using System.Diagnostics;

namespace VTB_Music_Volume_Normalization
{
    public class Normalization
    {
        /// <summary>
        /// 运行音量归一化处理 VTB-Music 版
        /// </summary>
        /// <param name="mediaFileName">输入媒体文件名称</param>
        /// <param name="outPutFileName">输出媒体文件名称</param>
        /// <param name="isLog">是否返回日志</param>
        /// <returns></returns>
        public string RunNormalizationForVTB(string mediaFileName, string outPutFileName, bool isLog)
        {
            // 运行 ffmpeg-normalize 并保存输出信息
            string Log = RunCommand("ffmpeg-normalize " + mediaFileName + " -nt peak -t -5 -c:a libmp3lame -b:a 192k -ext " + outPutFileName);
            // 判断是否返回日志
            if (isLog == true)
            {
                return Log;
            }
            return "";
        }

        /// <summary>
        /// 运行音量归一化处理自定义版
        /// </summary>
        /// <param name="mediaFileName">输入媒体文件名称</param>
        /// <param name="outPutFileName">输出媒体文件名称</param>
        /// <param name="Kbps">码率</param>
        /// <param name="Dbm">音量东西</param>
        /// <param name="isLog">是否返回日志</param>
        /// <returns></returns>
        public string RunNormalization(string mediaFileName,string outPutFileName,string Kbps,string Dbm,bool isLog)
        {
            // 运行 ffmpeg-normalize 并保存输出信息
            string Log = RunCommand("ffmpeg-normalize "+mediaFileName+ " -nt peak -t "+Dbm+ " -c:a libmp3lame -b:a "+Kbps +" -ext "+outPutFileName);
            // 判断是否返回日志
            if (isLog == true)
            {
                return Log;
            }
            return "";
        }

        /// <summary>
        /// 运行命令
        /// </summary>
        /// <param name="command">运行命令</param>
        /// <returns></returns>
        static string RunCommand(string command)
        {
            Process p = new Process();
            //设置要启动的应用程序
            p.StartInfo.FileName = command;
            //是否使用操作系统shell启动
            p.StartInfo.UseShellExecute = false;
            // 接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardInput = true;
            //输出信息
            p.StartInfo.RedirectStandardOutput = true;
            // 输出错误
            p.StartInfo.RedirectStandardError = true;
            // 不显示程序窗口
            p.StartInfo.CreateNoWindow = true;
            // 启动程序
            p.Start();
            p.StandardInput.AutoFlush = true;

            //获取输出信息
            string strOuput = p.StandardOutput.ReadToEnd();
            //等待程序执行完退出进程
            p.WaitForExit();
            p.Close();
            // 返回输出信息
            return strOuput;
        }
    }
}
