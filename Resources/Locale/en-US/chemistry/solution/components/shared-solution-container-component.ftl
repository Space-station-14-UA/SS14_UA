shared-solution-container-component-on-examine-main-text = Містить [color={$color}]{$desc}[/color] { $chemCount ->
    [1] речовину.
   *[other] хімічну суміш.
    }

examinable-solution-has-recognizable-chemicals = Ви впізнаєте {$recognizedString} у розчині.
examinable-solution-recognized = [color={$color}]{$chemical}[/color]

examinable-solution-on-examine-volume = Об'єм розчину { $fillLevel ->
    [exact] становить [color=white]{$current}/{$max}u[/color].
   *[other] [bold]{ -solution-vague-fill-level(fillLevel: $fillLevel) }[/bold].
}

examinable-solution-on-examine-volume-no-max = Об'єм розчину { $fillLevel ->
    [exact] становить[color=white]{$current}u[/color].
   *[other] [bold]{ -solution-vague-fill-level(fillLevel: $fillLevel) }[/bold].
}

examinable-solution-on-examine-volume-puddle = Рідина { $fillLevel ->
    [exact] [color=white]{$current}u[/color].
    [full] величезна та переповнена!
    [mostlyfull] величезна та переповнена!
    [halffull] глибока та плинна.
    [halfempty] дуже глибока.
   *[mostlyempty] збирається докупи.
    [empty] утворює кілька малих калюжок.
}

-solution-vague-fill-level =
    { $fillLevel ->
        [full] [color=white]Повний[/color]
        [mostlyfull] [color=#DFDFDF]Майже повний[/color]
        [halffull] [color=#C8C8C8]Наполовину повний[/color]
        [halfempty] [color=#C8C8C8]Наполовину порожній[/color]
        [mostlyempty] [color=#A4A4A4]Переважно порожній[/color]
       *[empty] [color=gray]Порожній[/color]
    }
