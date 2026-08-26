### Interaction Messages

# Shown when player tries to replace light, but there are no lights left
comp-light-replacer-missing-light = У {$light-replacer} не залишилося ламп ({$light-name}).

# Shown when player tries to insert a broken light bulb into the light replacer.
comp-light-replacer-insert-broken-light = Не можна вставляти розбиті лампи!

# Shown when a player attempts to replace a light with the same color & type as the active light.
comp-light-replacer-same-light = У цьому світильнику вже встановлено {$light}!

# Radial Menu messages
comp-light-replacer-eject-specified-lights = Eject all {MAKEPLURAL($light)}.
comp-light-replacer-select-lights = Select {MAKEPLURAL($light)}.
comp-light-replacer-open-empty = {CAPITALIZE(THE($light-replacer))} is completely empty!

# Label
comp-light-replacer-label = Tube: {$tube}
                            Bulb: {$bulb}

### Examine

comp-light-replacer-no-lights = Він порожній.
comp-light-replacer-has-lights = Він містить наступне:
comp-light-replacer-light-listing = {$amount ->
    [one] [color=yellow]{$amount}[/color] [color=gray]{$name}[/color]
    *[other] [color=yellow]{$amount}[/color] [color=gray]{MAKEPLURAL($name)}[/color]
}

### Status Control

# Bulbs
comp-light-bulb-incandescent = розжарювання
comp-light-bulb-dim = тьмяна
comp-light-bulb-warm = тепла
comp-light-bulb-service = службова

# Tubes
comp-light-bulb-fluorescent = люмінесцентна
comp-light-bulb-exterior = зовнішня
comp-light-bulb-sodium = натрієва

# Both
comp-light-bulb-old = стара
comp-light-bulb-led = світлодіодна
comp-light-bulb-cyan = блакитна
comp-light-bulb-blue = синя
comp-light-bulb-yellow = жовта
comp-light-bulb-pink = рожева
comp-light-bulb-orange = помаранчева
comp-light-bulb-black = чорна
comp-light-bulb-red = червона
comp-light-bulb-green = зелена
