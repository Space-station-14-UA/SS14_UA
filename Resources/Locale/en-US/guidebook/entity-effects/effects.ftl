-create-3rd-person =
    { $chance ->
        [1] Створює
        *[other] створити
    }

-cause-3rd-person =
    { $chance ->
        [1] Спричиняє
        *[other] спричинити
    }

-satiate-3rd-person =
    { $chance ->
        [1] Втамовує
        *[other] втамувати
    }

entity-effect-guidebook-spawn-entity =
    { $chance ->
        [1] Створює
        *[other] створити
    } { $amount ->
        [1] {INDEFINITE($entname)}
        *[other] {$amount} {MAKEPLURAL($entname)}
    }

entity-effect-guidebook-destroy =
    { $chance ->
        [1] Знищує
        *[other] знищити
    } об'єкт

entity-effect-guidebook-break =
    { $chance ->
        [1] Ламає
        *[other] зламати
    } об'єкт

entity-effect-guidebook-explosion =
    { $chance ->
        [1] Спричиняє
        *[other] спричинити
    } вибух

entity-effect-guidebook-emp =
    { $chance ->
        [1] Спричиняє
        *[other] спричинити
    } електромагнітний імпульс

entity-effect-guidebook-flash =
    { $chance ->
        [1] Спричиняє
        *[other] спричинити
    } засліплюючий спалах

entity-effect-guidebook-foam-area =
    { $chance ->
        [1] Створює
        *[other] створити
    } велику кількість піни

entity-effect-guidebook-smoke-area =
    { $chance ->
        [1] Створює
        *[other] створити
    } велику кількість диму

entity-effect-guidebook-satiate-thirst =
    { $chance ->
        [1] Втамовує
        *[other] втамувати
    } { $relative ->
        [1] спрагу в середньому темпі
        *[other] спрагу в {NATURALFIXED($relative, 3)}x від середнього темпу
    }

entity-effect-guidebook-satiate-hunger =
    { $chance ->
        [1] Втамовує
        *[other] втамувати
    } { $relative ->
        [1] голод в середньому темпі
        *[other] голод в {NATURALFIXED($relative, 3)}x від середнього темпу
    }

entity-effect-guidebook-health-change =
    { $chance ->
        [1] { $healsordeals ->
                [heals] Зцілює
                [deals] Завдає
                *[both] Змінює здоров'я на
             }
        *[other] { $healsordeals ->
                    [heals] зцілити
                    [deals] завдати
                    *[both] змінити здоров'я на
                 }
    } { $changes }

entity-effect-guidebook-even-health-change =
    { $chance ->
        [1] { $healsordeals ->
            [heals] Рівномірно зцілює
            [deals] Рівномірно завдає
            *[both] Рівномірно змінює здоров'я на
        }
        *[other] { $healsordeals ->
            [heals] рівномірно зцілити
            [deals] рівномірно завдати
            *[both] рівномірно змінити здоров'я на
        }
    } { $changes }

entity-effect-guidebook-status-effect-old =
    { $type ->
        [update]{ $chance ->
                    [1] Спричиняє
                     *[other] спричинити
                 } {LOC($key)} щонайменше на {NATURALFIXED($time, 3)} {MANY("second", $time)} без накопичення
        [add]   { $chance ->
                    [1] Спричиняє
                    *[other] спричинити
                } {LOC($key)} щонайменше на {NATURALFIXED($time, 3)} {MANY("second", $time)} з накопиченням
        [set]  { $chance ->
                    [1] Спричиняє
                    *[other] спричинити
                } {LOC($key)} на {NATURALFIXED($time, 3)} {MANY("second", $time)} без накопичення
        *[remove]{ $chance ->
                    [1] Знімає
                    *[other] зняти
                } {NATURALFIXED($time, 3)} {MANY("second", $time)} ефекту {LOC($key)}
    }

entity-effect-guidebook-status-effect =
    { $type ->
        [update]{ $chance ->
                    [1] Спричиняє
                    *[other] спричинити
                 } {$key} щонайменше на {NATURALFIXED($time, 3)} {MANY("second", $time)} без накопичення
        [add]   { $chance ->
                    [1] Спричиняє
                    *[other] спричинити
                } {$key} щонайменше на {NATURALFIXED($time, 3)} {MANY("second", $time)} з накопиченням
        [set]  { $chance ->
                    [1] Спричиняє
                    *[other] спричинити
                } {$key} щонайменше на {NATURALFIXED($time, 3)} {MANY("second", $time)} без накопичення
        *[remove]{ $chance ->
                    [1] Знімає
                    *[other] зняти
                } {NATURALFIXED($time, 3)} {MANY("second", $time)} ефекту {$key}
    } { $delay ->
        [0] негайно
        *[other] після затримки у {NATURALFIXED($delay, 3)} сек.
    }

entity-effect-guidebook-status-effect-indef =
    { $type ->
        [update]{ $chance ->
                    [1] Спричиняє
                    *[other] спричинити
                 } {$key} назавжди
        [add]   { $chance ->
                    [1] Спричиняє
                    *[other] спричинити
                } {$key} назавжди
        [set]  { $chance ->
                    [1] Спричиняє
                    *[other] спричинити
                } {$key} назавжди
        *[remove]{ $chance ->
                    [1] Знімає
                    *[other] зняти
                } {$key}
    } { $delay ->
        [0] негайно
        *[other] після затримки у {NATURALFIXED($delay, 3)} сек.
    }

entity-effect-guidebook-knockdown =
    { $type ->
        [update]{ $chance ->
                    [1] Спричиняє
                    *[other] спричинити
                    } {LOC($key)} щонайменше на {NATURALFIXED($time, 3)} {MANY("second", $time)} без накопичення
        [add]   { $chance ->
                    [1] Спричиняє
                    *[other] спричинити
                } збиття з ніг щонайменше на {NATURALFIXED($time, 3)} {MANY("second", $time)} з накопиченням
        *[set]  { $chance ->
                    [1] Спричиняє
                    *[other] спричинити
                } збиття з ніг щонайменше на {NATURALFIXED($time, 3)} {MANY("second", $time)} без накопичення
        [remove]{ $chance ->
                    [1] Знімає
                    *[other] зняти
                } {NATURALFIXED($time, 3)} {MANY("second", $time)} збиття з ніг
    }

entity-effect-guidebook-set-solution-temperature-effect =
    { $chance ->
        [1] Встановлює
        *[other] встановити
    } температуру розчину рівно на {NATURALFIXED($temperature, 2)}к

entity-effect-guidebook-adjust-solution-temperature-effect =
    { $chance ->
        [1] { $deltasign ->
                [1] Додає
                *[-1] Забирає
            }
        *[other]
            { $deltasign ->
                [1] додати
                *[-1] забрати
            }
    } теплову енергію розчину, поки температура не складе { $deltasign ->
                [1] максимум {NATURALFIXED($maxtemp, 2)}к
                *[-1] мінімум {NATURALFIXED($mintemp, 2)}к
            }

entity-effect-guidebook-adjust-reagent-reagent =
    { $chance ->
        [1] { $deltasign ->
                [1] Додає
                *[-1] Видаляє
            }
        *[other]
            { $deltasign ->
                [1] додати
                *[-1] видалити
            }
    } {NATURALFIXED($amount, 2)}од {$reagent} { $deltasign ->
        [1] до
        *[-1] з
    } розчину

entity-effect-guidebook-adjust-reagent-group =
    { $chance ->
        [1] { $deltasign ->
                [1] Додає
                *[-1] Видаляє
            }
        *[other]
            { $deltasign ->
                [1] додати
                *[-1] видалити
            }
    } {NATURALFIXED($amount, 2)}од реагентів групи {$group} { $deltasign ->
            [1] до
            *[-1] з
        } розчину

entity-effect-guidebook-adjust-temperature =
    { $chance ->
        [1] { $deltasign ->
                [1] Додає
                *[-1] Забирає
            }
        *[other]
            { $deltasign ->
                [1] додати
                *[-1] забрати
            }
    } {POWERJOULES($amount)} тепла { $deltasign ->
            [1] до
            *[-1] від
        } тіла, в якому знаходиться

entity-effect-guidebook-chem-cause-disease =
    { $chance ->
        [1] Викликає
        *[other] викликати
    } хворобу { $disease }

entity-effect-guidebook-chem-cause-random-disease =
    { $chance ->
        [1] Викликає
        *[other] викликати
    } хвороби { $diseases }

entity-effect-guidebook-jittering =
    { $chance ->
        [1] Викликає
        *[other] викликати
    } тремтіння

entity-effect-guidebook-clean-bloodstream =
    { $chance ->
        [1] Очищає
        *[other] очистити
    } кровотік від інших хімічних речовин

entity-effect-guidebook-cure-disease =
    { $chance ->
        [1] Лікує
        *[other] вилікувати
    } хвороби

entity-effect-guidebook-eye-damage =
    { $chance ->
        [1] { $deltasign ->
                [1] Завдає
                *[-1] Лікує
            }
        *[other]
            { $deltasign ->
                [1] завдати
                *[-1] вилікувати
            }
    } пошкодження очей

entity-effect-guidebook-vomit =
    { $chance ->
        [1] Викликає
        *[other] викликати
    } блювоту

entity-effect-guidebook-create-gas =
    { $chance ->
        [1] Створює
        *[other] створити
    } { $moles } { $moles ->
        [1] моль
        *[other] молів
    } { $gas }

entity-effect-guidebook-drunk =
    { $chance ->
        [1] Викликає
        *[other] викликати
    } сп'яніння

entity-effect-guidebook-electrocute =
    { $chance ->
        [1] { $stuns ->
            [true] Вражає струмом
            *[false] Б'є струмом
            }
        *[other] { $stuns ->
            [true] вразити струмом
            *[false] вдарити струмом
            }
    } організм на {NATURALFIXED($time, 3)} {MANY("second", $time)}

entity-effect-guidebook-emote =
    { $chance ->
        [1] Змушує
        *[other] змусити
    } організм [bold][color=white]{$emote}[/color][/bold]

entity-effect-guidebook-extinguish-reaction =
    { $chance ->
        [1] Гасить
        *[other] загасити
    } вогонь

entity-effect-guidebook-flammable-reaction =
    { $chance ->
        [1] Підвищує
        *[other] підвищити
    } займистість

entity-effect-guidebook-ignite =
    { $chance ->
        [1] Підпалює
        *[other] підпалити
    } організм

entity-effect-guidebook-make-sentient =
    { $chance ->
        [1] Робить
        *[other] зробити
    } організм розумним

entity-effect-guidebook-make-polymorph =
    { $chance ->
        [1] Перетворює
        *[other] перетворити
    } організм на { $entityname }

entity-effect-guidebook-modify-bleed-amount =
    { $chance ->
        [1] { $deltasign ->
                [1] Викликає
                *[-1] Зменшує
            }
        *[other] { $deltasign ->
                    [1] викликати
                    *[-1] зменшити
                 }
    } кровотечу

entity-effect-guidebook-modify-blood-level =
    { $chance ->
        [1] { $deltasign ->
                [1] Підвищує
                *[-1] Знижує
            }
        *[other] { $deltasign ->
                    [1] підвищити
                    *[-1] знизити
                 }
    } рівень крові

entity-effect-guidebook-paralyze =
    { $chance ->
        [1] Паралізує
        *[other] паралізувати
    } організм щонайменше на {NATURALFIXED($time, 3)} {MANY("second", $time)}

entity-effect-guidebook-movespeed-modifier =
    { $chance ->
        [1] Змінює
        *[other] змінити
    } швидкість руху на {NATURALFIXED($sprintspeed, 3)}x щонайменше на {NATURALFIXED($time, 3)} {MANY("second", $time)}

entity-effect-guidebook-reset-narcolepsy =
    { $chance ->
        [1] Тимчасово відкладає
        *[other] тимчасово відкласти
    } нарколепсію

entity-effect-guidebook-wash-cream-pie-reaction =
    { $chance ->
        [1] Змиває
        *[other] змити
    } кремовий пиріг з обличчя

entity-effect-guidebook-cure-zombie-infection =
    { $chance ->
        [1] Лікує
        *[other] вилікувати
    } активну зомбі-інфекцію

entity-effect-guidebook-cause-zombie-infection =
    { $chance ->
        [1] Заражає
        *[other] заразити
    } особу зомбі-інфекцією

entity-effect-guidebook-innoculate-zombie-infection =
    { $chance ->
        [1] Лікує
        *[other] вилікувати
    } активну зомбі-інфекцію, та надає імунітет до майбутніх заражень

entity-effect-guidebook-reduce-rotting =
    { $chance ->
        [1] Відновлює
        *[other] відновити
    } {NATURALFIXED($time, 3)} {MANY("second", $time)} гниття

entity-effect-guidebook-area-reaction =
    { $chance ->
        [1] Спричиняє
        *[other] спричинити
    } реакцію диму або піни на {NATURALFIXED($duration, 3)} {MANY("second", $duration)}

entity-effect-guidebook-add-to-solution-reaction =
    { $chance ->
        [1] Спричиняє
        *[other] спричинити
    } додавання {$reagent} до його внутрішнього контейнера з розчином

entity-effect-guidebook-artifact-unlock =
    { $chance ->
        [1] Допомагає
        *[other] допомогти
        } розблокувати інопланетний артефакт.

entity-effect-guidebook-artifact-durability-restore =
    Відновлює {$restored} міцності в активних вузлах інопланетних артефактів.

entity-effect-guidebook-plant-attribute =
    { $chance ->
        [1] Коригує
        *[other] скоригувати
    } {$attribute} на {$positive ->
    [false] [color=red]{$amount}[/color]
    *[true] [color=green]{$amount}[/color]
    }

entity-effect-guidebook-plant-cryoxadone =
    { $chance ->
        [1] Омолоджує
        *[other] омолодити
    } рослину, залежно від її віку та часу росту

entity-effect-guidebook-plant-phalanximine =
    { $chance ->
        [1] Відновлює
        *[other] відновити
    } життєздатність рослини, яка стала нежиттєздатною через мутацію

entity-effect-guidebook-plant-remove-kudzu =
    { $chance ->
        [1] Видаляє
        *[other] видалити
    } зарості кудзу з рослини

entity-effect-guidebook-plant-diethylamine =
    { $chance ->
        [1] Збільшує
        *[other] збільшити
    } тривалість життя рослини та/або її базове здоров'я з шансом 10% для кожного

entity-effect-guidebook-plant-robust-harvest =
    { $chance ->
        [1] Збільшує
        *[other] збільшити
    } потенцію рослини на {$increase} до максимуму {$limit}. Призводить до втрати рослиною насіння, коли потенція досягає {$seedlesstreshold}. Спроба збільшити потенцію понад {$limit} може призвести до зниження врожайності з шансом 10%

entity-effect-guidebook-plant-seeds-add =
    { $chance ->
        [1] Відновлює
        *[other] відновити
    } насіння рослини

entity-effect-guidebook-plant-seeds-remove =
    { $chance ->
        [1] Видаляє
        *[other] видалити
    } насіння рослини

entity-effect-guidebook-plant-mutate-chemicals =
    { $chance ->
        [1] Мутує
        *[other] мутувати
    } рослину для вироблення {$name}

entity-effect-guidebook-add-reagent-to-bloodstream =
    { $chance ->
        [1] Вводить
        *[other] ввести
    } {$quantity} {$reagent} безпосередньо в кровотік

entity-effect-disarm =
    { $chance ->
        [1] Роззброює
        *[other] роззброїти
    } сутність
