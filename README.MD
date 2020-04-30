# Лексер, парсер, компилятор скриптового языка VKScript

**VKScript** - язык, похожий на **JavaSсript** или **ActionScript** (предполагается совместимость с **ECMAScript**). Алгоритм должен завершаться командой **return %выражение%**. Операторы должны быть разделены точкой с запятой.

> Внутри **code** может содержаться не более 25 обращений к методам API.

Пример значения параметра code

> <pre>
> // присваивает переменной a результат поиска по фотографиям с данными параметрами
> var a = API.photos.search({"q":"Nature","count":3});
>
> // присваивает переменной b список владельцев найденных фотографий
> var b = a.items@.owner_id;
>
> // присваивает переменной с данные о страницах владельцев из списка b
> var c = API.users.get({"user_ids":b});
>
> // возвращает список фамилий из данных о владельцах
> return c@.last_name;
>
> // пример цикла
> var a = 1;
> var b = 10;
> while (b != 0) {
>     b = b - 1;
>     a = a + 1;
> };
> return a;
> </pre>

То же самое можно более коротко записать так:

> <pre>return API.users.get({"user_ids": API.photos.search({"q":"Beatles", "count":3}).items@.owner_id})@.last_name; <br></pre>

Поддерживаются:

* арифметические операции
* логические операции
* создание массивов и списков ([X,Y])
* **parseInt** и **parseDouble**
* конкатенация (+)
* конструкция **if**
* фильтр массива по параметру (@.)
* вызовы методов **API**, параметр **length**
* циклы, используя оператор **while**
* методы Javascript: **slice**, **push**, **pop**, **shift**, **unshift**, **splice**, **substr**, **split**
* оператор **delete**
* присваивания элементам маcсива,  например: row.user.action = "test";
* поиск в массиве или строке — **indexOf**, например: "123".indexOf(2) = 1, [1, 2, 3].indexOf(3) = 2. Возвращает -1, если элемент не найден.

В данный момент не поддерживается создание функций.

Обращение к элементам массива с результатом какого-либо метода всего должно основываться на структуре JSON, а не XML. Например, правильным обращением является

<tt>API.photos.search({"q":"Nature","count":3}).items@.owner_id;</tt>, а не

<tt>API.photos.search({"q":"Nature","count":3}).items@.photo@.owner_id;</tt>

 Метод **execute** также может использоваться и для получения результатов нескольких не связанных между собой запросов.

Пример значений параметра code

> <tt>return [API.users.isAppUser(), API.friends.get(), API.status.get()];</tt>

> <tt>return {"user": API.users.isAppUser(), "friends": API.friends.get(), "status": API.status.get()};</tt>

 В методе **execute** поддерживаются логические операции **<** (меньше), **>** (больше), **<=** (меньше или равно), **>=** (больше или равно), **==** (равно) и **!=** (не равно). В данный момент поддерживаются сравнения двух строк, двух чисел и строки и числа (в этом случае строка приводится к числу).

 Результат логического выражения может быть использован в управляющей конструкции **if** ... [**else** ...]:

Пример значения параметра code

> <tt><pre>var posts = API.wall.get({"count": 1});
> if (posts.count&lt;0) {
>   return {"post": null, "copy_owner": null};
> } else {
>   var post = posts.items[0];
>   var copy_owner=null;
>   if (post.copy_history[0]){
>     if (post.copy_history[0].owner_id &gt; 0) {
>       copy_owner = API.users.get({"user_id": post.copy_history[0].owner_id})[0];
>     } else
>     if (post.copy_history[0].owner_id  &lt; 0) {
>       copy_owner = API.groups.getById({"group_ids": -post.copy_history[0].owner_id})[0];
>     }
>     return {"post": post, "copy_owner": copy_owner};
>   } else {
>     return {"post": post, "copy_owner": null};
>   }
> }</pre></tt>
