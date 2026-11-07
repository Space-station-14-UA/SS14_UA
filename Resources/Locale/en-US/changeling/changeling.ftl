# antag selection
roles-antag-changeling-name = Генокрад
roles-antag-changeling-objective = Розумний хижак, який переймає особистості своїх жертв.

# devour
changeling-devour-attempt-failed-cannot-devour = Ми не можемо це поглинути!
changeling-devour-attempt-failed-already-devoured = Ми вже поглинули це тіло!
changeling-devour-attempt-failed-devoured-recently = Це тіло занадто покалічене, щоб його поглинути!
changeling-devour-attempt-failed-not-dead = Це тіло все ще живе! Ми не можемо поглинути його живим!
changeling-devour-attempt-failed-rotting = У цьому трупі залишилася лише згнила біомаса.
changeling-devour-attempt-failed-protected = Біомаса цієї жертви захищена бронею!
changeling-devour-attempt-failed-no-space = Ми перевищили максимальну кількість маскувань!

changeling-devour-begin-windup-self = Наша моторошна паща відкривається з потойбічним голодом.
changeling-devour-begin-windup-others = Моторошна паща { CAPITALIZE(POSS-ADJ($user)) } відкривається з потойбічним голодом.
changeling-devour-begin-consume-self = Моторошна паща глибоко впивається у свою жертву.
changeling-devour-begin-consume-others = Моторошна паща { CAPITALIZE(POSS-ADJ($user)) } глибоко впивається у { POSS-ADJ($user) } жертву.
changeling-devour-consume-complete-self = Наша моторошна паща ховається, біомасу поглинуто.
changeling-devour-consume-complete-others = Моторошна паща { CAPITALIZE(POSS-ADJ($user)) } ховається.

changeling-devour-doafter-windup = [color=red]{ CAPITALIZE(POSS-ADJ($user)) } face is splitting open, preparing to feast![/color]
changeling-devour-doafter = [color=red]{ CAPITALIZE(SUBJECT($user)) } { CONJUGATE-BE($user) } tearing into the flesh of {$target}![/color]

# transformation
changeling-transform-attempt-self = Наші кістки тріщать, м'язи рвуться, одна плоть стає іншою.
changeling-transform-attempt-others = Кістки { CAPITALIZE(POSS-ADJ($user)) } тріщать, м'язи рвуться, тіло перетворюється на інше.

changeling-transform-doafter = [color=red]The surface of { POSS-ADJ($user) } skin is melting, taking another shape.[/color]

# transformation BUI
changeling-transform-bui-select-entity = {$entity}
changeling-transform-bui-drop-identity-menu = Видалити поглинуту особистість із пам'яті.
changeling-transform-bui-drop-identity-entity = Видалити {$entity}
changeling-transform-bui-drop-identity-entity-popup = Ми видалили {$entity} з нашої пам'яті.
changeling-transform-bui-drop-identity-cannot-drop = Ми не можемо видалити нашу поточну особистість.

# voice mimicry
changeling-voice-mimic-window-title = Імітація голосу

# flesh clothing
changeling-flesh-clothing-removed-popop = {CAPITALIZE($item)} розпадається на м'ясисті рештки!
changeling-flesh-clothing-examine-wearer = [color=crimson]Цей предмет є замаскованою частиною вашого тіла. Він зникне, якщо ви його знімете![/color]
changeling-flesh-clothing-alert-name = Здібність Одяг із плоті
changeling-flesh-clothing-alert-desc = Чи увімкнено трансформацію одягу. Натисніть, щоб перемикнути.

# biodegrade
changeling-biodegrade-used-popup = {CAPITALIZE($user)} блює кислотою на {POSS-ADJ($user)} {$restraint}!
changeling-biodegrade-used-popup-self = Ми блюємо кислотою на свої {$restraint}!

# last resort
changeling-takeover-not-dead = Ця туша все ще жива! Ми не можемо інфестувати її живою.
changeling-takeover-is-changeling = Ця туша відкидає наші спроби захоплення!
changeling-takeover-start-others = {$user} починає залазити всередину трупа!
changeling-takeover-doafter = [color=red]{ CAPITALIZE(SUBJECT($user)) } залазить всередину {$target}![/color]

# stings
changeling-sting-success = Ми безшумно жалимо {$target}!
changeling-sting-hemotoxin = Ви відчуваєте гострий біль у грудях!

# mindshield
changeling-fake-mindshield-enabled = Ми випромінюємо фальшиві хвилі захисту розуму.
changeling-fake-mindshield-disabled = Ми припиняємо випромінювати фальшиві хвилі захисту розуму.

# chemicals
changeling-not-enough-chemicals = У нас недостатньо хімікатів.

# other
changeling-action-fail-generic = Ми не можемо зробити це просто зараз.
changeling-paused-map-name = Карта зберігання особистостей генокрада
changeling-cocoon-success = Ми огортаємо {$target} у м'ясисту гробницю.
changeling-cocoon-doafter = [color=red]{ CAPITALIZE(SUBJECT($user)) } вкриває {$target} м'ясистою масою![/color]

# horror transformation
changeling-horror-alert-time-name = Залишок часу
changeling-horror-alert-time-desc = Коли цей лічильник досягне 0, ми виснажимо свої сили.
changeling-horror-force-transform-self = Наша енергія виснажена, ми більше не можемо утримувати цю форму.
changeling-horror-force-transform-others = Плоть { POSS-ADJ($user) } швидко зморщується та відмирає.
changeling-horror-transform-fail = У нас недостатньо збереженої ДНК, щоб викрити себе.
