# WebVisualGame

Студенческий проект web-сервиса для создания текстовых и визуальных новелл.
**ВАЖНО!** На данном этапе, сайт еще не размещен в глобальной сети и недоступен для использования.

## Описание

**Для пользователей** веб-сервис предоставляет возможность исследовать существующие игры, проходить их и сохранять результат прохождения. **Разработчики** могут проектировать свои игры и загружать их на сервер. Для создания игр разработан специальный язык (см. Инструкция для разработчиков)
 
**Имеющийся функционал в процессе разработки.** 

### Что готово на данный момент?
1. Регистрация на сайте, создание аккаунта 
2. Загрузка исходного кода игр в виде текстового файла, их компиляция на сервере и сохранение в базе данных
3. Запуск существующих игр, сохранение игрового прогресса на сервере

### Что планируется сделать?
1. Улучшить визуальное оформление сайта, сделать интерфейс более интерактивным
2. Добавить среду для разработки игр внутрь сервиса - в виде редактора кода, либо средств визуального программирования

# Инструкция для разработчиков

## Краткие сведения о синтаксисе языка создания игр
Для пользователя игровой процесс выглядит как переход между различными состояниями игры посредством выбора действия из предложенных альтернатив.
Задача разработчика заключается в том, чтобы правильно описать игровой сюжет в виде состояний игр, действий доступных в этих состояниях и переходов в другие состояния.

Каждое состояние игры описывается таким образом (<идентификатор состояния>)"<текст, который отображается пользователю>"

Пример:  

> *(start)"Ну что, начнем?"*
    
Мы задали индентификатор *start* для того, чтобы в дальнейшем обращаться к данному состоянию и текст, который увидит пользователь, перешедший в это состояние.
Далее нужно описать действия доступные пользователю в текущем состоянии. Возможно два варианта:
1. От пользователя не требуется совершать выбор, лишь нажать "далее" после прочтения текста. Для этого в конце описания состояния нужно лишь указать идентификатор следующего состояния в квадратных скобках.

Пример:

> *(start)"Привет, игрок!"[name]*  
> *(name)"Как тебя зовут?"...*  
    
2. Пользователю нужно сделать какое-либо действие, совершить выбор. Синтаксис для этого следующий:  

> *(name)"Как тебя зовут?"*  
> *-"Иван"[alter1]*  
> *-"Другое"[alter2]*  

После текста состояния мы перечисляем варианты выбора, доступные пользователю. Отображаться они будут в заданном порядке. При выборе какого-либо варианта, пользователь будет переходить в состояние, индентификатор которого указан в квадратных скобках.

Перечисленного синтаксиса достаточно, чтобы создавать простые игры, более подробная инструкция будет добавлена позже.
  
