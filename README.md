# VTB-Music-Volume-Normalization
VTB Music 后端音量归一化处理模块
# 使用方法
- 运行音量归一化 VTB-Music 参数
```C#
Normalization normalization = new Normalization();
normalization.RunNormalizationForVTB("输入文件名称","输出文件名称",true); // 第三个参数为是否输出日志
```
- 运行音量归一化自定义参数
```C#
Normalization normalization = new Normalization();
normalization.RunNormalization("输入文件名称","输出文件名称","码率 例如:192k","音量大小 例如:-5dBm",true); // 最后一个参数为是否输出日志
```
# 注意事项
- 需要安装 Python 3.x
- 需要安装 ffmpeg 并添加到环境变量
- 需要安装 ffmpeg-normalize
