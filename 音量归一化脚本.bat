@echo off
echo ע:��Ҫ��װ FFmpeg �� FFmpeg-normalize
echo �ļ��ᱻ����� normalized �ļ���
echo ������������������������������������
for %%i in (*.mp3) do (
	echo ���ڵ��� "%%i" ������
	ffmpeg-normalize "%%i" -nt peak -t -5 -c:a libmp3lame -b:a 192k -ext mp3
	echo ���!
	echo ��������������������������������
)
echo ȫ���������!��������˳�
pause >nul