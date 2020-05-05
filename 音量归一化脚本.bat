@echo off
echo 注:需要安装 FFmpeg 和 FFmpeg-normalize
echo 文件会被输出到 normalized 文件夹
echo ——————————————————
for %%i in (*.mp3) do (
	echo 正在调整 "%%i" 的音量
	ffmpeg-normalize "%%i" -nt peak -t -5 -c:a libmp3lame -b:a 192k -ext mp3
	echo 完成!
	echo ————————————————
)
echo 全部处理完成!按任意键退出
pause >nul