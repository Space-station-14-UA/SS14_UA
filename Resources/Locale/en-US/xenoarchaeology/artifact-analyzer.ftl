analysis-console-menu-title = Консоль аналізу Broad-Spectrum Mark 3
analysis-console-server-list-button = Список серверів
analysis-console-extract-button = Вилучити

analysis-console-info-no-scanner = Аналізатор не підключено! Будь ласка, підключіть його за допомогою мультитула.
analysis-console-info-no-artifact = Артефакт відсутній! Помістіть один на платформу і проскануйте.
analysis-console-info-ready = Системи працюють. Готовий до сканування.

analysis-console-no-node = Виберіть вузол для перегляду
analysis-console-info-id = [font="Monospace" size=11]ID:[/font]
analysis-console-info-id-value = [font="Monospace" size=11][color=yellow]{$id}[/color][/font]
analysis-console-info-class = [font="Monospace" size=11]Клас:[/font]
analysis-console-info-class-value = [font="Monospace" size=11]{$class}[/font]
analysis-console-info-locked = [font="Monospace" size=11]Статус:[/font]
analysis-console-info-locked-value = [font="Monospace" size=11][color={$state ->
    [0] red]Заблоковано
    [1] lime]Розблоковано
    *[2] plum]Активний
}[/color][/font]
analysis-console-info-durability = [font="Monospace" size=11]Міцність:[/font]
analysis-console-info-durability-value = [font="Monospace" size=11][color={$color}]{$current}/{$max}[/color][/font]
analysis-console-info-effect = [font="Monospace" size=11]Ефект:[/font]
analysis-console-info-effect-value = [font="Monospace" size=11][color=gray]{$state ->
    [true] {$info}
    *[false] Розблокуйте вузли, щоб отримати інформацію
}[/color][/font]
analysis-console-info-trigger = [font="Monospace" size=11]Тригери:[/font]
analysis-console-info-triggered-value = [font="Monospace" size=11][color=gray]{$triggers}[/color][/font]
analysis-console-info-scanner = Сканування...
analysis-console-info-scanner-paused = Призупинено.
analysis-console-progress-text = {$seconds ->
    [one] T-{$seconds} секунда
    *[other] T-{$seconds} секунд
}
analysis-console-extract-value = [font="Monospace" size=11][color=orange]Вузол {$id} (+{$value})[/color][/font]
analysis-console-extract-none = [font="Monospace" size=11][color=orange]У жодного з розблокованих вузлів немає балів для вилучення[/color][/font]
analysis-console-extract-sum = [font="Monospace" size=11][color=orange]Всього досліджень: {$value}[/color][/font]
analyzer-artifact-extract-popup = На поверхні артефакту мерехтить енергія!
