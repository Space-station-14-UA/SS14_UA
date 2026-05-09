objectives-round-end-result = {$count ->
    [one] Був один {$agent}.
    *[other] Було {$count} {MAKEPLURAL($agent)}.
}

objectives-round-end-result-in-custody = {$custody} з {$count} {MAKEPLURAL($agent)} перебували під вартою.

objectives-player-user-named = [color=White]{$name}[/color] ([color=gray]{$user}[/color])
objectives-player-named = [color=White]{$name}[/color]

objectives-no-objectives = {$custody}{$title} був {$agent}.
objectives-with-objectives = {$custody}{$title} був {$agent}, у якого були такі цілі:

objectives-objective-success = {$objective} | [color=green]Успішно![/color] ({TOSTRING($progress, "P0")})
objectives-objective-partial-success = {$objective} | [color=yellow]Частковий успіх![/color] ({TOSTRING($progress, "P0")})
objectives-objective-partial-failure = {$objective} | [color=orange]Часткова невдача![/color] ({TOSTRING($progress, "P0")})
objectives-objective-fail = {$objective} | [color=red]Провалено![/color] ({TOSTRING($progress, "P0")})

objectives-in-custody = [bold][color=red]| ПІД ВАРТОЮ | [/color][/bold]
