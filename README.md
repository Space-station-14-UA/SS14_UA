<div class="header" align="center">  
<img alt="Space Station 14" width="880" height="300" src="https://raw.githubusercontent.com/space-wizards/asset-dump/de329a7898bb716b9d5ba9a0cd07f38e61f1ed05/github-logo.svg"> 
</div>

Space Station 14 це ремейк SS13 що працює на [Robust Toolbox](https://github.com/space-wizards/RobustToolbox), нашому самописномурушії, написаному на C#.

Це основний репозиторій для Space Station 14. Щоб запобігти створенню форків RobustToolbox, клієнт і сервер завантажують пакет «контенту». Цей пакет містить усе необхідне для гри на одному конкретному сервері.

Якщо ви хочете розміщувати або створювати контент для SS14, це саме те репозиторій, що вам потрібно. Він містить як RobustToolbox, так і пакет контенту для розробки нових пакетів контенту.

## Посилання

<div class="header" align="center">  

[Веб-сайт](https://ss14.com.ua/) | [Дискорд](https://discord.gg/MMUsHnH2Tt) | [Форум](https://ss14.miraheze.org/wiki/%D0%93%D0%BE%D0%BB%D0%BE%D0%B2%D0%BD%D0%B0_%D1%81%D1%82%D0%BE%D1%80%D1%96%D0%BD%D0%BA%D0%B0) | [Реддіт](https://www.reddit.com/r/SpaceStation14_UA/) | [Монобанка](https://send.monobank.ua/jar/8nmcqa8vnz) | [Steam](https://store.steampowered.com/app/1255460/Space_Station_14/) | [Standalone Download](https://spacestation14.com/about/nightlies/)  

</div>

## Документація/Вікі

Наш [сайт](https://docs.spacestation14.com/) має документацію на весь SS14 контент, рушій, ігровий дизайн, та більше.  
Крім того, ознайомтеся з цими матеріалами, щоб дізнатися про ліцензії та вимоги щодо зазначення авторства:  
- [Robust Generic Attribution](https://docs.spacestation14.com/en/specifications/robust-generic-attribution.html)  
- [Robust Station Image](https://docs.spacestation14.com/en/specifications/robust-station-image.html)

У нас також є безліч матеріалів для нових учасників проєкту.

## Внесення Змін

Ми будемо раді бачити будь-яку допомогу у підтримці та розробці нашої версії білду. Процес створення та прийняття ПРів точно такий ж, як й у інших форків. В ідеалі будьте присутніми у [нашому ДС Сервері](https://discord.gg/MMUsHnH2Tt), там 90% інформацій щодо поточних цілей, стандартів перекладу та обговорення подальших змін.

Єдине, першочергова ціль – переклад та додавання невеликих та локально необхідних **САМЕ НАМ змін**. Якщо хочете додати якусь повноцінну механіку чи фішку, краще спочатку спробуйте зробити це до [СС14](https://github.com/space-wizards/space-station-14/).

### Особливості внесення змін

* Зміни в білд Візардів (все поза папок `_Mriya`) варто уникати, за винятком .ftl файлів. Якщо це прототип – краще просто додайте рядки з потрібними вам значеннями до його ванільної версії та не забудьте додати відповідний коментар в обох випадках.
* Зміни в білд Mriya (все в папках `_Mriya`) повинні мати відповідний коментар, наприклад: "`# MR. "Пояснення чому (якщо треба)`", за винятком перекладу або .ftl файлів.
* Додавання нових прототипів/значень/систем повинно йти в білд Mriya (все в папки `_Mriya` або створіть такі, якщо нема), а також їх айді повинні починатися на `MR`, наприклад: `MRKitSherpa` або `MR-plant`. 

  Виключенням є випадки, коли ця змінна буде прив'язуватися до якоїсь вже існуючої системи Візардів/РМС та їй треба мати інший формат айді чи бути у якійсь спеціальній папці.


## НЕ зловживайте ШІ-згенерованим контентом. Перевіряйте ваш код, створюйте Пул-реквести відповідально.

## Побудова білду

1. Клонуйте цей репозиторій:
```shell
git clone https://github.com/space-wizards/space-station-14.git
```
2. Перейдіть до папки проєкту та запустіть файл `RUN_THIS.py`, щоб ініціалізувати підмодулі та завантажити рушій:
```shell
cd space-station-14
python RUN_THIS.py
```
3. Скомпілюйте рішення:  

Побудуйте сервер `dotnet build`.

[Більш детальні інструкції щодо реалізації проєкту.](https://docs.spacestation14.com/en/general-development/setup.html)

## Ліцензія

All code for the content repository is licensed under the [MIT license](https://github.com/space-wizards/space-station-14/blob/master/LICENSE.TXT).  

All code in the _NC directory is licensed under the GNU Affero General Public License version 3.0.

Most assets are licensed under [CC-BY-SA 3.0](https://creativecommons.org/licenses/by-sa/3.0/) unless stated otherwise. Assets have their license and copyright specified in the metadata file. For example, see the [metadata for a crowbar](https://github.com/space-wizards/space-station-14/blob/master/Resources/Textures/Objects/Tools/crowbar.rsi/meta.json).  

> [!NOTE]
> Some assets are licensed under the non-commercial [CC-BY-NC-SA 3.0](https://creativecommons.org/licenses/by-nc-sa/3.0/) or similar non-commercial licenses and will need to be removed if you wish to use this project commercially.
