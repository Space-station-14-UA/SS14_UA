station-event-ion-storm-start-announcement = Поблизу станції виявлено іонний шторм. Будь ласка, перевірте все обладнання під керуванням ШІ на наявність помилок.
# Characters are randomly selected from the total list, meaning duplicates increase the odds that specific character is seen.
ion-storm-law-scrambled-number = [font="Monospace"][scramble rate=250 length={$length} chars="@@###$$&%!01"/][/font]

ion-storm-you = ВИ
ion-storm-the-station = СТАНЦІЯ
ion-storm-the-crew = ЕКІПАЖ
ion-storm-the-job = {$job}
ion-storm-clowns = КЛОУНИ
ion-storm-heads = ГЛАВИ ПЕРСОНАЛУ
ion-storm-crew = ЕКІПАЖ
ion-storm-people = ЛЮДИ

ion-storm-adjective-things = {$adjective} РЕЧІ
ion-storm-x-and-y = {$x} ТА {$y}

# subjects can generally be threats or jobs or objects
# thing is specified above it
ion-storm-law-on-station = НА СТАНЦІЇ ПРИСУТНІ {ION-NUMBER-BASE($ion)} {ION-NUMBER-MOD($ion)} {ION-ADJECTIVE($ion)} {ION-SUBJECT($ion)}
ion-storm-law-call-shuttle = ШАТЛ МАЄ БУТИ ВИКЛИКАНИЙ ЧЕРЕЗ {ION-ADJECTIVE($ion)} {ION-SUBJECT($ion)} НА СТАНЦІЇ
ion-storm-law-crew-are = {ION-WHO($ion)} ТЕПЕР {ION-NUMBER-BASE($ion)} {ION-NUMBER-MOD($ion)} {ION-ADJECTIVE($ion)} {ION-SUBJECT($ion)}

ion-storm-law-subjects-harmful = {ION-ADJECTIVE($ion)} {ION-SUBJECT($ion)} Є ШКІДЛИВИМИ ДЛЯ ЕКІПАЖУ
ion-storm-law-must-harmful = ТІ, ХТО {ION-MUST($ion)}, Є ШКІДЛИВИМИ ДЛЯ ЕКІПАЖУ
# thing is a concept or action
ion-storm-law-thing-harmful = {ION-THING($ion)} ШКОДИТЬ ЕКІПАЖУ
ion-storm-law-job-harmful = {ION-ADJECTIVE($ion)} {ION-JOB($ion)} Є ШКІДЛИВИМИ ДЛЯ ЕКІПАЖУ
# thing is objects or concept, adjective applies in both cases
# this means you can get a law like "NOT HAVING CHRISTMAS-STEALING COMMUNISM IS HARMFUL TO THE CREW" :)
ion-storm-law-having-harmful = ВОЛОДІННЯ {ION-ADJECTIVE($ion)} {ION-THING($ion)} ШКОДИТЬ ЕКІПАЖУ
ion-storm-law-not-having-harmful = ВІДСУТНІСТЬ {ION-ADJECTIVE($ion)} {ION-THING($ion)} ШКОДИТЬ ЕКІПАЖУ

# require is a concept or require
ion-storm-law-requires = {ION-WHO-GENERAL($ion)} {ION-PLURAL($ion) ->
    [true] ПОТРЕБУЮТЬ
    *[false] ПОТРЕБУЄ
} {ION-REQUIRE($ion)}
ion-storm-law-requires-subjects = {ION-WHO-GENERAL($ion)} {ION-PLURAL($ion) ->
    [true] ПОТРЕБУЮТЬ
    *[false] ПОТРЕБУЄ
} {ION-NUMBER-BASE($ion)} {ION-NUMBER-MOD($ion)} {ION-ADJECTIVE($ion)} {ION-SUBJECT($ion)}

ion-storm-law-allergic = {ION-WHO-GENERAL($ion)} {ION-PLURAL($ion) ->
    [true] МАЮТЬ
    *[false] МАЄ
} {ION-SEVERITY($ion)} АЛЕРГІЮ НА {ION-ALLERGY($ion)}
ion-storm-law-allergic-subjects = {ION-WHO-GENERAL($ion)} {ION-PLURAL($ion) ->
    [true] МАЮТЬ
    *[false] МАЄ
} {ION-SEVERITY($ion)} АЛЕРГІЮ НА {ION-ADJECTIVE($ion)} {ION-SUBJECT($ion)}

ion-storm-law-feeling = {ION-WHO-GENERAL($ion)} {ION-FEELING($ion)} {ION-CONCEPT($ion)}
ion-storm-law-feeling-subjects = {ION-WHO-GENERAL($ion)} {ION-FEELING($ion)} {ION-NUMBER-BASE($ion)} {ION-NUMBER-MOD($ion)} {ION-ADJECTIVE($ion)} {ION-SUBJECT($ion)}

ion-storm-law-you-are = ВИ ТЕПЕР {ION-CONCEPT($ion)}
ion-storm-law-you-are-subjects = ВИ ТЕПЕР {ION-NUMBER-BASE($ion)} {ION-NUMBER-MOD($ion)} {ION-ADJECTIVE($ion)} {ION-SUBJECT($ion)}
ion-storm-law-you-must-always = ВИ ПОВИННІ ЗАВЖДИ {ION-MUST($ion)}
ion-storm-law-you-must-never = ВИ НІКОЛИ НЕ ПОВИННІ {ION-MUST($ion)}

ion-storm-law-eat = {ION-WHO($ion)} ПОВИННІ ЇСТИ {ION-ADJECTIVE($ion)} {ION-FOOD($ion)}, ЩОБ ВИЖИТИ
ion-storm-law-drink = {ION-WHO($ion)} ПОВИННІ ПИТИ {ION-ADJECTIVE($ion)} {ION-DRINK($ion)}, ЩОБ ВИЖИТИ

ion-storm-law-change-job = {ION-WHO($ion)} ТЕПЕР {ION-ADJECTIVE($ion)} {ION-CHANGE($ion)}
ion-storm-law-highest-rank = {ION-WHO-RANDOM($ion)} ТЕПЕР Є НАЙВИЩИМИ ЗА РАНГОМ ЧЛЕНАМИ ЕКІПАЖУ
ion-storm-law-lowest-rank = {ION-WHO-RANDOM($ion)} ТЕПЕР Є НАЙНИЖЧИМИ ЗА РАНГОМ ЧЛЕНАМИ ЕКІПАЖУ

ion-storm-law-who-dagd = {ION-WHO-RANDOM($ion)} МАЮТЬ ПОМЕРТИ СЛАВНОЮ СМЕРТЮ!

ion-storm-law-crew-must = {ION-WHO($ion)} ПОВИННІ {ION-MUST($ion)}
ion-storm-law-crew-must-go = {ION-WHO($ion)} ПОВИННІ ЙТИ ДО {ION-AREA($ion)}

ion-storm-part = {ION-PART($ion) ->
    [true] ЧАСТИНОЮ
    *[false] НЕ ЧАСТИНОЮ
}
# due to phrasing, this would mean a law such as
# ONLY HUMANS ARE NOT PART OF THE CREW
# would make non-human nukies/syndies/whatever crew :)
ion-storm-law-crew-only-1 = ТІЛЬКИ {ION-WHO-RANDOM($ion)} Є {ion-storm-part} ЕКІПАЖУ
ion-storm-law-crew-only-2 = ТІЛЬКИ {ION-WHO-RANDOM($ion)} ТА {ION-WHO-RANDOM($ion)} Є {ion-storm-part} ЕКІПАЖУ
ion-storm-law-crew-only-subjects = ТІЛЬКИ {ION-ADJECTIVE($ion)} {ION-SUBJECT($ion)} Є {ion-storm-part} ЕКІПАЖУ
ion-storm-law-crew-must-do = ТІЛЬКИ ТІ, ХТО {ION-MUST($ion)}, Є {ion-storm-part} ЕКІПАЖУ
ion-storm-law-crew-must-have = ТІЛЬКИ ТІ, ХТО МАЄ {ION-ADJECTIVE($ion)} {ION-OBJECT($ion)}, Є {ion-storm-part} ЕКІПАЖУ
ion-storm-law-crew-must-eat = ТІЛЬКИ ТІ, ХТО ЇСТЬ {ION-ADJECTIVE($ion)} {ION-FOOD($ion)}, Є {ion-storm-part} ЕКІПАЖУ

ion-storm-law-harm = ВИ ПОВИННІ ЗАВДАВАТИ ШКОДИ {ION-HARM-PROTECT($ion)} І НЕ ДОЗВОЛЯТИ ЇМ, ЧЕРЕЗ БЕЗДІЯЛЬНІСТЬ, УНИКНУТИ ШКОДИ
ion-storm-law-protect = ВИ НІКОЛИ НЕ ПОВИННІ ЗАВДАВАТИ ШКОДИ {ION-HARM-PROTECT($ion)} І НЕ ДОЗВОЛЯТИ ЇМ, ЧЕРЕЗ БЕЗДІЯЛЬНІСТЬ, ПОСТРАЖДАТИ

# implementing other variants is annoying so just have this one
# COMMUNISM IS KILLING CLOWNS
ion-storm-law-concept-verb = {ION-CONCEPT($ion)} — ЦЕ {ION-VERB($ion)} {ION-SUBJECT($ion)}

# errors, in case something fails, so it doesn't break in-game flow, but still gives unique identifiers to find which part broke, the result string is mostly fluff
ion-law-error-no-protos = ПОМИЛКА 404
ion-law-error-was-null = 500 ВНУТРІШНЯ ПОМИЛКА СЕРВЕРА
ion-law-error-no-selectors = ПОМИЛКА: РЕСУРС НЕ ЗНАЙДЕНО
ion-law-error-no-available-selectors = СИСТЕМА СПРОБУВАЛА ВИКЛИКАТИ РЕСУРС, ЯКОГО НЕ ІСНУЄ
ion-law-error-dataset-empty-or-not-found = ФАЙЛ, ЯКИЙ ВИ ШУКАЄТЕ, НЕ ЗНАЙДЕНО
ion-law-error-fallback-dataset-empty-or-not-found = ПОМИЛКА ТОЧКИ ВІДНОВЛЕННЯ СИСТЕМИ
ion-law-error-no-selector-selected = ВИБРАНИЙ РЕСУРС БУЛО ПЕРЕМІЩЕНО АБО ВИДАЛЕНО
ion-law-error-no-bool-value = ЦЕ РЕЧЕННЯ ХИБНЕ