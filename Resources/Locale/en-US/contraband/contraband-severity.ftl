contraband-examine-text-Minor =
    { $type ->
        *[item] [color={$color}]Цей предмет вважається дрібною контрабандою.[/color]
        [reagent] [color={$color}]Цей реагент вважається дрібною контрабандою.[/color]
    }

contraband-examine-text-Restricted =
    { $type ->
        *[item] [color={$color}]Цей предмет з обмеженим доступом.[/color]
        [reagent] [color={$color}]Цей реагент з обмеженим доступом.[/color]
    }

contraband-examine-text-Restricted-department =
    { $type ->
        *[item] [color={$color}]Цей предмет обмежений для {$departments}, і може вважатися контрабандою.[/color]
        [reagent] [color={$color}]Цей реагент обмежений для {$departments}, і може вважатися контрабандою.[/color]
    }

contraband-examine-text-Major =
    { $type ->
        *[item] [color={$color}]Цей предмет вважається великою контрабандою.[/color]
        [reagent] [color={$color}]Цей реагент вважається великою контрабандою.[/color]
    }

contraband-examine-text-GrandTheft =
    { $type ->
        *[item] [color={$color}]Цей предмет є дуже цінною мішенню для агентів Синдикату![/color]
        [reagent] [color={$color}]Цей реагент є дуже цінною мішенню для агентів Синдикату![/color]
    }

contraband-examine-text-Highly-Illegal =
    { $type ->
        *[item] [color={$color}]Цей предмет є надзвичайно незаконною контрабандою![/color]
        [reagent] [color={$color}]Цей реагент є надзвичайно незаконною контрабандою![/color]
    }

contraband-examine-text-Syndicate =
    { $type ->
        *[item] [color={$color}]Цей предмет є надзвичайно незаконною контрабандою Синдикату![/color]
        [reagent] [color={$color}]Цей реагент є надзвичайно незаконною контрабандою Синдикату![/color]
    }

contraband-examine-text-Magical =
    { $type ->
        *[item] [color={$color}]Цей предмет є надзвичайно незаконною магічною контрабандою![/color]
        [reagent] [color={$color}]Цей реагент є надзвичайно незаконною магічною контрабандою![/color]
    }

contraband-examine-text-avoid-carrying-around = [color=red][italic]Ви, напевно, хочете уникати видимого носіння цього без вагомої причини.[/italic][/color]
contraband-examine-text-in-the-clear = [color=green][italic]Ви можете вільно носити його з собою.[/italic][/color]

contraband-examinable-verb-text = Законність
contraband-examinable-verb-message = Перевірити законність цього предмета.

contraband-department-plural = {$department}
contraband-job-plural = {MAKEPLURAL($job)}
