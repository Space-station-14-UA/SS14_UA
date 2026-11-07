### Interaction Messages

# System

## When trying to ingest without the required utensil... but you gotta hold it
ingestion-you-need-to-hold-utensil = Щоб це з'їсти, потрібно тримати {INDEFINITE($utensil)} {$utensil}!

ingestion-try-use-is-empty = {CAPITALIZE(THE($entity))} порожнє!
ingestion-try-use-wrong-utensil = Ви не можете {$verb} {THE($food)} за допомогою {INDEFINITE($utensil)} {$utensil}.

ingestion-remove-mask = Спочатку потрібно зняти {$entity}.

## Failed Ingestion

ingestion-you-cannot-ingest-any-more = Ви не можете {$verb} більше!
ingestion-other-cannot-ingest-any-more = {CAPITALIZE(SUBJECT($target))} не може більше {$verb}!

ingestion-cant-digest = Ви не можете перетравити {THE($entity)}!
ingestion-cant-digest-other = {CAPITALIZE(SUBJECT($target))} не може перетравити {THE($entity)}!

## Action Verbs, not to be confused with Verbs

ingestion-verb-food = Їсти
ingestion-verb-drink = Пити

# Edible Component

-edible-satiated = { $satiated ->
    [true] {" "}Ви відчуваєте, що не можете більше { $verb }.
  *[false] {""}
}

edible-nom = Ням. {$flavors}{ -edible-satiated(satiated: $satiated, verb: "eat") }
edible-nom-other = Ням.
edible-slurp = Сьорб. {$flavors}{ -edible-satiated(satiated: $satiated, verb: "drink") }
edible-slurp-other = Сьорб.
edible-swallow = Ви ковтаєте { THE($food) }.{ -edible-satiated(satiated: $satiated, verb: "swallow") }
edible-gulp = Глоток. {$flavors}
edible-gulp-other = Глоток.

edible-has-used-storage = Ви не можете {$verb} { THE($food) }, бо всередині є предмет.

## Nouns

edible-noun-edible = їстівне
edible-noun-food = їжа
edible-noun-drink = напій
edible-noun-pill = пігулка

## Verbs

edible-verb-edible = спожити
edible-verb-food = з'їсти
edible-verb-drink = випити
edible-verb-pill = проковтнути

## Force feeding

edible-force-feed = {CAPITALIZE($user)} намагається змусити вас {$verb} щось!
edible-force-feed-success = {CAPITALIZE($user)} змусив вас {$verb} щось! {$flavors}{ -edible-satiated(satiated: $satiated, verb: $verb) }
edible-force-feed-success-user = Ви успішно нагодували {$target}
