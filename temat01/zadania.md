# ECMAScript - rozgrzewka

## Zadanie 1: kalkulator

Korzystając z faktu, że na poziomie interpretera ES przeglądarki za pomocą metod obiektu **document** możliwe jest budowanie struktury DOM stwórz aplikację kalkulatora w oparciu o załączoną postać startową.

1. W funkcji **gen()** korzystając z metody **createElement()** zbuduj interfejs kalkulatora, na który składać się będzie
   - wygenerowana w pętli klawiatura numeryczna
   - klawisze sumy, różnicy, iloczynu i ilorazu
   - klawisze `=` i `.`
   - klawisz kasowania ostatniego znaku i czyszczenia całego bufora
   - "wyświetlacz"
2. Dodaj funkcje obsługi, które zostaną skojarzone z poszczególnymi elementami klawiatury. Przekazanie wartości wybranych poszczególnych klawiszy numerycznych może odbywać się poprzez użycie atrybutów **data**-(pole **dataset** elementu).
3. Zadbaj o poprawność wprowadzanych danych.
4. Dodaj stosowne zmienne i funkcje, które pozwolą na wykonywanie obliczeń.
5. Rozszerz kalkulator o pole "wydruku" historii kolejnych działań i jego obsługę.

``` html
<!DOCTYPE html>
<html lang="en">
<head>
   <meta charset="UTF-8">
   <meta name="viewport"content="width=device-width, initial-scale=1.0">
   <title>Calculator</title>
   <script>
   function gen() {
      const main = document.getElementById("main")
      const key0 = document.createElement("button")
      key0.innerText = 0
      key0.onclick = show
      key0.dataset.value = 0
      main.appendChild(key0)
   }

   function show() {
      alert(this.dataset.value)
   }
   </script>
</head>
<body onload="gen()">
<div id="main">

</div>
</body>
</html>
```

## Zadanie 2: OXO

1. Analogicznie jak to miało miejsce w przypadku poprzedniego zadania napisz aplikację, która generuje planszę do gry "kółko i krzyżyk".
2. Kolejne kliknięcia na planszy powinny, o ile to możliwe, stawiać na zmianę stosowne piony. Dodaj też mechanizmy sprawdzające, czy, któraś ze stron nie wygrała, ewentualnie, czy nie nastąpił remis i powiadamiającą o tym fakcie gracza.
3. Dodaj obsługę resetu planszy w celu rozpoczęcia rozgrywki na nowo.
4. **Bonus**: Rozszerz o możliwość gry z komputerem w oparciu o algorytm minimax.
