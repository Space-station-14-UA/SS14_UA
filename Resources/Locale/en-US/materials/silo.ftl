ore-silo-ui-title = Сховище матеріалів
ore-silo-ui-label-clients = Устаткування
ore-silo-ui-label-mats = Матеріали
ore-silo-ui-itemlist-entry = {$linked ->
    [true] {"[Підключено] "}
    *[False] {""}
} {$name} ({$beacon}) {$inRange ->
    [true] {""}
    *[false] (Поза зоною дії)
}
