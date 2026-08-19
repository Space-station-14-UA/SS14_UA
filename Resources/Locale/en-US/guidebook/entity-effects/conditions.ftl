entity-condition-guidebook-total-damage =
    { $max ->
        [2147483648] має принаймні {NATURALFIXED($min, 2)} загальної шкоди
        *[other] { $min ->
                    [0] має щонайбільше {NATURALFIXED($max, 2)} загальної шкоди
                    *[other] має від {NATURALFIXED($min, 2)} до {NATURALFIXED($max, 2)} загальної шкоди
                 }
    }

entity-condition-guidebook-type-damage =
    { $max ->
        [2147483648] має принаймні {NATURALFIXED($min, 2)} шкоди типу {$type}
        *[other] { $min ->
                    [0] має щонайбільше {NATURALFIXED($max, 2)} шкоди типу {$type}
                    *[other] має від {NATURALFIXED($min, 2)} до {NATURALFIXED($max, 2)} шкоди типу {$type}
                 }
    }

entity-condition-guidebook-group-damage =
    { $max ->
        [2147483648] має принаймні {NATURALFIXED($min, 2)} шкоди типу {$type}.
        *[other] { $min ->
                    [0] має щонайбільше {NATURALFIXED($max, 2)} шкоди типу {$type}.
                    *[other] має від {NATURALFIXED($min, 2)} до {NATURALFIXED($max, 2)} шкоди типу {$type}
                 }
    }

entity-condition-guidebook-total-hunger =
    { $max ->
        [2147483648] ціль має принаймні {NATURALFIXED($min, 2)} загального голоду
        *[other] { $min ->
                    [0] ціль має щонайбільше {NATURALFIXED($max, 2)} загального голоду
                    *[other] ціль має від {NATURALFIXED($min, 2)} до {NATURALFIXED($max, 2)} загального голоду
                 }
    }

entity-condition-guidebook-reagent-threshold =
    { $max ->
        [2147483648] є принаймні {NATURALFIXED($min, 2)}од {$reagent}
        *[other] { $min ->
                    [0] є щонайбільше {NATURALFIXED($max, 2)}од {$reagent}
                    *[other] є від {NATURALFIXED($min, 2)}од до {NATURALFIXED($max, 2)}од {$reagent}
                 }
    }

entity-condition-guidebook-mob-state-condition =
    моб має стан { $state }

entity-condition-guidebook-job-condition =
    професія цілі — { $job }

entity-condition-guidebook-solution-temperature =
    температура розчину { $max ->
            [2147483648] принаймні {NATURALFIXED($min, 2)}к
            *[other] { $min ->
                        [0] щонайбільше {NATURALFIXED($max, 2)}к
                        *[other] від {NATURALFIXED($min, 2)}к до {NATURALFIXED($max, 2)}к
                     }
    }

entity-condition-guidebook-body-temperature =
    температура тіла { $max ->
            [2147483648] принаймні {NATURALFIXED($min, 2)}к
            *[other] { $min ->
                        [0] щонайбільше {NATURALFIXED($max, 2)}к
                        *[other] від {NATURALFIXED($min, 2)}к до {NATURALFIXED($max, 2)}к
                     }
    }

entity-condition-guidebook-organ-type =
    метаболізуючий орган { $shouldhave ->
                                [true] є
                                *[false] не є
                           } органом {$name}

entity-condition-guidebook-has-tag =
    ціль { $invert ->
             [true] не має
             *[false] має
            } тег {$tag}

entity-condition-guidebook-this-reagent = цей реагент

entity-condition-guidebook-breathing =
    організм { $isBreathing ->
                [true] дихає нормально
                *[false] задихається
               }

entity-condition-guidebook-internals =
    організм { $usingInternals ->
                [true] використовує внутрішнє дихання
                *[false] дихає атмосферним повітрям
               }
