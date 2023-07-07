## Опис на апликацијата
Апликацијата што ја развиваме е играта Pong.
### Како се игра играта
Играта се игра од два играчи претставени како палки поставени на левиот и десниот крај. 
Палките може да се движат само нагоре или надоле, обидувајќи се да го одбијат топчето. 
Целта е топчето коешто постојано се движи да ја помине палката на другиот играч. 
Така се постигнува поен во играта. Дополнително за играта да биде поинтересна, на средината како трета палка постојано се 
движи ѕид во насока нагоре-надоле и топчето со текот на времето се движи се побрзо. Играта се игра до 3 поени.  

Движење на левиот играч:
- Притискање на тастерот W: движење нагоре
- Притискање на тастерот S: движење надоле

Движење на десниот играч:  
- Притискање на тастерот ↑ (Up arrow key): движење нагоре
- Притискање на тастерот ↓ (Down arrow key): движење надоле
## Решение на проблемот
### Класи
Класа Ball - го претставува топчето и содржи:
- променлива Point Center - центарот на топчето
- променлива static int Radius - радиусот на топчето
- променлива Color Color - бојата на топчето  

Класа Line – ја преставува границата за палките и топчето
- променлива Point Left - крајната лева точка на границата
- променлива Point Right - крајната десна точка на границата  

Класа Player – ја претставува палката на играчот и ѕидот
- променлива int Width - ширината на палката
- променлива int Height - висината на палката
- променлива int ColorNumber - бојата на палката
- променлива Point Center - централната точка на палката

Класа Scene - ја претставува играта
- променлива float Width - ширината на формата
- променлива float Height - висината на формата
- променлива Player Player1 - палката на левиот играч
- променлива Player Player2 - палката на десниот играч
- променлива Player Wall - палката на ѕидот
- променлива Line Up - горната граница
- променлива Line Down - долната граница
- променлива Ball ball - топчето
- променлива bool UpDown - променлива за контрола на движењето на ѕидот
- променлива double ballVelocityX - брзина на топчето по x-оска
- променлива double ballVelocityY - брзина на топчето по y-оска
- променлива int nextX - следната вредност на центарот на топчето по x-оска
- променлива int nextY - следната вредност на центарот на топчето по y-оска
- променлива static float MAXBOUNCEANGLE - максималниот агол на одбивање на топчето
- променлива Random random - за поставување случајни вредности
- променлива bool IsWallInGame - дали палката на ѕидот е во игра
- променлива bool IsBallInGame - дали топчето е во игра
- променлива int FirstPlayerPoints - поените на левиот играч
- променлива int SecondPlayerPoints - поените на десниот играч
- променлива bool Pause - дали играта е завршена
## Опис на функции
Функција MoveBall() служи за контрола на движењето на топчето, односно определување на наредната позиција на топчето

    internal void MoveBall()
    {
        // Проверка дали топчето ја поминало левата палка
        if (ball.Center.X < Player1.Center.X && !Pause)
        {
            // Десниот играч постигнува поен и ресетирање во почетна состојба
            IsBallInGame = false;
            IsWallInGame = false;
            SecondPlayerPoints++;
            // Проверка дали десниот играч освоил 3 поени (играта завршува)
            if (SecondPlayerPoints == 3)
            {
                Pause = true;
                DialogResult dialog = MessageBox.Show("Player 2 won! \n Do you want to restart the game?", "pong", MessageBoxButtons.YesNo);
                // Проверка дали ќе се игра уште еднаш
                if (dialog == DialogResult.Yes)
                {
                    // Ресетирање на палките и вредностите за поени
                    FirstPlayerPoints = 0;
                    SecondPlayerPoints = 0;
                    Player1 = new Player(new Point((int)(Width / 10), (int)((Up.Left.Y + Down.Left.Y) / 2)), 1);
                    Player2 = new Player(new Point((int)(Width / 10 * 9), (int)((Up.Left.Y + Down.Left.Y) / 2)), 2);
                    Pause = false;

                }
                else
                    Application.Exit();
            }
            resetMovementValues();
            return;
        }
        // Проверка дали топчето ја поминало десната палка
        else if (ball.Center.X > Player2.Center.X && !Pause)
        {
            // Левиот играч постигнува поен и ресетирање во почетна состојба
            IsBallInGame = false;
            IsWallInGame = false;
            FirstPlayerPoints++;
            // Проверка дали левиот играч освоил 3 поени (играта завршува)
            if (FirstPlayerPoints == 3)
            {
                Pause = true;
                DialogResult dialog = MessageBox.Show("Player 1 won! \n Do you want to restart the game?", "pong", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Проверка дали ќе се играта уште еднаш
                if (dialog == DialogResult.Yes)
                {
                    // Ресетирање на палките и вредностите за поени
                    FirstPlayerPoints = 0;
                    SecondPlayerPoints = 0;
                    Player1 = new Player(new Point((int)(Width / 10), (int)((Up.Left.Y + Down.Left.Y) / 2)), 1);
                    Player2 = new Player(new Point((int)(Width / 10 * 9), (int)((Up.Left.Y + Down.Left.Y) / 2)), 2);
                    Pause = false;
                }
                else
                    Application.Exit();

            }
            resetMovementValues();
            return;
        }

        // Конверзија на топчето, палките и ѕидот како правоаголници
        Rectangle rectangleBall = new Rectangle(ball.Center.X - Ball.Radius, ball.Center.Y - Ball.Radius, 2 * Ball.Radius, 2 * Ball.Radius); ;
        Rectangle rectanglePlayer1 = new Rectangle(Player1.Center.X - Player1.Width / 2, Player1.Center.Y - Player1.Height / 2, Player1.Width, Player1.Height);
        Rectangle rectanglePlayer2 = new Rectangle(Player2.Center.X - Player2.Width / 2, Player2.Center.Y - Player2.Height / 2, Player2.Width, Player2.Height);
        Rectangle rectangleWall = new Rectangle(Wall.Center.X - Wall.Width / 2, Wall.Center.Y - Wall.Height / 2, Wall.Width, Wall.Height);

        // Проверка дали топчето ја погодува (ја сече) палката на левиот играч
        if (rectangleBall.IntersectsWith(rectanglePlayer1))
        {
            var bounceAngle = CalculateBounceDirection(ball.Center.Y, Player1.Center.Y - Player1.Height / 2, Player1.Height);
            var angleInRad = bounceAngle * (Math.PI / 180);

            // Пресметка на новите вредности на центарот на топчето во зависност на аголот на одбивање од палката
            nextX = (int)(ballVelocityX * Math.Cos(angleInRad));
            nextY = (int)(ballVelocityY * -Math.Sin(angleInRad));
        }
        // Проверка дали топчето ја погодува (ја сече) палката на десниот играч
        else if (rectangleBall.IntersectsWith(rectanglePlayer2))
        {
            var bounceAngle = CalculateBounceDirection(ball.Center.Y, Player2.Center.Y - Player2.Height / 2, Player2.Height);
            var angleInRad = bounceAngle * (Math.PI / 180);

            // Пресметка на новите вредности на центарот на топчето во зависност на аголот на одбивање од палката
            nextX = -(int)(ballVelocityX * Math.Cos(angleInRad));
            nextY = (int)(ballVelocityY * -Math.Sin(angleInRad));
        }
        // Проверка дали топчето ја погодува (ја сече) палката на ѕидот
        else if (IsWallInGame && rectangleBall.IntersectsWith(rectangleWall))
        {
            var bounceAngle = CalculateBounceDirection(ball.Center.Y, Wall.Center.Y - Wall.Height / 2, Wall.Height);
            var angleInRad = bounceAngle * (Math.PI / 180);
            int sign = 1;
            // Проверка на насоката на движење на топчето за да се одбие на спротивната насока
            if (nextX > 0)
            {
                sign = -1;
            }
            // Пресметка на новите вредности на центарот на топчето во зависност на аголот на одбивање од палката
            nextX = (int)(ballVelocityX * Math.Cos(angleInRad)) * sign;
            nextY = (int)(ballVelocityY * -Math.Sin(angleInRad));
        }
        // Проверка дали топчето ја стигнало горната или долната граница
        if (ball.Center.Y - Ball.Radius <= Height / 8 || ball.Center.Y + Ball.Radius > Height / 10 * 8)
        {
            // Движење на топчето во спротивна вертикална насока
            nextY *= -1;
        }
        // Аплицирање на соодветните вредности за центарот на топчето
        ball.Move(nextX, nextY);
    }
Функција CalculateBounceDirection(int ballY, int paddleY, int paddleHeight) служи за одредување на аголот на одбивање на топчето од палките. 
Како аргументи оваа функција ги зема позицијата на топчето по y-оска, позицијата на горната граница на палката по y-оска и висината на палката. 
Аголот на одбивање е поголем колку позицијата на којашто се одбива топчето од центарот на палката е поголем. 
Доколку се удри со горниот дел од палката топчето се одбива во нагорна насока, а доколку се удри со долниот дел од палката топлето се одбива во надолна насока. 
Максималниот агол на одбивање е 75 степени.

        static float CalculateBounceDirection(int ballY, int paddleY, int paddleHeight)
        {
            float relativeIntersectY = (paddleY + (paddleHeight / 2)) - ballY;
            float normalizedIntersectY = relativeIntersectY / (paddleHeight / 2);
            float bounceAngle = normalizedIntersectY * MAXBOUNCEANGLE;
            bounceAngle = Math.Max(-75, Math.Min(75, bounceAngle));
            return bounceAngle;
        }
## Изглед на апликацијата
Почетен изглед на прозорецот:
![image](https://github.com/FilipTrajanoski/Proekt_VP/assets/127451559/1e4f2fe2-b28f-4a28-9067-3c77274f4286)  
Изглед на прозорецот по 8-10 секунди:
![image](https://github.com/FilipTrajanoski/Proekt_VP/assets/127451559/cc954eb5-44f0-47e3-925a-0209f339fe63)  
Изглед на прозорецот по завршување на играта (победа на еден од играчите):
![image](https://github.com/FilipTrajanoski/Proekt_VP/assets/127451559/448ad9f9-9e0b-400c-aab1-b21562e132e8)  
