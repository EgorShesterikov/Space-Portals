# Space Portals

Проект реализован в формате быстрой игры на архитектурном шаблоне MVP с использованием следующих фрейворков:
1.	Zenject - для прокидывания зависимостей и общего биндинга
2.	UniRx - для организации реактивных свойств модели и удобному отслеживанию событий
3.	DOTween - для реализации анимаций и их последовательностей в коде, без создания аниматоров

![]()

Осмотрев код, можно заметить, что Presenter перегружен ссылками на различные вспомогательные системы, такую логику можно было подразделить на компоненты, 
но мной было принято решение оставить такой вариант, что бы не разбрасываться логикой по разным классам. 
(Игра в целом не будет расширяться далее, и сделана как прототип для оттачивания навыков)

# Игровая механика

Основной задачей игры является выживание шарика в как можно дольшем временном промежутке. 
Сцена состоит из порталов, которые предсталвяю собой механику телепорта от одного к другому (по цветам)

![]()

Чем дольше игрок держится в игре, тем быстрей начинают появлятся различные эффекты, в том числе и бомбы, которые являются основной причиной для поражения.
А также - порталы имеют свойство перемешиваться, тем самым усложняя игровой процесс.

# Настройки

В игре реализована система настроек, в которой мы можем менять значения музыки и звуков.

![]()

Система сохранения значений настроек, а также прогресса игрока. Перезапустив игру, все ваши настройки и достижения останутся на месте.

# Магазин

Заработанные монеты можно потратить на покупку новых шариков, которые обладают уникальными эффектами!

![]()