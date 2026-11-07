markings-search = Пошук
-markings-selection = { $selectable ->
    [0] У вас не залишилося доступних відміток.
    [one] Ви можете обрати ще одну відмітку.
   *[other] Ви можете обрати ще { $selectable } відміток.
}
markings-limits = { $required ->
    [true] { $count ->
        [-1] Оберіть принаймні одну відмітку.
        [0] Ви не можете обирати відмітки, але чомусь мусите? Це помилка.
        [one] Оберіть одну відмітку.
       *[other] Оберіть принаймні одну і до {$count} відміток. { -markings-selection(selectable: $selectable) }
    }
   *[false] { $count ->
        [-1] Оберіть будь-яку кількість відміток.
        [0] Ви не можете обирати відмітки.
        [one] Оберіть до однієї відмітки.
       *[other] Оберіть до {$count} відміток. { -markings-selection(selectable: $selectable) }
    }
}
markings-reorder = Змінити порядок відміток

humanoid-marking-modifier-respect-limits = Дотримуватися лімітів
humanoid-marking-modifier-respect-group-sex = Дотримуватися обмежень групи та статі
humanoid-marking-modifier-base-layers = Базові шари
humanoid-marking-modifier-enable = Увімкнути
humanoid-marking-modifier-prototype-id = ID прототипу:

# Categories

markings-organ-Torso = Тулуб
markings-organ-Head = Голова
markings-organ-ArmLeft = Ліва рука
markings-organ-ArmRight = Права рука
markings-organ-HandRight = Права кисть
markings-organ-HandLeft = Ліва кисть
markings-organ-LegLeft = Ліва нога
markings-organ-LegRight = Права нога
markings-organ-FootLeft = Ліва стопа
markings-organ-FootRight = Права стопа
markings-organ-Eyes = Очі

markings-layer-Special = Спеціальне
markings-layer-Tail = Хвіст
markings-layer-Tail-Moth = Крила
markings-layer-Hair = Зачіска
markings-layer-FacialHair = Рослинність на обличчі
markings-layer-UndergarmentTop = Майка
markings-layer-UndergarmentBottom = Труси
markings-layer-Chest = Груди
markings-layer-Head = Голова
markings-layer-Snout = Морда
markings-layer-SnoutCover = Морда (Покриття)
markings-layer-HeadSide = Голова (Збоку)
markings-layer-HeadTop = Голова (Зверху)
markings-layer-Eyes = Очі
markings-layer-OverEyes = Поверх очей
markings-layer-RArm = Права рука
markings-layer-LArm = Ліва рука
markings-layer-RHand = Права кисть
markings-layer-LHand = Ліва кисть
markings-layer-RLeg = Права нога
markings-layer-LLeg = Ліва нога
markings-layer-RFoot = Права стопа
markings-layer-LFoot = Ліва стопа
markings-layer-Overlay = Оверлей
markings-layer-TailOverlay = Оверлей
