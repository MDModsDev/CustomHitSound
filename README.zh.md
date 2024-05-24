# CustomHitSound

玩家可以自制音效包替换游戏内打击音效

## 如何安装

安装 [Muse Dash Mod tools](https://github.com/MDModsDev/MuseDashModToolsUI/releases/latest), 跟着提示的流程安装mod。

然后从 [Releases](https://github.com/MDModsDev/CustomHitSound/releases/latest)里下载BattleSfx.zip, 解压到`Muse Dash\UserData` 文件夹.

最终路径应为`Muse Dash\UserData\BattleSfx`.

## 如何使用音效包

在游戏的声音设置的打击音效里有对应的下拉框，选择音效即可

## 如何创建自己的音效包

**在BattleSfx.zip里有默认的模板 (Celeste和Bandori).**

### 你可以替换很多种音效：

```
char_common_fever
char_common_empty_atk
char_common_empty_jump
sfx_hp
sfx_score
sfx_press_top
sfx_jump
sfx_mezzo_1
sfx_forte_2
sfx_piano_2
sfx_forte_3
sfx_mezzo_3
sfx_ghost_gc
hitsound_000
hitsound_001
hitsound_002
hitsound_003
hitsound_004
hitsound_005
hitsound_006
hitsound_007
hitsound_008
hitsound_009
hitsound_010
hitsound_011
hitsound_012
hitsound_013
hitsound_014
hitsound_015
```

### 对于打击音效的名字，你可以参考下面的表格：

```
sfx_forte_2 = 大型2，boss冲撞
sfx_forte_3 = 锤子
sfx_mezzo_1 = 小型，中型，双押，boss子弹
sfx_mezzo_3 = 幽灵
sfx_piano_2 = 大型1，突袭
sfx_hp = 红心
sfx_score = 蓝音符
sfx_press_top = 长条头/尾
sfx_press = 长条中间
sfx_ghost_gc = Groove Coaster的幽灵
hitsound = 连打 
```

### 还可以替换人物受伤音效

#### 玛莉嘉：

```
VoiceMarijaHurt02
VoiceMarijaHurt03
VoiceMarijaHurt04
VoiceMarijaHurt05
VoiceMarijaHurt06
VoiceMarijaHurt07
VoiceMarijaHurt08
VoiceMarijaHurt09

VoiceCatMarijaHurt
```

#### 凛：

```
VoiceRinHurt01
VoiceRinHurt02
VoiceRinHurt03
VoiceRinHurt06
VoiceRinHurt09
VoiceRinHurt10
VoiceRinHurt11

VoiceCatRinHurt
```

#### 布若：

```
VoiceBuroHurt01
VoiceBuroHurt03
VoiceBuroHurt05
VoiceBuroHurt06
VoiceBuroHurt07
VoiceBuroHurt08
VoiceBuroHurt10

VoiceCatBuroHurt
```

#### 欧拉：

```
VoiceOlaHurt01
VoiceOlaHurt02
VoiceOlaHurt03
VoiceOlaHurt04
VoiceOlaHurt05
```

#### 柚梅：

```
VoiceYumeHurt01
VoiceYumeHurt02
VoiceYumeHurt03
VoiceYumeHurt04
VoiceYumeHurt05
VoiceYumeHurt06
VoiceYumeHurt07
```

#### Neko：

```
VoiceNekoHurt01
VoiceNekoHurt02
VoiceNekoHurt03
VoiceNekoHurt04
VoiceNekoHurt05
```

#### 博丽灵梦：

```
VoiceReimuHurt01
VoiceReimuHurt02
VoiceReimuHurt03
VoiceReimuHurt04
VoiceReimuHurt05
```

#### El_Clear：

```
VoiceClearHurt02
VoiceClearHurt04
VoiceClearHurt06
VoiceClearHurt07
VoiceClearHurt08
VoiceClearHurt10
```

#### 雾雨魔理沙：

```
VoiceMarisaHurt01
VoiceMarisaHurt02
VoiceMarisaHurt03
VoiceMarisaHurt04
VoiceMarisaHurt05
```

#### 阿米娅：

```
VoiceAmiyaHurt01
VoiceAmiyaHurt02
VoiceAmiyaHurt03
VoiceAmiyaHurt04
VoiceAmiyaHurt05
```

#### 道士布若：

```
char_exorcist_empty_atk

VoiceExorcistHurt01
VoiceExorcistHurt02
VoiceExorcistHurt03
VoiceExorcistHurt04
VoiceExorcistHurt05
```

### 命名规则

**你需要把文件命名为以下的格式：**

**音效名称_<小写或大写的文件夹名字>.wav (或者是mp3，aiff，ogg)**

例子：Celeste文件夹里的`sfx_forte_2_celeste.wav` （也可以命名为`sfx_forte_2_Celeste.wav`）

### Debug 模式

Debug模式会在控制台输出对应音频文件的名称和所用的路径，可以用来检测是否使用了正确的音频文件

打开UserData底下的Custom Hit Sound.cfg文件，路径应为`MuseDash\UserData\Custom Hit Sound.cfg`. 然后改成DebugModeEnabled = true

### 如果你没有替换对应音效游戏会使用默认音效

### 另

**如果你想要把你的音效包加到默认里，可以discord或者qq找我**