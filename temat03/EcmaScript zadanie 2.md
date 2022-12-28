# ECMASCRIPT + HTML5 = CANVAS

## ZADANIE 1: GRA

Biedny, samotny, czerwony prostokąt żyje w pustym świecie, w którym może sobie tylko spacerować bez celu. 
Marzy mu się, żeby mieć wielu przyjaciół podobnych do niego, z którymi mógłby wspólnie spędzać czas grając w 
Breakout/Space Invaders/Teris/Micromachines/Snake’a.

Twoim zadaniem jest, w oparciu o załączony szkielet, zaprogramowanie, prawie od zera, gry, która będzie 
wariacją na temat klasycznych tytułów.

Więcej o samej tkaninie (canvasie): https://developer.mozilla.org/en-US/docs/Web/API/Canvas_API

``` html
<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <meta http-equiv="X-UA-Compatible" content="ie=edge">
  <title>Document</title>
  <style>
  /* definiujemy pozycję i rozmiar tkaniny */
  #main {
    width: 640px;
    height: 480px;
    margin: auto;
    border: 1px solid black;
  }
  </style>

  <script>
  var canvas
  var ctx // uchwyt kontekstu tkaniny pozwalający na operowanie na niej
  var pos_x = 320, pos_y = 300 // zmienne pozycji bohatera
  var welcome_screen = true // stan ekranu powitalnego

  /**
   * funkcja rysująca bohatera na tkaninie
   */
  function draw_hero() {
    ctx.save() // zachowanie stanu kontekstu
    ctx.fillStyle = 'rgba(255, 0, 0, 1)'; // ustawienie koloru wypełnienia
    ctx.translate(pos_x, pos_y) // przesunięcie tkaniny tak, aby narysowny
      // bohater znalazł się w odpowiednim miejscu

    ctx.fillRect(0,0,10,30) // narysowanie bohatera
    ctx.restore() // przywrócenie stanu kontekstu
  }

  /**
   * funkcja wywoływana cyklicznie przerysowująca tkaninę
   */
  function redraw(){
    ctx.clearRect(0,0,640,480) // czyszczenie tkaniny
    draw_hero()
  }

  /**
   * funkcja inicjalizująca grę i tworząca ekran powitalny
   */
  function init() {
    window.addEventListener( "keydown", keyListener, false )
      // skojarzenie funkcji obsługi klawiatury ze zdarzeniem

    canvas = document.getElementById('game')
      // pobranie wskazania na element tkaniny

    ctx = canvas.getContext('2d')
      // pobranie kontekstu grafiki dwuwymiarowej dla tkaniny

    ctx.font = '48px sans-serif'
    ctx.textAlign = 'center'
      // ustawienie dla tkaniny kroju pisma i sposobu wyrównania
      // tekstu

    ctx.fillText('READY PLAYER ONE?', 320, 240)
      // umieszczenie napisu na ekranie powitalnym

    draw_hero()
  }

  /**
   * funkcja obsługi klawiatury
   */
  function keyListener(e) {
    if(welcome_screen) { // jeżeli ekran powitalny to wyczyść
      ctx.clearRect(0,0,640,480)
      welcome_screen = false
      window.setInterval(redraw, 10)
        // podłączenie funckji przerysowania tkaniny
    }
    switch(e.keyCode) {
      case 37: // naciśnięto strzałkę w lewo
        pos_x-=10
        break
      case 38: // naciśnięto strzałkę w górę
        break
      case 39: // naciśnięto strzałkę w prawo
        pos_x+=10
        break
      case 40: // naciśnięto strzałkę w dół
        break
    }
  }
  </script>
</head>
<body onload="init()">
  <div id="main">
  <canvas id="game" width="640" height="480">
    Zacznij w końcu używać współczesnej przeglądarki!
  </canvas>
  </div>
</body>
</html>
```
