# Tworzenie gry w CANVAS

Tworzenie gry często wymaga jakiegoś tła, wizerunku postaci, elementów otoczenia. Aby
postać w grze nie była smutnym prostokątem, można skorzystać z wczytywania grafiki
po ścieżce (no chyba że jest to prymitywny snake) i dlatego najlepiej skorzystać z funkcji
`drawImage`. W poniższym tutorialu jest dużo przydatnych gotowców:

https://developer.mozilla.org/en-US/docs/Web/API/Canvas_API/Tutorial/Using_images

W grze często występują ruchome elementy. Można skorzystać z trzech głównych
funkcji:

`setInterval(function, delay)` – dla animacji bez kontroli - coś się rusza
`setTimeout(function, delay)` – dla animacji np. Postaci wraz ze sterowaniem
`requestAnimationFrame(callback)` – polecana do stosowania, działa płynniej

Dokładny opis stosowania funkcji z przykładami:

https://developer.mozilla.org/en-US/docs/Web/API/Canvas_API/Tutorial/Basic_animations

Do gry przyda się również fizyka, czy boczne ściany przez które użytkownik nie będzie
mógł przejść. Do tego można skorzystać z zaawansowanych opcji animacji:

https://developer.mozilla.org/en-US/docs/Web/API/Canvas_API/Tutorial/Advanced_animations

Ostatni link zawiera przykłady gier jakie zostały napisane w canvas, a także tutorial krok
po kroku dla gry breakout:

https://developer.mozilla.org/en-US/docs/Games
