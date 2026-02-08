using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;


namespace Losowanie
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<DiceThrow> DiceThrows { get; set; }
        public int FirstDice { get => firstDice; set { firstDice = value; OnPropertyChanged(); } }
        public int SecondDice { get => secondDice; set { secondDice = value; OnPropertyChanged(); } }
        public int ThirdDice { get => thirdDice; set { thirdDice = value; OnPropertyChanged(); } }
        public int FourthDice { get => fourthDice; set { fourthDice = value; OnPropertyChanged(); } }
        public int FifthDice { get => fifthDice; set { fifthDice = value; OnPropertyChanged(); } }
        public int Sum { get => sum; set { sum = value; OnPropertyChanged(); } }


        private readonly Random random;
        private int firstDice;
        private int secondDice;
        private int thirdDice;
        private int fourthDice;
        private int fifthDice;
        private int sum;


        public event PropertyChangedEventHandler? PropertyChanged;


        public MainWindow()
        {
            InitializeComponent();

            DiceThrows = [];
            DataContext = this;

            random = new();
            Sum = 0;
        }


        private void Randomize_Click(object sender, RoutedEventArgs e)
        {
            FirstDice = random.Next(1, 7);
            SecondDice = random.Next(1, 7);
            ThirdDice = random.Next(1, 7);
            FourthDice = random.Next(1, 7);
            FifthDice = random.Next(1, 7);

            int id = DiceThrows.Count + 1;
            List<int> pips = [FirstDice, SecondDice, ThirdDice, FourthDice, FifthDice];

            DiceThrow diceThrow = new(id, pips);

            DiceThrows.Add(diceThrow);

            Sum += diceThrow.Sum;
        }


        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            Sum = 0;
            FirstDice = 0;
            SecondDice = 0;
            ThirdDice = 0;
            FourthDice = 0;
            FifthDice = 0;
            DiceThrows.Clear();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new()
            {
                FileName = "dane.txt"
            };

            bool? isSucces = saveFileDialog.ShowDialog();

            if (isSucces.HasValue && isSucces.Value == true)
            {
                using StreamWriter sw = new(saveFileDialog.FileName);

                foreach (var dice in DiceThrows)
                {
                    sw.WriteLine($"Id: {dice.Id}; Rzuty: {string.Join(",", dice.Pips)}; Suma: {dice.Sum}");
                }
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}