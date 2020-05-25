using System;
using WPF_Miner.Controls;

namespace WPF_Miner.Data
{
    public static class Utils
    {
        /// <summary>
        /// Accessory method for go throw all the cells on gaming field
        /// </summary>
        /// <param name="cells">Array of all cells on the game field</param>
        /// <param name="process">Action to do</param>
        /// <param name="_bombsAmount">Amount of the bombs</param>
        public static void ForEach(Cell[,] cells, Action<Cell> process)
        {
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    Cell _cell = cells[i, j];
                    process(_cell);
                }
            }
        }

        //A pack of static methods for loading images
        public static readonly Uri BombUri = new Uri("pack://application:,,,/Images/bomb.bmp", UriKind.RelativeOrAbsolute);
        public static readonly Uri AdvancedBombUri = new Uri("pack://application:,,,/Images/AdvancedBomb.bmp", UriKind.RelativeOrAbsolute);
        public static readonly Uri BombErrorUri = new Uri("pack://application:,,,/Images/bomb_error.bmp", UriKind.RelativeOrAbsolute);
        public static readonly Uri BombExplodeUri = new Uri("pack://application:,,,/Images/bomb_explode.bmp", UriKind.RelativeOrAbsolute);
        public static readonly Uri ButtonUri = new Uri("pack://application:,,,/Images/button.bmp", UriKind.RelativeOrAbsolute);
        public static readonly Uri EmptyUri = new Uri("pack://application:,,,/Images/empty.bmp", UriKind.RelativeOrAbsolute);
        public static readonly Uri FlagUri = new Uri("pack://application:,,,/Images/flag.bmp", UriKind.RelativeOrAbsolute);
        public static readonly Uri B1Uri = new Uri("pack://application:,,,/Images/b1.bmp", UriKind.RelativeOrAbsolute);
        public static readonly Uri B2Uri = new Uri("pack://application:,,,/Images/b2.bmp", UriKind.RelativeOrAbsolute);
        public static readonly Uri B3Uri = new Uri("pack://application:,,,/Images/b3.bmp", UriKind.RelativeOrAbsolute);
        public static readonly Uri B4Uri = new Uri("pack://application:,,,/Images/b4.bmp", UriKind.RelativeOrAbsolute);
        public static readonly Uri B5Uri = new Uri("pack://application:,,,/Images/b5.bmp", UriKind.RelativeOrAbsolute);
        public static readonly Uri B6Uri = new Uri("pack://application:,,,/Images/b6.bmp", UriKind.RelativeOrAbsolute);
        public static readonly Uri B7Uri = new Uri("pack://application:,,,/Images/b7.bmp", UriKind.RelativeOrAbsolute);
        public static readonly Uri B8Uri = new Uri("pack://application:,,,/Images/b8.bmp", UriKind.RelativeOrAbsolute);
        public static readonly Uri QuestionUri = new Uri("pack://application:,,,/Images/question.bmp", UriKind.RelativeOrAbsolute);
        public static readonly Uri FaceSmileUri = new Uri("pack://application:,,,/Images/face_smile.png", UriKind.RelativeOrAbsolute);
        public static readonly Uri FaceSadUri = new Uri("pack://application:,,,/Images/face_sad.png", UriKind.RelativeOrAbsolute);
        public static readonly Uri FaceUri = new Uri("pack://application:,,,/Images/face.png", UriKind.RelativeOrAbsolute);

    }

    public static class ForEachClass
    {
        public static void ForEach(this Cell[,] cells, Action<Cell> process)
        {
            Utils.ForEach(cells, process);
        }
    }
}
