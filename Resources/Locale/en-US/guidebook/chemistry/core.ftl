guidebook-reagent-effect-description =
    {$quantity ->
        [0] {""}
        *[other] Якщо є принаймні {$quantity}од {$reagent},{" "}
    }{$chance ->
        [1] { $effect }
        *[other] З імовірністю { NATURALPERCENT($chance, 2) } { $effect }
    }{ $conditionCount ->
        [0] .
        *[other] , якщо { $conditions }.
    }

guidebook-reagent-name = [bold][color={$color}]{CAPITALIZE($name)}[/color][/bold]
guidebook-reagent-recipes-header = Рецепт
guidebook-reagent-recipes-reagent-display = [bold]{$reagent}[/bold] \[{$ratio}\]
guidebook-reagent-sources-header = Джерела
guidebook-reagent-sources-ent-wrapper = [bold]{$name}[/bold] \[1\]
guidebook-reagent-sources-gas-wrapper = [bold]{$name} (газ)[/bold] \[1\]
guidebook-reagent-effects-header = Ефекти
guidebook-reagent-effects-metabolism-stage-rate = [bold]{$stage}[/bold] [color=gray]({$rate} од. на секунду)[/color]
guidebook-reagent-effects-metabolite-item = {$reagent} з коефіцієнтом { NATURALPERCENT($rate, 2) }
guidebook-reagent-effects-metabolites = Метаболізується в { $items }.
guidebook-reagent-plant-metabolisms-header = Метаболізм рослин
guidebook-reagent-plant-metabolisms-rate = [bold]Метаболізм рослин[/bold] [color=gray](базово 1 од. кожні 3 секунди)[/color]
guidebook-reagent-physical-description = [italic]Здається, це {$description}.[/italic]
guidebook-reagent-recipes-mix-info = {$minTemp ->
    [0] {$hasMax ->
            [true] {CAPITALIZE($verb)} при температурі нижче {NATURALFIXED($maxTemp, 2)}к
            *[false] {CAPITALIZE($verb)}
        }
    *[other] {CAPITALIZE($verb)} при температурі {$hasMax ->
            [true] від {NATURALFIXED($minTemp, 2)}к до {NATURALFIXED($maxTemp, 2)}к
            *[false] вище {NATURALFIXED($minTemp, 2)}к
        }
}
