using System.ComponentModel;
using System.Windows.Input;

namespace ZH2Konzi
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        
        public ICommand CounterButtonPressedCommand { get; set; }

        public Person MyPerson { get; set; }

        public MainPage()
        {
            BindingContext = this;
            MyPerson = new Person { FirstName = "John", LastName = "Doe", Age = 30 };
            CounterButtonPressedCommand = new Command(OnCounterClicked);
            InitializeComponent();
        }

        private async void OnCounterClicked()
        {
            var result = await CalculateForLongTime();
            MyPerson.FirstName = $"John {result}";
        }

        private async Task<int> CalculateForLongTime()
        {
            int sum = 0;
            for (int i = 0;i< 1000;i++)
            {
                sum++;
                await Task.Delay(10);
            }
            return sum;
        }
    }
}
