namespace Last_project
{
    public partial class Form1 : Form
    {

        int pipeSpeed = 8;
        int gravity = 15;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
        }
        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Score: " + score;

            if (pipeBottom.Left < -150)
            {
                pipeBottom.Left = 950;
                score++;
            }
            if (pipeTop.Left < -180)
            {
                pipeTop.Left = 1100;
                score++;
            }

            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds)
              
                )
            {
                endGame();
            }

            if(score > 5)
            {
                pipeSpeed = 15;

            }

            if(flappyBird.Top < -25)
            {

               endGame();
            }


        }




        private void gamekeyisdown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Space)
            {

                gravity = -15;
            }

        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Space)
            {

                gravity = 15;
            }


        }

        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += " YOU LOST HAHAH";
        }
    }
}