## UI
cargo-console-menu-title = Консоль подачі заявок на вантаж
cargo-console-menu-flavor-left = Замовте більше коробок піцци ніж зазвичай!
cargo-console-menu-flavor-right = v2.1
cargo-console-menu-account-name-label = Акаунт:{" "}
cargo-console-menu-account-name-none-text = Немає
cargo-console-menu-account-name-format = [bold][color={$color}]{$name}[/color][/bold] [font="Monospace"]\[{$code}\][/font]
cargo-console-menu-shuttle-name-label = Ім'я шатла:{" "}
cargo-console-menu-shuttle-name-none-text = Немає
cargo-console-menu-points-label = Баланс:{" "}
cargo-console-menu-points-amount = ${$amount}
cargo-console-menu-shuttle-status-label = Статус шатла:{" "}
cargo-console-menu-shuttle-status-away-text = Відсутній
cargo-console-menu-order-capacity-label = Місткість замовлення:{" "}
cargo-console-menu-order-capacity-number = {$count}/{$capacity}
cargo-console-menu-call-shuttle-button = Активувати телепад
cargo-console-menu-permissions-button = Дозволи
cargo-console-menu-categories-label = Категорії:{" "}
cargo-console-menu-search-bar-placeholder = Пошук
cargo-console-menu-requests-label = Запити
cargo-console-menu-orders-label = Замовлення
cargo-console-menu-populate-categories-all-text = Усі
cargo-console-menu-order-row-title = {$productName} (x{$orderAmount} за {$orderPrice}$)
cargo-console-menu-populate-orders-cargo-order-row-product-name-text = Запитано: {$orderRequester} з [color={$accountColor}]{$account}[/color]
cargo-console-menu-order-row-product-description = Причина: {$orderReason}
cargo-console-menu-order-row-button-approve = Схвалити
cargo-console-menu-order-row-button-cancel = Скасувати
cargo-console-menu-order-row-alerts-reason-absent = Причина не вказана
cargo-console-menu-order-row-alerts-requester-unknown = Невідомо
cargo-console-menu-tab-title-orders = Замовлення
cargo-console-menu-tab-title-funds = Перекази
cargo-console-menu-account-action-transfer-limit = [bold]Ліміт переказу:[/bold] ${$limit}
cargo-console-menu-account-action-transfer-limit-unlimited-notifier = [color=gold](Необмежено)[/color]
cargo-console-menu-account-action-select = [bold]Дія з рахунком:[/bold]
cargo-console-menu-account-action-amount = [bold]Сума:[/bold] $
cargo-console-menu-account-action-button = Переказати
cargo-console-menu-toggle-account-lock-button = Змінити ліміт переказу
cargo-console-menu-account-action-option-withdraw = Зняти готівку
cargo-console-menu-account-action-option-transfer = Переказати кошти на {$code}

# Orders
cargo-console-order-not-allowed = Доступ заборонено
cargo-console-station-not-found = Немає доступної станції
cargo-console-invalid-product = Невірний ідентифікатор товару
cargo-console-too-many = Занадто багато затверджених наказів
cargo-console-snip-snip = Замовлення урізано до мінімуму
cargo-console-insufficient-funds = Недостатність коштів (require {$cost})
cargo-console-unfulfilled = Невистачає місця для виконання
cargo-console-trade-station = Відправити до {$destination}
cargo-console-unlock-approved-order-broadcast = [bold]{$productName} x{$orderAmount}[/bold], вартість якого [bold]{$cost}[/bold], було затверджено [bold]{$approver}[/bold]
cargo-console-fund-withdraw-broadcast = [bold]{$name} зняв {$amount} спесос з {$name1} \[{$code1}\]
cargo-console-fund-transfer-broadcast = [bold]{$name} переказав {$amount} спесос з {$name1} \[{$code1}\] до {$name2} \[{$code2}\][/bold]
cargo-console-fund-transfer-user-unknown = Невідомо

cargo-console-paper-reason-default = Без причини
cargo-console-paper-approver-default = Unknown
cargo-console-paper-print-name = Замовлення №{$orderNumber}
cargo-console-paper-print-text =
    {"[color=#7b6640]"}█▄ █ ▀█▀{"[/color]"} {"[head=2]"}НАЗВА СТАНЦІЇ{"[/head]"}
    {"[color=#7b6640]"}█ ▀█ {"[color=#0000]"}░{"[/color]"}█{"[color=#0000]"}░{"[/color]"} {"[/color]"} {"[bold]"}ДАТА:{"[/bold]"} __________
    ▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬
    {"[head=3]"}Замовлення №{$orderNumber}{"[/head]"}
    ▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬
    {"[bold]"}Назва та кількість товарів:{"[/bold]"} {$itemName}, x{$orderQuantity}
    {"[bold]"}Замовник:{"[/bold]"} {$requester}
    {"[bold]"}Платник:{"[/bold]"} {$account} [font="Monospace"]\[{$accountcode}\][/font]
    {"[bold]"}Підстави:{"[/bold]"} {$reason}
    ▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬
    {"[bold]"}Підтверджено:{"[/bold]"} {$approver}
    ▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬
    ПЕЧАТКА/ПІДПИС

# Cargo shuttle console
cargo-shuttle-console-menu-title = Консоль вантажного шаттла
cargo-shuttle-console-station-unknown = Невідомо
cargo-shuttle-console-shuttle-not-found = Не знайдено
cargo-shuttle-console-organics = Виявлено органічні форми життя на шатлі
cargo-no-shuttle = Вантажний шатл не знайдено!

# Funding allocation console
cargo-funding-alloc-console-menu-title = Консоль розподілу фінансування
cargo-funding-alloc-console-label-account = [bold]Акаунт[/bold]
cargo-funding-alloc-console-label-code = [bold]Код[/bold]
cargo-funding-alloc-console-label-balance = [bold]Баланс[/bold]
cargo-funding-alloc-console-label-cut = [bold]Розподіл доходів (%)[/bold]

cargo-funding-alloc-console-label-primary-cut = Частка Карго з коштів від продажів без lockbox (%):
cargo-funding-alloc-console-label-lockbox-cut = Частка Карго з коштів від продажів lockbox (%):

cargo-funding-alloc-console-label-help-non-adjustible = Карго отримує {$percent}% прибутку від продажів без lockbox. Решту розподіляють, як вказано нижче:
cargo-funding-alloc-console-label-help-adjustible = Залишкові кошти від продажів без lockbox розподіляються, як вказано нижче:
cargo-funding-alloc-console-button-save = Зберегти зміни
cargo-funding-alloc-console-label-save-fail = [bold]Недійсний розподіл доходів![/bold] [color=red]({$pos ->
    [1] +
    *[-1] -
}{$val}%)[/color]

# Slip template
cargo-acquisition-slip-body = [head=3]Деталі активу[/head]
    {"[bold]Продукт:[/bold]"} {$product}
    {"[bold]Опис:[/bold]"} {$description}
    {"[bold]Ціна за одиницю:[/bold]"} ${$unit}
    {"[bold]Кількість:[/bold]"} {$amount}
    {"[bold]Загальна вартість:[/bold]"} ${$cost}

    {"[head=3]Деталі придбання[/head]"}
    {"[bold]Замовник:[/bold]"} {$orderer}
    {"[bold]Причина:[/bold]"} {$reason}

