device-pda-slot-component-slot-name-cartridge = Картридж

default-program-name = Програма
notekeeper-program-name = Нотатоник
nano-task-program-name = НаноТаск
news-read-program-name = Новини станції

crew-manifest-program-name = Маніфест екіпажу
crew-manifest-cartridge-loading = Завантаження ...
crew-manifest-cartridge-loading-failed = Не вдалося завантажити маніфест екіпажу!

net-probe-program-name = НетПроб
net-probe-scan = Проскановано {$device}!
net-probe-label-name = Назва
net-probe-label-address = Адреса
net-probe-label-frequency = Частота
net-probe-label-network = Мережа

log-probe-program-name = ЛогПроб
log-probe-scan = Завантажені логи з {$device}!
log-probe-label-time = Час
log-probe-label-accessor = Ким використано
log-probe-label-number = #
log-probe-print-button = Друк логів
log-probe-printout-device = Просканований пристрій: {$name}
log-probe-printout-header = Останні логи:
log-probe-printout-entry = #{$number} / {$time} / {$accessor}

astro-nav-program-name = АстроНав

med-tek-program-name = МедТек

# NanoTask cartridge

nano-task-ui-heading-high-priority-tasks =
    { $amount ->
        [zero] Завдань з високим пріоритетом немає
        [one] 1 Завдання з високим пріоритетом
       *[other] {$amount} Завдання з високим пріоритетом
    }
nano-task-ui-heading-medium-priority-tasks =
    { $amount ->
        [zero] Завдань з середнім пріоритетом немає
        [one] 1 Завданя з середнім пріоритетом
       *[other] {$amount} Завдання з середнім пріоритетом
    }
nano-task-ui-heading-low-priority-tasks =
    { $amount ->
        [zero] Завдань з низьким пріоритетом немає
        [one] 1 Завдання з низьким пріоритетом
       *[other] {$amount} Задвання з низьким пріоритетом
    }
nano-task-ui-done = Виконано
nano-task-ui-revert-done = Повернути
nano-task-ui-priority-low = Низький
nano-task-ui-priority-medium = Середній
nano-task-ui-priority-high = Високий
nano-task-ui-cancel = Скасувати
nano-task-ui-print = Друкувати
nano-task-ui-delete = Видалити
nano-task-ui-save = Зберегти
nano-task-ui-new-task = Нове завдання
nano-task-ui-description-label = Опис:
nano-task-ui-description-placeholder = Зробити щось важливе
nano-task-ui-requester-label = Замовник:
nano-task-ui-requester-placeholder = Джон Нанотрейзен
nano-task-ui-item-title = Редагувати завдання
nano-task-printed-description = [bold]Опис[/bold]: {$description}
nano-task-printed-requester = [bold]Замовник[/bold]: {$requester}
nano-task-printed-high-priority = [bold]Пріоритет[/bold]: [color=red]Високий[/color]
nano-task-printed-medium-priority = [bold]Пріоритет[/bold]: Середній
nano-task-printed-low-priority = [bold]Пріоритет[/bold]: Низький

# Wanted list cartridge
wanted-list-program-name = Список розшуку
wanted-list-label-no-records = Все гаразд, ковбою
wanted-list-search-placeholder = Пошук за ім'ям та статусом

wanted-list-age-label = [color=darkgray]Вік:[/color] [color=white]{$age}[/color]
wanted-list-job-label = [color=darkgray]Посада:[/color] [color=white]{$job}[/color]
wanted-list-species-label = [color=darkgray]Вид:[/color] [color=white]{$species}[/color]
wanted-list-gender-label = [color=darkgray]Гендер:[/color] [color=white]{$gender}[/color]

wanted-list-reason-label = [color=darkgray]Причина:[/color] [color=white]{$reason}[/color]
wanted-list-unknown-reason-label = невідома причина

wanted-list-initiator-label = [color=darkgray]Ініціатор:[/color] [color=white]{$initiator}[/color]
wanted-list-unknown-initiator-label = невідомий ініціатор

wanted-list-status-label = [color=darkgray]статус:[/color] {$status ->
        [suspected] [color=yellow]підозрюваний[/color]
        [wanted] [color=red]розшукується[/color]
        [detained] [color=#b18644]затриманий[/color]
        [paroled] [color=green]достроково зв.[/color]
        [discharged] [color=green]звільнений[/color]
        [hostile] [color=darkred]ворожий[/color]
        [eliminated] [color=gray]ліквідований[/color]
        *[other] ніякого
    }

wanted-list-history-table-time-col = Час
wanted-list-history-table-reason-col = Злочин
wanted-list-history-table-initiator-col = Ініціатор
