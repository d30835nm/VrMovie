# VrMovie
360Video &amp; VR180 verification samples. (360動画およびVR180の検証サンプル集)

## サンプルシーン
### Assets\VrMovie\Scenes\VrMovieModeSwitcher.unity
モノラル・ステレオの360動画および180動画の4種類を切り替え比較できるシーン。
editor上で 左クリック か、 Oculus Goにビルドして Trigger or Pad で動画切り替え。
[VrMovieModeSwicher20190429v1.apk](https://drive.google.com/file/d/1iOH0zQ0I6VobwCIENdTosUb0M7u6JqUn/view?usp=sharing)

### Assets\VrMovie\Scenes\FpsSwitcher.unity
30fpsと60fpsのVR180動画の2種類を切り替え比較できるシーン。
editor上で 左クリック か、 Oculus Goにビルドして Trigger or Pad で動画切り替え。
60fpsの方が動画2週目以降がfpsが落ちている気配を感じる。
[FpsSwicher20190518v2.apk](https://drive.google.com/file/d/1ysGx2Oi4bz6Jwd8O-_oIzkv-LGFumeDU/view?usp=sharing)

### Assets\VrMovie\Scenes\VrMovieAndObjects.unity
VR180動画とオブジェクトを組み合わせて配置したシーン。
視差が発生しない部分にオブジェクトを配置することで、立体視破綻を防げる。
[VrMovieAndObjects20190518v1.apk](https://drive.google.com/file/d/1maTYUNgf81GhUVhnNsezoE1QgUYHq2Xa/view?usp=sharing)

## サンプル動画
### Assets\VrMovie\Videos\Sample01
モノラル・ステレオの360動画および180動画サンプル
VrMovieModeSwitcher.unityで利用

### Assets\VrMovie\Videos\Sample02
30および60fpsのVR180動画サンプル
FpsSwitcher.unityで利用

### Assets\VrMovie\Videos\Sample03
H265及びH264のVR180動画サンプル
利用シーンなし

### Assets\VrMovie\Videos\Sample04
人物+背景単色黒のVR180動画サンプル
VrMovieAndObjects.unityで利用