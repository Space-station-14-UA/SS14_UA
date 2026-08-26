anomaly-component-contact-damage = Аномалія обпікає вашу шкіру!

anomaly-vessel-component-anomaly-assigned = Аномалія прив'язана до накопичувача.
anomaly-vessel-component-not-assigned = До цього накопичувача не прив'язано жодної аномалії. Спробуйте використати на ньому сканер.
anomaly-vessel-component-assigned = До цього накопичувача прив'язана аномалія.

anomaly-particles-delta = Дельта частинки
anomaly-particles-epsilon = Епсілон частинки
anomaly-particles-zeta = Зета частинки
anomaly-particles-omega = Омега частинки
anomaly-particles-sigma = Сігма частинки

anomaly-scanner-component-scan-complete = Сканування завершено!

anomaly-scanner-ui-title = Сканер аномалій
anomaly-scanner-no-anomaly = Наразі аномалію не відскановано.
anomaly-scanner-severity-percentage = Поточний ступінь небезпеки: [color=gray]{$percent}[/color]
anomaly-scanner-severity-percentage-unknown = Поточний ступінь небезпеки: [color=red]ПОМИЛКА[/color]
anomaly-scanner-stability-low = Поточний стан аномалії: [color=gold]Розпад[/color]
anomaly-scanner-stability-medium = Поточний стан аномалії: [color=forestgreen]Стабільна[/color]
anomaly-scanner-stability-unknown = Поточний стан аномалії: [color=red]ПОМИЛКА[/color]
anomaly-scanner-stability-high = Поточний стан аномалії: [color=crimson]Ріст[/color]
anomaly-scanner-point-output = Прибилизна генерація балів: [color=gray]{$point}[/color]
anomaly-scanner-point-output-unknown = Прибилизна генерація балів: [color=red]ПОМИЛКА[/color]
anomaly-scanner-particle-readout = Реакція аномалії на частинки:
anomaly-scanner-particle-danger = - [color=crimson]Небезпечний тип:[/color] {$type}
anomaly-scanner-particle-unstable = - [color=plum]Нестабільний тип:[/color] {$type}
anomaly-scanner-particle-containment = - [color=goldenrod]Стримуючий тип:[/color] {$type}
anomaly-scanner-particle-transformation = - [color=#6b75fa]Тип трансформації:[/color] {$type}
anomaly-scanner-particle-danger-unknown = - [color=crimson]Тип небезпеки:[/color] [color=red]ПОМИЛКА[/color]
anomaly-scanner-particle-unstable-unknown = - [color=plum]Тип нестабільності:[/color] [color=red]ПОМИЛКА[/color]
anomaly-scanner-particle-containment-unknown = - [color=goldenrod]Тип стримування:[/color] [color=red]ПОМИЛКА[/color]
anomaly-scanner-particle-transformation-unknown = - [color=#6b75fa]Тип трансформації:[/color] [color=red]ПОМИЛКА[/color]
anomaly-scanner-pulse-timer = Час до наступного імпульсу: [color=gray]{$time}[/color]
anomaly-scanner-doafter-examine = { CAPITALIZE(SUBJECT($user)) } [color=plum]сканує аномалію[/color].

anomaly-gorilla-core-slot-name = Ядро аномалії
anomaly-gorilla-charge-none = Немає [bold]ядра аномалії[/bold] в середині цього.
anomaly-gorilla-charge-limit = Має [color={$count ->
    [3]green
    [2]yellow
    [1]orange
    [0]red
    *[other]purple
}]{$count} {$count ->
    [one]заряд
    *[other]зарядів
}[/color] remaining.
anomaly-gorilla-charge-infinite = Має [color=gold]нескінченні заряди[/color]. [italic]Поки що...[/italic]

anomaly-sync-connected = Аномалію успішно прикріплено
anomaly-sync-disconnected = Зв'язок з аномалією втрачено!
anomaly-sync-no-anomaly = Немає аномалії в діапазоні.
anomaly-sync-examine-connected = Це [color=darkgreen]приєднано[/color] до аномалії.
anomaly-sync-examine-not-connected = Це [color=darkred]не приєднано[/color] до аномалії.
anomaly-sync-connect-verb-text = Прикріпити аномалію
anomaly-sync-connect-verb-message = Додати сусідню аномалію до {$machine}.
anomaly-sync-disconnect-verb-text = Від'єднати аномалію
anomaly-sync-disconnect-verb-message = Від'єднати підключену аномалію від {$machine}.

anomaly-generator-ui-title = Генератор Аномалій
anomaly-generator-fuel-display = Паливо:
anomaly-generator-cooldown = Охолодження: [color=gray]{$time}[/color]
anomaly-generator-no-cooldown = Охолодження: [color=gray]Завершено[/color]
anomaly-generator-yes-fire = Статус: [color=forestgreen]Готовий[/color]
anomaly-generator-no-fire = Статус: [color=crimson]Не готовий[/color]
anomaly-generator-generate = Згенерувати аномалію
anomaly-generator-charges = {$charges ->
    [one] {$charges} заряд
    *[other] {$charges} зарядів
}
anomaly-generator-announcement = Аномалія була сгенерована!

anomaly-command-pulse = Пульсує цільову аномалію
anomaly-command-supercritical = Робить цільову аномалію надкритичною

# Flavor text on the footer
anomaly-generator-flavor-left = Аномалія може створитися всередині оператора.
anomaly-generator-flavor-right = v1.1

anomaly-behavior-unknown = [color=red]ПОМИЛКА. Неможливо прочитати.[/color]

anomaly-behavior-title = аналіз поведінкових відхилень:
anomaly-behavior-point = [color=gold]Аномалія створює {$mod}% балів[/color]

anomaly-behavior-safe = [color=forestgreen]Аномалія надзвичайно стабільна. Надзвичайно рідкісна пульсація.[/color]
anomaly-behavior-slow = [color=forestgreen]Частота пульсацій набагато рідша.[/color]
anomaly-behavior-light = [color=forestgreen]Потужність пульсації значно знижена.[/color]
anomaly-behavior-balanced = Відхилень у поведінці не виявлено.
anomaly-behavior-delayed-force = Частота пульсацій значно знижена, але їх потужність збільшена.
anomaly-behavior-rapid = Частота пульсації значно вища, але її сила послаблена.
anomaly-behavior-reflect = Було виявлено захисне покриття.
anomaly-behavior-nonsensivity = Виявлено слабку реакцію на частинки.
anomaly-behavior-sensivity = Виявлено посилену реакцію на частинки.
anomaly-behavior-invisibility = Виявлено спотворення світлової хвилі.
anomaly-behavior-secret = Виявлено втручання. Деякі дані неможливо прочитати
anomaly-behavior-inconstancy = [color=crimson]Виявлено непостійність. Типи частинок можуть змінюватися з часом.[/color]
anomaly-behavior-fast = [color=crimson]Частота пульсації сильно підвищена.[/color]
anomaly-behavior-strenght = [color=crimson]Потужність пульсації значно збільшена.[/color]
anomaly-behavior-moving = [color=crimson]Виявлено нестабільність координат.[/color]
anomaly-secret-admin = [color=red](ERROR)[/color]
